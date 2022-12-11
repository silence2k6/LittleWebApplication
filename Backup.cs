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
        public static List<AccountInformations> AccountListRepository(List<AccountInformations> accountList, XmlSerializer serializer, string path)
        {
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, accountList);
            }

            using (FileStream file = File.OpenRead(path))
            {
                accountList = serializer.Deserialize(file) as List<AccountInformations>;
            }
            return accountList;
        }

        public static List<ProfilData> PrivatUserRepository(List<ProfilData> privatUserList, XmlSerializer serializer, string path)
        {
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, privatUserList);
            }

            using (FileStream file = File.OpenRead(path))
            {
                privatUserList = serializer.Deserialize(file) as List<ProfilData>;
            }
            return privatUserList;
        }
    }
}
