using LittleWebApplication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    public class UImethods
    {
        public static string AskForUserLoginNumber()
        {
            Console.Write("Benutzername:\t");
            string userLoginNumberInput = Console.ReadLine().ToUpper();
            return userLoginNumberInput;
        }

        public static Enums.UserType CheckUserLoginForArtOfUser(string userLoginNumberInput)
        {
            Enums.UserType artOfUser = new();
            bool validPreNumberInput = false;

            while (validPreNumberInput == false)
            {
                if (userLoginNumberInput[0].Equals('P'))
                {
                    artOfUser = Enums.UserType.privateUser;
                    break;
                }
                if (userLoginNumberInput[0].Equals('B'))
                {
                    artOfUser = Enums.UserType.businessUser;
                    break;
                }
                if (userLoginNumberInput[0].Equals('S'))
                {
                    artOfUser = Enums.UserType.serviceUser;
                    break;
                }
                if (userLoginNumberInput[0].Equals('A'))
                {
                    artOfUser = Enums.UserType.adminUser;
                    break;
                }
                Console.WriteLine("Eingabe ungültig (Achten Sie darauf dass Ihr Benutzername mit einem Buchstaben beginnen und mit einer Zahlenfolge enden muss)");
                break;
            }
            return artOfUser;
        }


        public static CreateUser CheckUserLoginForUserNumberExist(string userLoginNumberInput, Enums.UserType artOfUser)
        {
            List<CreateUser> userList = new(); 

            if (artOfUser == Enums.UserType.privateUser)
            {
                userList = Backup.LoadPrivateUserRepository();
            }
            if (artOfUser == Enums.UserType.businessUser)
            {
                userList = Backup.LoadBusinessUserRepository();
            }
            if (artOfUser == Enums.UserType.serviceUser)
            {
                userList = Backup.LoadServiceUserRepository();
            }
            if (artOfUser == Enums.UserType.adminUser)
            {
                userList = Backup.LoadAdminUserRepository();
            }

            int userObjectPos = 0;
            CreateUser user = new();

            while (userObjectPos <= userList.Count)
            {
                user = userList[userObjectPos];
                
                if (string.Equals(userLoginNumberInput, user.userLogin.userLoginNumber))
                {
                    user = userList[userObjectPos];
                    break;
                }
                else
                {
                    userObjectPos++;

                    if (userObjectPos == userList.Count)
                    {
                        Console.WriteLine("Benutzername exitiert nicht!");
                        user = null;
                        break;
                    }
                }
            }
            return user;
        }

        public static string AskForUserLoginPassword()
        { 
            Console.Write("Passwort:\t");
            string userPasswordInput = Console.ReadLine();
            return userPasswordInput;
        }

        public static bool CheckUserLoginForValidPassword(CreateUser user, string userPasswordInput)
        {
            bool validUserPassword = false;

            while (validUserPassword == false)
            {
                if (string.Equals(user.userLogin.userLoginPassword, userPasswordInput))
                {
                    validUserPassword = true;
                    break;
                }
                Console.WriteLine("Passwort nicht korrekt");
                break;
            }
            return validUserPassword;
        }

        public static void ShowUserMenue(Enums.UserType artOfUser)
        {
            if (artOfUser == Enums.UserType.privateUser)
            {
                Console.WriteLine("1)Spendenübersicht\n2)Sammlungen\n3)Little-Standorte\n4)Meldungen\n5)Einstellungen\n6)Kontakt");
            }
            if (artOfUser == Enums.UserType.businessUser)
            {
                Console.WriteLine("1)Terminalübsersicht\n2)Couponübersicht\n3)Einstellungen");
            }
            if (artOfUser == Enums.UserType.serviceUser)
            {
                Console.WriteLine("1)Terminalübersicht\n2)Meldungen");
            }
            if (artOfUser == Enums.UserType.adminUser) ;
            {
                Console.WriteLine("1)Userverwaltung\n2)Finanzverwaltung\n3)Terminalverwaltung\n4)Sammlungen\n5)Little-Standorte\n6)Meldungen");
            }
        }

        public static int AskForMenueSelection(Enums.UserType artOfUser)
        {
            int userMenueSelectionInput = 0;
            int maxBusinessUserMenueSelections = 3;
            int maxServiceUserMenueSelections = 2;
            int maxAdminUserMenueSelections = 6;
            bool validMenueSelectionInput = false;

            //while (validMenueSelectionInput == false)
            //{
            //    Console.WriteLine("Menüauswahl:");
            //    validMenueSelectionInput = int.TryParse(Console.ReadLine(), out userMenueSelectionInput);
            ////Find way to go out of loop when selection is done (not check every if condition anymore)
            //    if(artOfUser == Enums.UserType.privateUser)
            //    {
            //        int maxPrivatUserMenueSelections = 6;

            //        if (userMenueSelectionInput <= 0 || userMenueSelectionInput > maxServiceUserMenueSelections)
            //        {
            //            Console.WriteLine("Menüauswahl nicht korrekt!");
            //            continue;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}

        }
    }
}
