using LittleWebApplication.Accounts;
using LittleWebApplication.Terminal;
using LittleWebApplication.Users;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class Backup
    {
        static XmlSerializer accountSerializer = new XmlSerializer(typeof(List<AccountInformations>));
        static string ACCOUNT_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\accountRepository.xml";
        static XmlSerializer privateUserSerializer = new(typeof(List<CreateUser>));
        static string PRIVATE_USER_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\privateUserList.xml";
        static XmlSerializer terminalSerializer = new(typeof(List<CreateTerminal>));
        static string TERMINAL_PATH = @"C:\Users\user\source\repos\LittleWebApplication\Backup\terminalList.xml";

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
    }
}
