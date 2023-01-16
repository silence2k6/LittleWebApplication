using LittleWebApplication.Accounts;
using LittleWebApplication.Terminal;
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
            List<AccountInformations> accountList = Backup.LoadAccountRepository();
            List<CreateUser> privateUserList = Backup.LoadPrivateUserRepository();
            //List<CreateTerminal> terminalList = 

            string accountNumber = CreateUser.CreateAccountNumber(accountList);
            string userNumber = CreateUser.CreateUserNumber(Enums.AccountType.privateUser, accountNumber);

            AccountInformations newAccount = AccountInformations.CreateAccount(accountNumber, Enums.AccountType.privateUser);
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

                    //bool subMenueNavigation = false;

                    //while (subMenueNavigation == false)
                    //{
                    //    int subMenueOptions = 0;

                    //    if(artOfAccount == Enums.AccountType.privateUser)
                    //    {
                    //        UImethods.ShowPrivatUserSubMenue(userMainMenueSelection);
                    //        break;
                    //    }
                    //    else if(artOfAccount == Enums.AccountType.businessUser)
                    //    {
                    //        subMenueOptions = UImethods.ShowBusinessUserSubMenue(userMainMenueSelection);
                    //    }
                    //    else if(artOfAccount == Enums.AccountType.serviceUser)
                    //    {
                    //        subMenueOptions = UImethods.ShowServiceUserSubMenue(userMainMenueSelection);
                    //    }
                    //    else if(artOfAccount == Enums.AccountType.adminUser)
                    //    {
                    //        subMenueOptions = UImethods.ShowAdminUserSubMenue(userMainMenueSelection);
                    //    }
                }
            }
            
            //Console.WriteLine(new string('-', 10));
            //Console.WriteLine($"Usernummer:\t{user.userNumber}\nName:\t\t{user.userName}\nAdresse:\t{user.userAdress}\nKontakt:\t{user.userContact}\nLogindaten:\t{user.userLogin}\n");
            //Console.WriteLine(new string('-', 10));

            //foreach (CreateUser user in privateUserList)
            //{
            //    Console.WriteLine($"Usernummer:\t{user.userNumber}\nName:\t\t{user.userName}\nAdresse:\t{user.userAdress}\nKontakt:\t{user.userContact}\nLogindaten:\t{user.userLogin}\n");
            //}

        }
    }
}