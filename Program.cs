using LittleWebApplication.Accounts;
using LittleWebApplication.Users;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    internal class Progamm
    {
        static void Main(string[] args)
        {
            List<AccountInformations> accountList = Backup.LoadAccountRepository();
            List<CreateUser> privatUserList = Backup.LoadUserRepository();

            int accountNumber = CreateUser.CreateAccountNumber(accountList);
            string userNumber = CreateUser.CreateUserNumber(Enums.UserType.privatUser, accountNumber);
            DateTime datetime = DateTime.Now;

            AccountInformations newAccount = AccountInformations.CreateAccount(accountNumber, Enums.UserType.privatUser, datetime);
            accountList.Add(newAccount);

            CreateUser newUser = CreateUser.CreatePrivatUserDummy(userNumber);
            privatUserList.Add(newUser);

            Backup.StoreAccountRepository(accountList);
            Backup.StoreUserRepository(privatUserList);

            Console.WriteLine(privatUserList);
        }
    }
}