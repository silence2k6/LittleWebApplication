﻿using LittleWebApplication.Accounts;
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

            AccountInformations newAccount = AccountInformations.CreateAccount(accountNumber, Enums.UserType.privateUser);
            accountList.Add(newAccount);

            CreateUser newUser = CreateUser.CreatePrivateUserDummy(accountNumber);
            privateUserList.Add(newUser);

            Backup.StoreAccountRepository(accountList);
            Backup.StorePrivateUserRepository(privateUserList);

            bool validUserLogin = false;
            bool validArtOfUser = false;
            string userLoginNumberInput = "";
            Enums.UserType artOfUser = 0;
            CreateUser user = new();

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
                }

                user = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, artOfUser);

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
                int mainMainMenueOptions = UImethods.ShowMainMenue(artOfUser);
                int userMainMenueSelection = UImethods.AskforMenueSelection(mainMainMenueOptions);

                if (userMainMenueSelection == mainMainMenueOptions)
                {
                    Environment.Exit(0);
                    //Go Back To Login
                }
                else
                {
                    bool subMenueNavigation = false;

                    while (subMenueNavigation == false)
                    {
                        int subMenueOptions = UImethods.ShowSubMenue(artOfUser, userMainMenueSelection);
                        int userSubMenueSelection = UImethods.AskforMenueSelection(subMenueOptions);

                        if (userSubMenueSelection == subMenueOptions)
                        {
                            break;
                        }
                        else
                        {
                            Environment.Exit(0);
                            //open Menue Selection
                        }
                    }
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