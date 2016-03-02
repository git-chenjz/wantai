using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace MyFrameWork.Common.Email
{
    public class EmailCore
    {
        public static MessageEmailConfig GetConfig()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string fileName = Path.Combine(path, "Email.config");

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MessageEmailConfig));
                return (MessageEmailConfig)serializer.Deserialize(stream);
            }
        }
    }
}
