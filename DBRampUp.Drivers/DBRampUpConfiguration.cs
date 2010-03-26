using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DBRampUp
{
    public class DBRampUpConfiguration : ConfigurationSection
    {
        public static DBRampUpConfiguration Instance
        {
            get
            {
                DBRampUpConfiguration config = (DBRampUpConfiguration)
                  System.Configuration.ConfigurationManager.GetSection("dbRampUp");

				if (config == null) throw new ApplicationException("Could not find config section named: dbRampUp in the configuration file.");

                return config;
            }
        }

        [ConfigurationProperty("defaultConnectionStringName", DefaultValue = "", IsRequired = true)]
        public string DefaultConnectionStringName
        {
            get
            {
                return (string)this["defaultConnectionStringName"];
            }
            set
            {
                this["defaultConnectionStringName"] = value;
            }
        }

        [ConfigurationProperty("modules")]
        public DBRampUpModuleCollectionConfiguration Modules
        {
            get
            {
                return this["modules"] as DBRampUpModuleCollectionConfiguration;
            }
        }

    }


    public class DBRampUpModuleCollectionConfiguration : ConfigurationElementCollection
    {

        public DBRampUpModuleConfiguration this[int index]
        {
            get
            {
                return base.BaseGet(index) as DBRampUpModuleConfiguration;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public DBRampUpModuleConfiguration this[string name]
        {
            get
            {
                return base.BaseGet(name) as DBRampUpModuleConfiguration;
            }
            set
            {
                int index = -1;
                if (base.BaseGet(name) != null)
                {
                    index = base.BaseIndexOf(base.BaseGet(name));
                    base.BaseRemove(name);
                }

                if (index == -1)
                {
                    this.BaseAdd(value);
                }
                else
                {
                    this.BaseAdd(index, value);
                }
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DBRampUpModuleConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DBRampUpModuleConfiguration)element).Name;
        }

    }



    public class DBRampUpModuleConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("name", DefaultValue = "", IsRequired = true, IsKey=true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("type", DefaultValue = "", IsRequired = true)]
        public string TypeName
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        [ConfigurationProperty("settings", DefaultValue = "", IsRequired = false)]
        public string Settings
        {
            get
            {
                return (string)this["settings"];
            }
            set
            {
                this["settings"] = value;
            }
        }



    }
    
}
