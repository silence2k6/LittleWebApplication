using LittleWebApplication.Accounts;
using LittleWebApplication.Terminal;
using LittleWebApplication.Users;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class Backup
    {
        static XmlSerializer accountSerializer = new XmlSerializer(typeof(List<AccountInformations>));
        //static string ACCOUNT_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\accountRepository.xml";
        static string ACCOUNT_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\accountRepository.xml";
        static XmlSerializer privateUserSerializer = new(typeof(List<CreateUser>));
        //static string PRIVATE_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\privateUserList.xml";
        static string PRIVATE_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\privateUserRepository.xml";
        static XmlSerializer businessUserSerializer = new(typeof(List<CreateUser>));
        //static string BUSINESS_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\businessUserList.xml";
        static string BUSINESS_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\pusinessUserRepository.xml";
        static XmlSerializer serviceUserSerializer = new(typeof(List<CreateUser>));
        //static string SERVICE_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\serviceUserList.xml";
        static string SERVICE_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\serviceUserRepository.xml";
        static XmlSerializer adminUserSerializer = new(typeof(List<CreateUser>));
        //static string ADMIN_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\adminUserList.xml";
        static string ADMIN_USER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\adminUserRepository.xml";
        static XmlSerializer terminalSerializer = new(typeof(List<CreateTerminal>));
        //static string TERMINAL_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\terminalList.xml";
        static string TERMINAL_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\terminalRepository.xml";
        static XmlSerializer fundraiserSerializer = new(typeof(List<Fundraiser>));
        //static string FUNDRAISER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\fundraiserRepository.xml";
        static string FUNDRAISER_PATH = @"C:\Users\Bimbi\source\repos\silence2k6\LittleWebApplication\Backup\fundraiserRepositoryRepository.xml";


        public static void StoreAccountRepository(List<AccountInformations> accounts)
        {
            using (FileStream file = File.Create(ACCOUNT_PATH))
            {
                accountSerializer.Serialize(file, accounts);
            }
        }

        public static List<AccountInformations> LoadAccountRepository()
        {
            List<AccountInformations> accounts = new();
            bool backUpCheck = File.Exists(ACCOUNT_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(ACCOUNT_PATH))
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

        public static void StorePrivateUserRepository(List<CreateUser> users)
        {
            using (FileStream file = File.Create(PRIVATE_USER_PATH))
            {
                privateUserSerializer.Serialize(file, users);
            }
        }

        public static List<CreateUser> LoadPrivateUserRepository()
        {
            List<CreateUser> users = new();
            bool backUpCheck = File.Exists(PRIVATE_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(PRIVATE_USER_PATH))
                {
                    users = privateUserSerializer.Deserialize(file) as List<CreateUser>;
                }
            }
            else
            {
                StorePrivateUserRepository(users);
            }
            return users;
        }

        public static void StoreBusinessUserRepository(List<CreateUser> users)
        {
            using (FileStream file = File.Create(BUSINESS_USER_PATH))
            {
                privateUserSerializer.Serialize(file, users);
            }
        }

        public static List<CreateUser> LoadBusinessUserRepository()
        {
            List<CreateUser> users = new();
            bool backUpCheck = File.Exists(BUSINESS_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(BUSINESS_USER_PATH))
                {
                    users = businessUserSerializer.Deserialize(file) as List<CreateUser>;
                }
            }
            else
            {
                StoreBusinessUserRepository(users);
            }
            return users;
        }

        public static void StoreServiceUserRepository(List<CreateUser> users)
        {
            using (FileStream file = File.Create(SERVICE_USER_PATH))
            {
                serviceUserSerializer.Serialize(file, users);
            }
        }

        public static List<CreateUser> LoadServiceUserRepository()
        {
            List<CreateUser> users = new();
            bool backUpCheck = File.Exists(SERVICE_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(SERVICE_USER_PATH))
                {
                    users = serviceUserSerializer.Deserialize(file) as List<CreateUser>;
                }
            }
            else
            {
                StoreServiceUserRepository(users);
            }
            return users;
        }

        public static void StoreAdminUserRepository(List<CreateUser> users)
        {
            using (FileStream file = File.Create(ADMIN_USER_PATH))
            {
                adminUserSerializer.Serialize(file, users);
            }
        }

        public static List<CreateUser> LoadAdminUserRepository()
        {
            List<CreateUser> users = new();
            bool backUpCheck = File.Exists(ADMIN_USER_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(ADMIN_USER_PATH))
                {
                    users = adminUserSerializer.Deserialize(file) as List<CreateUser>;
                }
            }
            else
            {
                StoreAdminUserRepository(users);
            }
            return users;
        }

        public static void StoreTerminalRepository(List<CreateTerminal> terminals)
        {
            using (FileStream file = File.Create(TERMINAL_PATH))
            {
                accountSerializer.Serialize(file, terminals);
            }
        }

        public static List<CreateTerminal> LoadTerminalRepository()
        {
            List<CreateTerminal> terminals = new();
            bool backUpCheck = File.Exists(TERMINAL_PATH);

            if (backUpCheck == true)
            {
                using (FileStream file = File.OpenRead(TERMINAL_PATH))
                {
                    terminals = terminalSerializer.Deserialize(file) as List<CreateTerminal>;
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
