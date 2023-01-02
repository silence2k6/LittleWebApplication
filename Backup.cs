using LittleWebApplication.Accounts;
using LittleWebApplication.Users;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class Backup
    {
        static XmlSerializer accountSerializer = new XmlSerializer(typeof(List<AccountInformations>));
        static string ACC_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\accountRepository.xml";
        static XmlSerializer userSerializer = new(typeof(List<CreateUser>));
        static string USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\privatUserList.xml";

        public static void StoreAccountRepository(List<AccountInformations> accounts)
        {
            using (FileStream file = File.Create(ACC_PATH))
            {
                accountSerializer.Serialize(file, accounts);
            }
        }

        public static List<AccountInformations> LoadAccountRepository()
        {
            List<AccountInformations> accounts = new();
            bool backUpCheck = File.Exists(ACC_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(ACC_PATH))
                {
                    accounts = accountSerializer.Deserialize(file) as List<AccountInformations>;
                }
            }
            else
            {
                StoreAccountRepository(accounts);
            }
            return accounts;
        }

        public static void StoreUserRepository(List<CreateUser> users)
        {
            using (FileStream file = File.Create(USER_PATH))
            {
                userSerializer.Serialize(file, users);
            }
        }

        public static List<CreateUser> LoadUserRepository()
        {
            List<CreateUser> users = new();
            bool backUpCheck = File.Exists(USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(USER_PATH))
                {
                    users = userSerializer.Deserialize(file) as List<CreateUser>;
                }
            }
            else
            {
                StoreUserRepository(users);
            }
            return users;
        }
    }
}
