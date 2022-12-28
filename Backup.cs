using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LittleWebApplication.Accounts;
using LittleWebApplication.Users;

namespace LittleWebApplication
{
    public class Backup
    {
        public static List<AccountInformations> AccountListRepository(List<AccountInformations> accountList, XmlSerializer accountSerializer, string accountRepositoryPath)
        {
            using (FileStream file = File.Create(accountRepositoryPath))
            {
                accountSerializer.Serialize(file, accountList);
            }

            using (FileStream file = File.OpenRead(accountRepositoryPath))
            {
                accountList = accountSerializer.Deserialize(file) as List<AccountInformations>;
            }
            return accountList;
        }

        public static List<CreateUser> PrivatUserRepository(List<CreateUser> privatUserList, XmlSerializer userSerializer, string userRepositoryPath)
        {
            using (FileStream file = File.Create(userRepositoryPath))
            {
                userSerializer.Serialize(file, privatUserList);
            }

            using (FileStream file = File.OpenRead(userRepositoryPath))
            {
                privatUserList = userSerializer.Deserialize(file) as List<CreateUser>;
            }
            return privatUserList;
        }
    }
}
