using LittleWebApplication.Accounts;
using LittleWebApplication.Terminal;
using LittleWebApplication.Users;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    internal class Progamm
    {
        static void Main(string[] args)
        {
            List<AccountInformations> accountList = Backup.LoadAccountRepository();
            List<CreateUser> privateUserList = Backup.LoadPrivateUserRepository();
            //List<CreateTerminal> terminalList = 

            int accountNumber = CreateUser.CreateAccountNumber(accountList);
            string userNumber = CreateUser.CreateUserNumber(Enums.UserType.privateUser, accountNumber);
            DateTime datetime = DateTime.Now;

            AccountInformations newAccount = AccountInformations.CreateAccount(accountNumber, Enums.UserType.privateUser, datetime);
            accountList.Add(newAccount);

            CreateUser newUser = CreateUser.CreatePrivateUserDummy(accountNumber);
            privateUserList.Add(newUser);

            Backup.StoreAccountRepository(accountList);
            Backup.StorePrivateUserRepository(privateUserList);

            bool validUserNumberInput = true;
            List<CreateUser> userList = new();

            while (validUserNumberInput == true)
            {
                string userLoginNumberInput = UImethods.AskForUserLoginNumber();
                Enums.UserType artOfUser = UImethods.CheckUserLoginForArtOfUser(userLoginNumberInput);
                UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, artOfUser);

                
            }
            //foreach (CreateUser user in privateUserList)
            //{
            //    Console.WriteLine($"Usernummer:\t{user.userNumber}\nName:\t\t{user.userName}\nAdresse:\t{user.userAdress}\nKontakt:\t{user.userContact}\nLogindaten:\t{user.userLogin}\n");
            //}

        }
    }
}