using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using InsaneJourney.XmlFileRepository.Interfaces;

namespace InsaneJourney.XmlFileRepository
{
    internal class Deserializer <T> : IDeserializer<T> where T : class, new() 
    {
        private readonly string _rootElementName;
        private readonly string _schemaPath;
        private readonly string _xmlFilePath;

        public Deserializer(string rootElementName, string schemaPath, string xmlFilePath)
        {
            _rootElementName = rootElementName;
            _schemaPath = schemaPath;
            _xmlFilePath = xmlFilePath;
        }

        public T Deserialize()
        {
            using (var xmlStream = new StreamReader(_xmlFilePath))
            {
                using (var xmlReader = XmlReader.Create(xmlStream, XmlReaderSettings))
                {
                    return (T)XmlSerializer.Deserialize(xmlReader);
                }
            }
        }

        private XmlSerializer XmlSerializer
        {
            get
            {
                return
                    new XmlSerializer(typeof (T), new XmlRootAttribute(_rootElementName));
            }
        }

        private XmlReaderSettings XmlReaderSettings
        {
            get
            {
                var xmlReaderSettings = new XmlReaderSettings();
                xmlReaderSettings.Schemas.Add(null, _schemaPath);
                xmlReaderSettings.ValidationType = ValidationType.Schema;
                xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                xmlReaderSettings.ValidationEventHandler += ValidationEvent;
                return xmlReaderSettings;
            }
        }

        private void ValidationEvent(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Error)
                throw args.Exception;
        }
    }
}
