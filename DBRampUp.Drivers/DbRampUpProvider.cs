using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using System.Configuration;
using System.Web.Configuration;
namespace DBRampUp
{
    public class DBRampUpProvider
    {
        public static readonly string DBRampUpProviderName = "DBRampUpProvider";
        protected IList contentParts = null;
        protected static string _projectPath = string.Empty;
        protected int _commandTimeout = 120;
        protected DBRampUpContext context = new DBRampUpContext();

        #region Drop All Objects Script

        protected string dropAllObjectsScript = @"declare @cmd varchar(4000), @id int
DECLARE @cmds table (id int identity(1, 1) not null, cmd varchar(4000) not null)

set nocount on

insert into @cmds ( cmd )
select cmd from (
	/* order 10, 20 for Foreign Key, then Primary */
	select
		N'alter table ' + quotename(TABLE_SCHEMA) + N'.' + quotename(TABLE_NAME) + N' drop constraint ' + quotename(CONSTRAINT_NAME) + N';'
		, case CONSTRAINT_TYPE WHEN N'PRIMARY KEY' then 20 else 10 end as Ordinal
	from
		INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	where
		CONSTRAINT_TYPE IN (N'PRIMARY KEY', N'FOREIGN KEY')  AND TABLE_NAME is not null
	union all
	/* 30: Drop all sprocs next */
	select
		N'drop ' + ROUTINE_TYPE + N' ' + quotename(ROUTINE_SCHEMA) + N'.' + quotename(ROUTINE_NAME) + N';'
		, 30 as Ordinal
	from
		INFORMATION_SCHEMA.ROUTINES
	union all
	/* 40: Drop all views next */
	select
		N'drop view ' + quotename(TABLE_SCHEMA) + N'.' + quotename(TABLE_NAME) + N';'
		, 40 as Ordinal
	from
		INFORMATION_SCHEMA.TABLES
	where
		TABLE_TYPE = N'VIEW'
	union all
	/* 50: Drop all tables next */
	select
		N'drop table ' + quotename(TABLE_SCHEMA) + N'.' + quotename(TABLE_NAME) + N';'
		, 50 as Ordinal
	from
		INFORMATION_SCHEMA.TABLES
	where
		TABLE_TYPE = N'BASE TABLE'
    union all
    /* 60: Drop all Schemas next */
    select
        N'drop schema ' + quotename(SCHEMA_NAME) + N';'
        , 60 as Ordinal
    from
        INFORMATION_SCHEMA.SCHEMATA
    where
        SCHEMA_NAME LIKE N'aspnet_%'
    union all
    /* 70: Drop all Roles next */
    select
        N'DROP ROLE ' + quotename(name) + N';',
		70 as Ordinal
    from 
		sys.database_principals
    WHERE
		name like N'aspnet_%'

) as z (cmd, Ordinal)
order by
	Ordinal

set @id = 1 /* starting point of the identity column we created */
WHILE (1=1)
BEGIN
	select @cmd = c.cmd from @cmds c where c.id = @id
	if @@ROWCOUNT = 0 BREAK
	
	print 'Executing: ' + @cmd
    EXEC (@cmd)
    
    SET @id = @id + 1
END
";
        #endregion Drop All Objects Script

        #region Public Properties

        /// <summary>
        /// The command timeout to use for all Sql Commands executed during site setup.
        /// </summary>
        public virtual int CommandTimeout
        {
            get { return _commandTimeout; }
            set { _commandTimeout = value; }
        }

        /// <summary>
        /// The directory where your project lives (ie where the .Components, .Controls, & .Web folders are)  Defaults to ..\..\ from lib\setup.  If overriding, do it in your constructor.
        /// </summary>
        public static string ProjectPath
        {
            get
            {
                if (string.IsNullOrEmpty(_projectPath)) _projectPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\"));
                return _projectPath;
            }
        }

		/// <summary>
		/// Will Server.MapPath style resolve the url for direct file access.  Normally to be used like: /setup/files/bob.txt
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string MapPath(string path)
		{
			if (path.StartsWith("~/")) path = path.Substring(2);
			path = path.Replace("/", "\\");
			if (path.StartsWith("//")) path = path.Substring(1);
			return Path.Combine(ProjectPath, path);
		}


        protected string _sqlPath = @"Data";
        /// <summary>
        /// The directory where SQL files are located.  Relative to the Project Path.  Defaults to sql.
        /// </summary>  
        public virtual string SqlPath
        {
            get { return _sqlPath; }
            set { _sqlPath = value; }
        }

		/// <summary>
		/// Setting this value will cause all the sql to be executed after test data.
		/// </summary>
		public virtual string SchemaSqlPath
		{
			get;
			set;
		}

        protected Dictionary<string, string> ConnectionStringValues;
        protected Dictionary<string, string> GetConnectionStringValues()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string[] items = ConnectionString.Split(";".ToCharArray());

            foreach (string item in items)
            {
                int splitter = item.IndexOf("=");
                if (splitter > -1)
                {
                    values.Add(item.Substring(0, splitter).ToLower(), item.Substring(splitter + 1));
                }
            }
            return values;
        }


        protected string MasterConnectionString
        {
            get
            {
                string connString = string.Empty;
                foreach (KeyValuePair<string, string> item in ConnectionStringValues)
                {
                    if (item.Key == "database")
                        connString += item.Key + "=master;";
                    else
                        connString += item.Key + "=" + item.Value + ";";
                }
                return connString;
            }
        }

        public void WriteLine(string stringToWrite)
        {
            DBRampUpLogging.WriteLine(stringToWrite);
        }
        public void Write(string stringToWrite)
        {
            DBRampUpLogging.Write(stringToWrite);
        }

        #endregion Public Properties

        #region Module Event Handling

        protected void OnBuildTestData()
        {
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreBuildTestData, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventBuildTestData, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostBuildTestData, context);
        }

		private void OnExecuteSqlUpdate()
		{
			context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreExecuteUpdateSql, context);
			context.EventHub.ExecuteEvent(DBRampUpEventHub.EventExecuteUpdateSql, context);
			context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostExecuteUpdateSql, context);
		}

        protected void OnCustomSiteSettings()
        {
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreCustomSiteSettings, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventCustomSiteSettings, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostCustomSiteSettings, context);
        }

        protected void OnRestoreContent()
        {
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreRestoreContent, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventRestoreContent, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostRestoreContent, context);
        }



        protected void OnBuildDatabase()
        {
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreBuildDatabase, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventBuildDatabase, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostBuildDatabase, context);
        }

        protected void OnTearDownDB()
        {
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreTearDown, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventTearDown, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostTearDown, context);
        }

        protected void OnPreserveContent()
        {
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPrePreserveContent, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreserveContent, context);
            context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostPreserveContent, context);
        }

		protected void EventHub_BuildTestData(DBRampUpContext context)
        {
            BuildTestData();
        }
		
		protected void EventHub_UpdateSql(DBRampUpContext context)
		{
			UpdateSql();
		}

        protected void EventHub_CustomSiteSettings(DBRampUpContext context)
        {
            AddCustomSiteSettings();
        }

        protected void EventHub_RestoreContent(DBRampUpContext context)
        {
            RestoreContent();
        }

        protected void EventHub_BuildCustomDatabase(DBRampUpContext context)
        {

        }

        protected void EventHub_BuildDatabase(DBRampUpContext context)
        {
            BuildDatabase();
        }

        protected void EventHub_PreserveContent(DBRampUpContext context)
        {
            PreserveContent();
        }

        protected void EventHub_TearDown(DBRampUpContext context)
        {
            TearDownDatabase();
        }

        #endregion

        #region Module Loading

        internal List<IDBRampUpModule> LoadModules(DBRampUpContext context)
        {
            List<IDBRampUpModule> modules = new List<IDBRampUpModule>();

            try
            {

                DBRampUpModuleCollectionConfiguration moduleConfigs = DBRampUpConfiguration.Instance.Modules;
                foreach (DBRampUpModuleConfiguration mod in moduleConfigs)
                {
                    modules.Add(LoadModule(mod));
                }

            }
            catch (Exception ex)
            {
                WriteLine(String.Format("An exception of type {0} occurred while loading DBRampUpModules. The exception message is: {1}", ex.GetType().Name, ex.Message));
            }

            return modules;
        }

        internal IDBRampUpModule LoadModule(DBRampUpModuleConfiguration moduleConfig)
        {
            string typeName = null;

            IDBRampUpModule module = null;

            try
            {

                Type type = Type.GetType(moduleConfig.TypeName);

                if (type == null)
                {
                    WriteLine(String.Format("A DBRampUpModule could not be loaded. The type {0} does not exist", moduleConfig.TypeName));
                }
                else
                {
                    module = Activator.CreateInstance(type) as IDBRampUpModule;

                    if (module == null)
                    {
                        WriteLine(String.Format("A DBRampUpModule could not be loaded. The type {0} could not be instantiated", typeName));
                    }
                    else
                    {
                        // Initialize the extender
                        module.Initialize(context);
                    }
                }

            }
            catch (Exception ex)
            {
                WriteLine(String.Format("A DBRampUpModule could not be loaded. An exception of type {0} occurred: {1}", ex.GetType().Name, ex.Message));
            }

            // Return the result
            return module;
        }

        #endregion



        #region Virtual Setup Methods

        public virtual int Execute(SetupArgs args)
        {
            try
            {
                // Get the context
                context.SetupArgs = args;
                context.EventHub = new DBRampUpEventHub();

                // Be the first to attach events to the hub
                context.EventHub.PreserveContent += new DBRampUpEventHandler(EventHub_PreserveContent);
                context.EventHub.TearDown += new DBRampUpEventHandler(EventHub_TearDown);
                context.EventHub.BuildDatabase += new DBRampUpEventHandler(EventHub_BuildDatabase);
                context.EventHub.RestoreContent += new DBRampUpEventHandler(EventHub_RestoreContent);
                context.EventHub.CustomSiteSettings += new DBRampUpEventHandler(EventHub_CustomSiteSettings);
                context.EventHub.BuildTestData += new DBRampUpEventHandler(EventHub_BuildTestData);
				context.EventHub.UpdateSql += new DBRampUpEventHandler(EventHub_UpdateSql);

                // Update the logging state
                DBRampUpLogging.LogToFile = context.SetupArgs.Log;

                // Initialize the site builder provider
                Initialize();

				//Implement a IDBRampUpModule in any of your external assemblies to attach to DBRampUp execution events                

                // Find all the site builder extenders and intialize them
                List<IDBRampUpModule> modules = LoadModules(context);

				WriteLine("DBRampUp modules loaded and initialized");

                // Run the post initialize event
                context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPostInitialize, context);

                // See if we are to preserve content
                if (context.SetupArgs.PreserveContent)
                {
                    // Run the preserve content events
                    OnPreserveContent();
                    WriteLine("Content preserved");
                }

                // See if we are to tear down the database
                if (context.SetupArgs.TearDownDB)
                {
                    OnTearDownDB();
                    WriteLine("Database torn down");
                }

                // See if we are to build the database
                if (context.SetupArgs.BuildDB)
                {
                    OnBuildDatabase();
                    WriteLine("Database built");
                }


                if (context.SetupArgs.PreserveContent)
                {
                    OnRestoreContent();
                    WriteLine("Content restored");
                }

                if (context.SetupArgs.CustomSettings)
                {
                    OnCustomSiteSettings();
                    WriteLine("Custom site settings added.");
                }

                if (context.SetupArgs.Test)
                {
                    OnBuildTestData();
                    WriteLine("Test data built.");
                }

				OnExecuteSqlUpdate();

                // Execute the pre-finalize event
                context.EventHub.ExecuteEvent(DBRampUpEventHub.EventPreFinalize, context);

                // Finalize all modules
                foreach (IDBRampUpModule module in modules)
                {
                    module.Finalize(context);
                }

				WriteLine("DBRampUp finalized");
            }
            catch (Exception ex)
            {
                WriteLine(ex.ToString());
				return 1;
            }
            finally
            {
                CleanUp();
            }

			return 0;
        }

		


        /// <summary>
        /// Initializes provider
        /// </summary>
        protected virtual void Initialize()
        {
        }

        /// <summary>
        /// Preserves content parts
        /// </summary>
        protected virtual void PreserveContent()
        {

        }

        /// <summary>
        /// Add any users, sections, roles, etc that are required to get your site running here.
        /// </summary>
        protected virtual void AddCustomSiteSettings()
        {
        }



        public string FullSqlPath
        {
            get
            {
                return Path.Combine(ProjectPath, SqlPath);
            }
        }

		public string FullSchemaSqlPath
		{
			get
			{
				return Path.Combine(ProjectPath, this.SchemaSqlPath);
			}
		}
        /// <summary>
        /// Runs database install scripts.  Default behavior runs all sql files in the folder
        /// </summary>
        protected virtual void BuildDatabase()
        {
            ExecuteFilesInFolder(FullSqlPath);
        }

		protected virtual void UpdateSql()
		{
			if (false == String.IsNullOrEmpty(this.SchemaSqlPath))
				ExecuteFilesInFolder(FullSchemaSqlPath);
		}

        /// <summary>
        /// Put code here to get rid of the existing DB.  Default behavior is to drop all objects.
        /// </summary>
        public virtual void TearDownDatabase()
        {
            try
            {

                ExecSqlString(dropAllObjectsScript, ConnectionString);
            }
            catch (Exception ex)
            {
                WriteLine("Error in teardown.  Error was:" + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// Build any test data you might want
        /// </summary>
        protected virtual void BuildTestData() { }

        /// <summary>
        /// Adds Content Parts in the contentParts IList to the new DB
        /// </summary>
        protected virtual void RestoreContent()
        {

        }

        /// <summary>
        /// Writes log file.  Place any other clean up steps here.
        /// </summary>
        protected virtual void CleanUp()
        {
            DBRampUpLogging.CloseLog();
        }

        #endregion

        #region Member variables
        protected string databaseOwner = "dbo";	// overwrite in web.config
        string connectionString = null;

        #endregion

        #region Instance

        private static DBRampUpProvider _defaultInstance = null;

        static DBRampUpProvider()
        {
            CreateDefaultSetupProvider();
        }
        /// <summary>
        /// Returns an instance of the user-specified data provider class.
        /// </summary>
        /// <returns>An instance of the user-specified data provider class.</returns>
        public static DBRampUpProvider Instance()
        {
            return _defaultInstance;
        }

        


        /// <summary>
        /// Creates the Default SiteSetupProvider
        /// </summary>
        private static void CreateDefaultSetupProvider()
        {
           ConnectionStringSettingsCollection strings =   WebConfigurationManager.ConnectionStrings;
		   var data = strings[DBRampUpConfiguration.Instance.DefaultConnectionStringName];
		   if (data == null) throw new ApplicationException("Could not find connection string named: " + DBRampUpConfiguration.Instance.DefaultConnectionStringName);
           string connStr = data.ConnectionString;


            _defaultInstance = new DBRampUpProvider(connStr);
        }

        #endregion

        #region Constructor
       

        /****************************************************************
        // SqlDataProvider
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //
        ****************************************************************/
        public DBRampUpProvider( string connectionString)
        {
            // Read the connection string for this provider
            //
            this.connectionString = connectionString;

           
            DBRampUpLogging.LogFileName = string.Format("setup_{0:MMddyy_HHmm}.log", DateTime.Now);
        }

       

        #endregion


        #region Provider Helpers
        protected SqlConnection GetSqlConnection()
        {

            try
            {
                return new SqlConnection(ConnectionString);
            }
            catch
            {
                throw new Exception("SQL Connection String is invalid.");
            }

        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
        #endregion

        #region Exec SQL

        protected void ExecSqlString(string sql, string connString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandTimeout = CommandTimeout;
                    connection.Open();

                    // Change to the user selected database
                    //

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;


                    command.CommandText = sql;

                    command.ExecuteNonQuery();

                }

            }

            catch (Exception ex)
            {
                WriteLine(string.Format("ExecSqlString:{0}", "Message:" + ex.Message));
                throw ex;
            }
        }

        public void ExecuteFilesInFolder(string path)
        {
            string[] files = Directory.GetFiles(path, "*.sql");

            foreach (string fileName in files)
            {
                WriteLine("Executing " + Path.GetFileName(fileName));
                ExecuteSqlInFile(fileName);
            }
        }

        /// <summary>
        /// Executes all sql statements in the given file
        /// </summary>
        /// <param name="pathToScriptFile"></param>
        /// <returns></returns>
        public bool ExecuteSqlInFile(string pathToScriptFile)
        {


            try
            {
                StreamReader _reader = null;

                string sql = "";

                if (false == System.IO.File.Exists(pathToScriptFile))
                {
                    throw new Exception("File " + pathToScriptFile + " does not exists");
                }
                using (Stream stream = System.IO.File.OpenRead(pathToScriptFile))
                {
                    _reader = new StreamReader(stream);

                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {

                        SqlCommand command = new SqlCommand();
                        command.CommandTimeout = CommandTimeout;
                        connection.Open();

                        // Change to the user selected database
                        //

                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;

                        while (null != (sql = ReadNextStatementFromStream(_reader)))
                        {
                            command.CommandText = sql;

                            command.ExecuteNonQuery();
                        }

                        _reader.Close();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                WriteLine(string.Format("ExecuteSqlInFile:{0}", "Error in file:" + pathToScriptFile + Environment.NewLine + "Message:" + ex.Message));
                throw ex;
            }


        }

        private static string ReadNextStatementFromStream(StreamReader _reader)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                string lineOfText;

                while (true)
                {
                    lineOfText = _reader.ReadLine();
                    if (lineOfText == null)
                    {

                        if (sb.Length > 0)
                        {
                            return sb.ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }

                    if (lineOfText.TrimEnd().ToUpper() == "GO")
                    {
                        break;
                    }

                    sb.Append(lineOfText + Environment.NewLine);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ReadNextStatementFromStream", ex.InnerException);
            }
        }

        #endregion Exec SQL


    }
}
