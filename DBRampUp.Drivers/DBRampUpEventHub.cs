using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace DBRampUp
{
    #region Delegates

    public delegate void DBRampUpEventHandler(DBRampUpContext context);

    #endregion

    public class DBRampUpEventHub
    {
        #region Private Members

        private readonly EventHandlerList _events = new EventHandlerList();

        #endregion

        #region Events

        /// <summary>
        /// Fired after initialize
        /// </summary>
        internal static readonly object EventPostInitialize = new object();

        /// <summary>
        /// Fired before the preserve content event
        /// </summary>
        internal static readonly object EventPrePreserveContent = new object();

        /// <summary>
        /// The preserve content event
        /// </summary>
        internal static readonly object EventPreserveContent = new object();

        /// <summary>
        /// Fired after preserve content event
        /// </summary>
        internal static readonly object EventPostPreserveContent = new object();

        /// <summary>
        /// Fired before tear down event
        /// </summary>
        internal static readonly object EventPreTearDown = new object();

        /// <summary>
        /// The tear down event
        /// </summary>
        internal static readonly object EventTearDown = new object();

        /// <summary>
        /// Fired after the tear down event
        /// </summary>
        internal static readonly object EventPostTearDown = new object();

        /// <summary>
        /// Fired before the Build Database event
        /// </summary>
        internal static readonly object EventPreBuildDatabase = new object();

        /// <summary>
        /// The Build Database event
        /// </summary>
        internal static readonly object EventBuildDatabase = new object();

        /// <summary>
        /// Fired after the build Database event
        /// </summary>
        internal static readonly object EventPostBuildDatabase = new object();

        

        /// <summary>
        /// Fired before the restore content event
        /// </summary>
        internal static readonly object EventPreRestoreContent = new object();

        /// <summary>
        /// The restore content event
        /// </summary>
        internal static readonly object EventRestoreContent = new object();

        /// <summary>
        /// Fired after the restore content event
        /// </summary>
        internal static readonly object EventPostRestoreContent = new object();

        /// <summary>
        /// Fired before custom site settings
        /// </summary>
        internal static readonly object EventPreCustomSiteSettings = new object();

        /// <summary>
        /// Custom site settings event
        /// </summary>
        internal static readonly object EventCustomSiteSettings = new object();

        /// <summary>
        /// Fired after custom site settings
        /// </summary>
        internal static readonly object EventPostCustomSiteSettings = new object();

        /// <summary>
        /// Fired before build test data
        /// </summary>
        internal static readonly object EventPreBuildTestData = new object();

        /// <summary>
        /// Build test data event
        /// </summary>
        internal static readonly object EventBuildTestData = new object();

        /// <summary>
        /// Fired after build test data
        /// </summary>
        internal static readonly object EventPostBuildTestData = new object();

        /// <summary>
        /// Fired before finalize
        /// </summary>
        internal static readonly object EventPreFinalize = new object();

        #endregion

        #region EventHandlers

        /// <summary>
        /// Event raised after initialized
        /// </summary>
        public event DBRampUpEventHandler PostInitialize
        {
            add { _events.AddHandler(EventPostInitialize, value); }
            remove { _events.RemoveHandler(EventPostInitialize, value); }
        }

        /// <summary>
        /// Event raised before preserve content
        /// </summary>
        public event DBRampUpEventHandler PrePreserveContent
        {
            add { _events.AddHandler(EventPrePreserveContent, value); }
            remove { _events.RemoveHandler(EventPrePreserveContent, value); }
        }

        /// <summary>
        /// Event raised to preserve content
        /// </summary>
        public event DBRampUpEventHandler PreserveContent
        {
            add { _events.AddHandler(EventPreserveContent, value); }
            remove { _events.RemoveHandler(EventPreserveContent, value); }
        }

        /// <summary>
        /// Event raised after preserve content
        /// </summary>
        public event DBRampUpEventHandler PostPreserveContent
        {
            add { _events.AddHandler(EventPostPreserveContent, value); }
            remove { _events.RemoveHandler(EventPostPreserveContent, value); }
        }

        /// <summary>
        /// Event raised before database tear down
        /// </summary>
        public event DBRampUpEventHandler PreTearDown
        {
            add { _events.AddHandler(EventPreTearDown, value); }
            remove { _events.RemoveHandler(EventPreTearDown, value); }
        }

        /// <summary>
        /// Event to tear down the database
        /// </summary>
        public event DBRampUpEventHandler TearDown
        {
            add { _events.AddHandler(EventPostTearDown, value); }
            remove { _events.RemoveHandler(EventPostTearDown, value); }
        }

        /// <summary>
        /// Event after database tear down
        /// </summary>
        public event DBRampUpEventHandler PostTearDown
        {
            add { _events.AddHandler(EventPostTearDown, value); }
            remove { _events.RemoveHandler(EventPostTearDown, value); }
        }

        /// <summary>
        /// Event before database built
        /// </summary>
        public event DBRampUpEventHandler PreBuildDatabase
        {
            add { _events.AddHandler(EventPreBuildDatabase, value); }
            remove { _events.RemoveHandler(EventPreBuildDatabase, value); }
        }

        /// <summary>
        /// Event to build database
        /// </summary>
        public event DBRampUpEventHandler BuildDatabase
        {
            add { _events.AddHandler(EventBuildDatabase, value); }
            remove { _events.RemoveHandler(EventBuildDatabase, value); }
        }

        /// <summary>
        /// Event after build database
        /// </summary>
        public event DBRampUpEventHandler PostBuildDatabase
        {
            add { _events.AddHandler(EventPostBuildDatabase, value); }
            remove { _events.RemoveHandler(EventPostBuildDatabase, value); }
        }

       

        /// <summary>
        /// Event before restore content
        /// </summary>
        public event DBRampUpEventHandler PreRestoreContent
        {
            add { _events.AddHandler(EventPreRestoreContent, value); }
            remove { _events.RemoveHandler(EventPreRestoreContent, value); }
        }

        /// <summary>
        /// Event to restore content
        /// </summary>
        public event DBRampUpEventHandler RestoreContent
        {
            add { _events.AddHandler(EventRestoreContent, value); }
            remove { _events.RemoveHandler(EventRestoreContent, value); }
        }

        /// <summary>
        /// Event after restore content
        /// </summary>
        public event DBRampUpEventHandler PostRestoreContent
        {
            add { _events.AddHandler(EventPostRestoreContent, value); }
            remove { _events.RemoveHandler(EventPostRestoreContent, value); }
        }

        /// <summary>
        /// Event before custom site settings
        /// </summary>
        public event DBRampUpEventHandler PreCustomSiteSettings
        {
            add { _events.AddHandler(EventPreCustomSiteSettings, value); }
            remove { _events.RemoveHandler(EventPreCustomSiteSettings, value); }
        }

        /// <summary>
        /// Custom site settings event
        /// </summary>
        public event DBRampUpEventHandler CustomSiteSettings
        {
            add { _events.AddHandler(EventCustomSiteSettings, value); }
            remove { _events.RemoveHandler(EventCustomSiteSettings, value); }
        }

        /// <summary>
        /// Fired after custom site settings
        /// </summary>
        public event DBRampUpEventHandler PostCustomSiteSettings
        {
            add { _events.AddHandler(EventPostCustomSiteSettings, value); }
            remove { _events.RemoveHandler(EventPostCustomSiteSettings, value); }
        }

        /// <summary>
        /// Fired before build test data
        /// </summary>
        public event DBRampUpEventHandler PreBuildTestData
        {
            add { _events.AddHandler(EventPreBuildTestData, value); }
            remove { _events.RemoveHandler(EventPreBuildTestData, value); }
        }

        /// <summary>
        /// Build test data event
        /// </summary>
        public event DBRampUpEventHandler BuildTestData
        {
            add { _events.AddHandler(EventBuildTestData, value); }
            remove { _events.RemoveHandler(EventBuildTestData, value); }
        }

        /// <summary>
        /// Fired after build test data event
        /// </summary>
        public event DBRampUpEventHandler PostBuildTestData
        {
            add { _events.AddHandler(EventPostBuildTestData, value); }
            remove { _events.RemoveHandler(EventPostBuildTestData, value); }
        }

        /// <summary>
        /// Event before finalize
        /// </summary>
        public event DBRampUpEventHandler PreFinalize
        {
            add { _events.AddHandler(EventPreFinalize, value); }
            remove { _events.RemoveHandler(EventPreFinalize, value); }
        }

        #endregion

        #region Execution

        internal virtual void ExecuteEvent(object EventKey, DBRampUpContext context)
        {
            DBRampUpEventHandler handler = _events[EventKey] as DBRampUpEventHandler;

            if (handler != null)
            {
                handler(context);
            }
        }

        #endregion
    }
}
