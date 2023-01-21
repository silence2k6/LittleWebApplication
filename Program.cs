using LittleWebApplication.Terminals;
using LittleWebApplication.Users;
using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    internal class Progamm
    {
        const int ESC_HASH = 1769499;

        static void Main(string[] args)
        {
            List<Account> accountList = Backup.LoadAccountRepository();
            List<CreateUser> privateUserList = Backup.LoadPrivateUserRepository();
            //List<CreateTerminal> terminalList = 

            string accountNumber = CreateUser.CreateAccountNumber(accountList);
            string userNumber = CreateUser.CreateUserNumber(Enums.AccountType.privateUser, accountNumber);

            Account newAccount = Account.CreateAccount(accountNumber, Enums.AccountType.privateUser);
            accountList.Add(newAccount);

            CreateUser newUser = CreateUser.CreatePrivateUserDummy(accountNumber);
            privateUserList.Add(newUser);

            Backup.StoreAccountRepository(accountList);
            Backup.StorePrivateUserRepository(privateUserList);

            bool validUserLogin = false;
            bool validArtOfUser = false;
            string userLoginNumberInput = "";
            Enums.AccountType artOfAccount = 0;
            CreateUser user = new();

            while (validUserLogin == false)
            {
                while (validArtOfUser == false)
                {
                    userLoginNumberInput = UImethods.AskForUserLoginNumber();
                    artOfAccount = UImethods.CheckUserLoginForArtOfUser(userLoginNumberInput);

                    if (artOfAccount != 0)
                    {
                        break;
                    }
                }

                user = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, artOfAccount);

                if (user != null)
                {
                    break;
                }
            }

            bool validUserPassword = false;

            while (validUserPassword == false)
            {
                string userLoginPasswordInput = UImethods.AskForUserLoginPassword();
                validUserPassword = UImethods.CheckUserLoginForValidPassword(user, userLoginPasswordInput);

                if (validUserPassword == true)
                {
                    break;
                }
            }

            bool mainMenueNavigation = false;

            while (mainMenueNavigation == false)
            {
                int mainMainMenueOptions = UImethods.ShowMainMenue(artOfAccount);
                int userMainMenueSelection = UImethods.AskforMenueSelection(mainMainMenueOptions);

                if (userMainMenueSelection == ESC_HASH)
                {
                    Environment.Exit(0);
                    //Go Back To Login
                }
                else
                {
                    if (artOfAccount == Enums.AccountType.privateUser)
                    {
                        UImethods.ShowPrivatUserSubMenue(userMainMenueSelection);
                    }
                }
            }
        }
    }
}