using System;
using System.Configuration;

namespace InsaneJourney.XmlFileRepository
{
    public class XmlFileRepositoryConfigSection : ConfigurationSection
    {
        private static XmlFileRepositoryConfigSection _config;

        [ConfigurationProperty("useAbsolutePath", DefaultValue = "true", IsRequired = true)]
        public Boolean UseAbsolutePath
        {
            get
            {
                return (Boolean)this["useAbsolutePath"];
            }
            set
            {
                this["useAbsolutePath"] = value;
            }
        }

        [ConfigurationProperty("xsdSchemaDirectoryPath", IsRequired = false)]
        
        public String XsdSchemaDirectoryPath
        {
            get
            {
                return (String)this["xsdSchemaDirectoryPath"];
            }
            set
            {
                this["xsdSchemaDirectoryPath"] = value;
            }
        }

        [ConfigurationProperty("xmlDataDirectoryPath", IsRequired = false)]
        
        public String XmlDataDirectoryPath
        {
            get
            {
                return (String)this["xmlDataDirectoryPath"];
            }
            set
            {
                this["xmlDataDirectoryPath"] = value;
            }
        }

        [ConfigurationProperty("xsdSchemaFileName", IsRequired = true)]
        public String XsdSchemaFileName
        {
            get
            {
                return (String)this["xsdSchemaFileName"];
            }
            set
            {
                this["xsdSchemaFileName"] = value;
            }
        }

        [ConfigurationProperty("xmlDataFileName", IsRequired = true)]
        public String XmlDataFileName
        {
            get
            {
                return (String)this["xmlDataFileName"];
            }
            set
            {
                this["xmlDataFileName"] = value;
            }
        }

        public static XmlFileRepositoryConfigSection Configuration
        {
            get {
                return _config ??
                       (_config =
                        ConfigurationManager.GetSection("xmlFileRepositoryGroup/xmlFileRepository") as XmlFileRepositoryConfigSection);
            }
        }

        public static string SchemaPath
        {
            get
            {
               return Configuration.UseAbsolutePath
                                ? _config.XsdSchemaDirectoryPath + _config.XsdSchemaFileName
                                : ExecutingAssemblyDirectory+_config.XsdSchemaFileName;
            }
        }
        public static string XmlDataPath
        {
            get
            {
                return Configuration.UseAbsolutePath
                              ? _config.XmlDataDirectoryPath + _config.XmlDataFileName
                              : ExecutingAssemblyDirectory + _config.XmlDataFileName;
            }
        }

        public static string ExecutingAssemblyDirectory
        {
            get
            {
                return  System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
            }
        }
        

    }
}