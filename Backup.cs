using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static LittleWebApplication.ProfilData;

namespace LittleWebApplication
{
    public class Backup
    {
        public static List<string> StringListRepository(List<string> stringList, XmlSerializer serializer, string path)
        {
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, stringList);
            }

            using (FileStream file = File.OpenRead(path))
            {
                stringList = serializer.Deserialize(file) as List<string>;
            }
            return stringList;
        }
        public static List<AccountInformations> ObjectListRepository(List<AccountInformations> objectList, XmlSerializer serializer, string path)
        {
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, objectList);
            }

            using (FileStream file = File.OpenRead(path))
            {
                objectList = serializer.Deserialize(file) as List<AccountInformations>;
            }
            return objectList;
        }
    }
}
