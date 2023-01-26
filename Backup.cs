using LittleWebApplication.Users;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class Backup
    {
        static XmlSerializer accountSerializer = new XmlSerializer(typeof(List<Account>));
        //static string ACCOUNT_PATH = "accountRepository.xml";
        //static string ACCOUNT_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\accountRepository.xml";
        static string ACCOUNT_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\accountRepository.xml";
        static XmlSerializer privateUserSerializer = new(typeof(List<User>));
        //static string PRIVATE_USER_PATH = "privateUserRepository.xml";
        //static string PRIVATE_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\privateUserList.xml";
        static string PRIVATE_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\privateUserRepository.xml";
        static XmlSerializer businessUserSerializer = new(typeof(List<User>));
        //static string BUSINESS_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\businessUserList.xml";
        static string BUSINESS_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\pusinessUserRepository.xml";
        static XmlSerializer serviceUserSerializer = new(typeof(List<User>));
        //static string SERVICE_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\serviceUserList.xml";
        static string SERVICE_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\serviceUserRepository.xml";
        static XmlSerializer adminUserSerializer = new(typeof(List<User>));
        //static string ADMIN_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\adminUserList.xml";
        static string ADMIN_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\adminUserRepository.xml";
        static XmlSerializer terminalSerializer = new(typeof(List<Terminal>));
        //static string TERMINAL_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\terminalList.xml";
        static string TERMINAL_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\terminalRepository.xml";
        static XmlSerializer fundraiserSerializer = new(typeof(List<Fundraiser>));
        //static string FUNDRAISER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\fundraiserRepository.xml";
        static string FUNDRAISER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\fundraiserRepositoryRepository.xml";


        public static void StoreAccountRepository(List<Account> accounts)
        {
            using (FileStream file = File.Create(ACCOUNT_PATH))
            {
                accountSerializer.Serialize(file, accounts);
            }
        }

        public static List<Account> LoadAccountRepository()
        {
            List<Account> accounts = new();
            bool backUpCheck = File.Exists(ACCOUNT_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(ACCOUNT_PATH))
                {
                    accounts = accountSerializer.Deserialize(file) as List<Account>;
                }
            }
            else
            {
                StoreAccountRepository(accounts);
            }
            return accounts;
        }

        public static void StorePrivateUserRepository(List<User> users)
        {
            using (FileStream file = File.Create(PRIVATE_USER_PATH))
            {
                privateUserSerializer.Serialize(file, users);
            }
        }

        public static List<User> LoadPrivateUserRepository()
        {
            List<User> users = new();
            bool backUpCheck = File.Exists(PRIVATE_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(PRIVATE_USER_PATH))
                {
                    users = privateUserSerializer.Deserialize(file) as List<User>;
                }
            }
            else
            {
                StorePrivateUserRepository(users);
            }
            return users;
        }

        public static void StoreBusinessUserRepository(List<User> users)
        {
            using (FileStream file = File.Create(BUSINESS_USER_PATH))
            {
                privateUserSerializer.Serialize(file, users);
            }
        }

        public static List<User> LoadBusinessUserRepository()
        {
            List<User> users = new();
            bool backUpCheck = File.Exists(BUSINESS_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(BUSINESS_USER_PATH))
                {
                    users = businessUserSerializer.Deserialize(file) as List<User>;
                }
            }
            else
            {
                StoreBusinessUserRepository(users);
            }
            return users;
        }

        public static void StoreServiceUserRepository(List<User> users)
        {
            using (FileStream file = File.Create(SERVICE_USER_PATH))
            {
                serviceUserSerializer.Serialize(file, users);
            }
        }

        public static List<User> LoadServiceUserRepository()
        {
            List<User> users = new();
            bool backUpCheck = File.Exists(SERVICE_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(SERVICE_USER_PATH))
                {
                    users = serviceUserSerializer.Deserialize(file) as List<User>;
                }
            }
            else
            {
                StoreServiceUserRepository(users);
            }
            return users;
        }

        public static void StoreAdminUserRepository(List<User> users)
        {
            using (FileStream file = File.Create(ADMIN_USER_PATH))
            {
                adminUserSerializer.Serialize(file, users);
            }
        }

        public static List<User> LoadAdminUserRepository()
        {
            List<User> users = new();
            bool backUpCheck = File.Exists(ADMIN_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(ADMIN_USER_PATH))
                {
                    users = adminUserSerializer.Deserialize(file) as List<User>;
                }
            }
            else
            {
                StoreAdminUserRepository(users);
            }
            return users;
        }

        public static void StoreTerminalRepository(List<Terminal> terminals)
        {
            using (FileStream file = File.Create(TERMINAL_PATH))
            {
                accountSerializer.Serialize(file, terminals);
            }
        }

        public static List<Terminal> LoadTerminalRepository()
        {
            List<Terminal> terminals = new();
            bool backUpCheck = File.Exists(TERMINAL_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(TERMINAL_PATH))
                {
                    terminals = terminalSerializer.Deserialize(file) as List<Terminal>;
                }
            }
            else
            {
                StoreTerminalRepository(terminals);
            }
            return terminals;
        }
        public static void StoreFundraiserRepository(List<Fundraiser> fundraisers)
        {
            using (FileStream file = File.Create(FUNDRAISER_PATH))
            {
                fundraiserSerializer.Serialize(file, fundraisers);
            }
        }

        public static List<Fundraiser> LoadFundraiserRepository()
        {
            List<Fundraiser> fundraisers = new();
            bool backUpCheck = File.Exists(FUNDRAISER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(FUNDRAISER_PATH))
                {
                    fundraisers = fundraiserSerializer.Deserialize(file) as List<Fundraiser>;
                }
            }
            else
            {
                StoreFundraiserRepository(fundraisers);
            }
            return fundraisers;
        }

    }
}
