using LittleWebApplication.ProfilData;
using LittleWebApplication.Users;

namespace LittleWebApplication
{
    internal class Progamm
    {
        const int ESC_HASH = 1769499;

        static void Main(string[] args)
        {
            List<User> adminUserList = new();
            User superAdminUser = User.CreateSuperAdmin();
            adminUserList.Add(superAdminUser);
            Backup.StoreAdminUserRepository(adminUserList);

            List<Account> accountList = Backup.LoadAccountRepository();
            List<User> privateUserList = Backup.LoadPrivateUserRepository();

            string accountNumber = Account.CreateAccountNumber(accountList);
            string userNumber = User.CreateUserNumber(Enums.AccountType.privateUser, accountNumber);

            Account newAccount = Account.CreateAccount(accountNumber, Enums.AccountType.privateUser);
            accountList.Add(newAccount);

            User newUser = User.CreatePrivateUserDummy(accountNumber);
            privateUserList.Add(newUser);

            Backup.StoreAccountRepository(accountList);
            Backup.StorePrivateUserRepository(privateUserList);

            bool validUserLogin = false;
            bool validArtOfUser = false;
            string userLoginNumberInput = "";
            Enums.AccountType artOfAccount = 0;
            Enums.Status accountStatus = 0;
            User user = new();

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

            accountStatus = Account.CheckAccountStatus(user, accountList);

            if (accountStatus != Enums.Status.active)
            {
                UImethods.AccountInacticeNotificaton(artOfAccount);
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
                    UImethods.ShowSubMenue(artOfAccount, userMainMenueSelection);
                }
            }
        }
    }
}