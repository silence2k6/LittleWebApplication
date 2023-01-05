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

            string accountNumber = CreateUser.CreateAccountNumber(accountList);
            string userNumber = CreateUser.CreateUserNumber(Enums.UserType.privateUser, accountNumber);
            DateTime datetime = DateTime.Now;

            AccountInformations newAccount = AccountInformations.CreateAccount(accountNumber, Enums.UserType.privateUser, datetime);
            accountList.Add(newAccount);

            CreateUser newUser = CreateUser.CreatePrivateUserDummy(accountNumber);
            privateUserList.Add(newUser);

            Backup.StoreAccountRepository(accountList);
            Backup.StorePrivateUserRepository(privateUserList);

            bool validUserLogin = false;
            bool validArtOfUser = false;
            string userLoginNumberInput = "";
            Enums.UserType artOfUser = 0;

            while (validUserLogin == false)
            {
                while (validArtOfUser == false)
                {
                    userLoginNumberInput = UImethods.AskForUserLoginNumber();
                    artOfUser = UImethods.CheckUserLoginForArtOfUser(userLoginNumberInput);

                    if (artOfUser != 0)
                    {
                        break;
                    }
                    Console.WriteLine("Eingabe ungültig (Achten Sie darauf dass Ihr Benutzername mit einem Buchstaben beginnen und mit einer Zahlenfolge enden muss)");
                }

                CreateUser user = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, artOfUser);

                if (user != null)
                {
                    break;
                }
            }

            //foreach (CreateUser user in privateUserList)
            //{
            //    Console.WriteLine($"Usernummer:\t{user.userNumber}\nName:\t\t{user.userName}\nAdresse:\t{user.userAdress}\nKontakt:\t{user.userContact}\nLogindaten:\t{user.userLogin}\n");
            //}

        }
    }
}