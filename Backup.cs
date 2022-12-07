using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class Backup
    {
        public static List<string> stringListRepository(List<string> stringList, XmlSerializer serializer, string path)
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

        public static List<int> intListRepository(List<int> intList, XmlSerializer serializer, string path)
        {
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, intList);
            }

            using (FileStream file = File.OpenRead(path))
            {
                intList = serializer.Deserialize(file) as List<int>;
            }
            return intList;
        }
    }
}
