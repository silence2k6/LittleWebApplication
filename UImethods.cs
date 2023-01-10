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
        public static int AskforMenueSelection(int menueOptions)
        {
            bool validUserInput = false;
            int userMenueSelection = 0;

            while (validUserInput == false)
            {
                Console.Write("Auswahl:\t");
                validUserInput = int.TryParse(Console.ReadLine(), out userMenueSelection);

                if(userMenueSelection <= 0 || userMenueSelection > menueOptions)
                {
                    Console.WriteLine("Menüauswahl nicht korrekt!");
                    validUserInput = false;
                }
            }
            return userMenueSelection;
        }

        public static int ShowMainMenue(Enums.UserType artOfUser)
        {
            int mainMenueOptions = 0;
            Console.WriteLine("\nHAUPTMENÜ");

            if (artOfUser == Enums.UserType.privateUser)
            {
                Console.WriteLine("1.Spendenübersicht\n2.Sammlungen\n3.Meldungen\n4.Einstellungen\n5.Kontakt\n6.Little-Standorte\n7.Logout");
                mainMenueOptions = 7;
            }
            if (artOfUser == Enums.UserType.businessUser)
            {
                Console.WriteLine("1.Terminalübersicht\n2.Couponübersicht\n3.Einstellungen\n4.Logout");
                mainMenueOptions = 4;
            }
            if (artOfUser == Enums.UserType.serviceUser)
            {
                Console.WriteLine("1.Terminalübersicht\n2.Meldungen\n3.Logout");
                mainMenueOptions = 3;
            }
            if (artOfUser == Enums.UserType.adminUser)
            {
                Console.WriteLine("1.Userverwaltung\n2.Finanzverwaltung\n3.Terminalverwaltung\n4.Spendenorganisationsverwaltung\n5.Gewinnverwaltung\n6.Achievementverwaltung\n7.Nachrichten\n8.Logout");
                mainMenueOptions = 8;
            }
            return mainMenueOptions;
        }

        public static int ShowSubMenue(Enums.UserType artOfUser, int userMenueSelection)
        {
            int subMenueOptions = 0;

            if (artOfUser == Enums.UserType.privateUser)
            {
                if (userMenueSelection == 1)
                {
                    Console.WriteLine("\nSPENDENÜBERSICHT\n1.Meine Spenden anzeigen\n2.Zurück");
                    subMenueOptions = 2;
                }
                if (userMenueSelection == 2)
                {
                    Console.WriteLine("\nSAMMLUNGEN\n1.Meine Gewinne\n2.Meine Achievements\n3.Zurück");
                    subMenueOptions = 3;
                }
                if (userMenueSelection == 3)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Nachrichten\n2.Couponerinnerungen\n3.Zurück");
                    subMenueOptions = 3;
                }
                if (userMenueSelection == 4)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n3.Zurück");
                    subMenueOptions = 3;
                }
                if (userMenueSelection == 5)
                {
                    Console.WriteLine("\nKONTAKT\n1.neues Ticket erstellen\n2.Zurück");
                    subMenueOptions = 2;
                }
                if (userMenueSelection == 6)
                {
                    Console.WriteLine("\nLITTLE-STANDORTE\n1.Terminalstandorte anzeigen\n2.Zurück");
                    subMenueOptions = 2;
                }
            }
            if (artOfUser == Enums.UserType.businessUser)
            {
                if (userMenueSelection == 1)
                {
                    Console.WriteLine("\nTERMINALÜBERSICHT\n1.Meine Terminals anzeigen\n2.Zurück");
                    subMenueOptions = 2;
                }
                if (userMenueSelection == 2)
                {
                    Console.WriteLine("\nCOUPONÜBERSICHT\n1.Meine Coupons anzeigen\n2.Zurück");
                    subMenueOptions = 2;
                }
                if (userMenueSelection == 3)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n3.Zurück");
                    subMenueOptions = 3;
                }
            }
            if (artOfUser == Enums.UserType.serviceUser)
            {
                if (userMenueSelection == 1)
                {
                    Console.WriteLine("\nTERMINALÜBERSICHT\n1.Meine Terminals anzeigen\n2.Zurück");
                    subMenueOptions = 2;
                }
                if (userMenueSelection == 2)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Terminalmeldungen\n2.Aufgaben\n3.Zurück");
                    subMenueOptions = 3;
                }
            }
            if (artOfUser == Enums.UserType.adminUser)
            {
                if (userMenueSelection == 1)
                {
                    Console.WriteLine("\nUSERVERWALTUNG\n1.PrivatUser-Übersicht\n2.BusinessUser-Übersicht\n3.ServiceUser-Übersicht\n4.AdminUser-Übersicht\n5.Zurück");
                    subMenueOptions = 5;
                }
                if (userMenueSelection == 2)
                {
                    Console.WriteLine("\nFINANZVERWALTUNG\n1.Gesamtspenden anzeigen\n2.Entleerungen anzeigen\n3.Spendenüberweisungen anzeigen\n4.Provisionen anzeigen\n5.Zurück");
                    subMenueOptions = 5;
                }
                if (userMenueSelection == 3)
                {
                    Console.WriteLine("\nTERMINALVERWALTUNG\n1.Terminal-Übersicht\n2.Terminal erstellen\n3.Zurück");
                    subMenueOptions = 3;
                }
                if (userMenueSelection == 4)
                {
                    Console.WriteLine("\nSPENDENORGANISATIONSVERWALTUNG\n1.Spendenorganisationen-Übersicht\n2.Spendenorganisation erstellen\n3.Zurück");
                    subMenueOptions = 3;
                }
                if (userMenueSelection == 5)
                {
                    Console.WriteLine("\nGEWINNVERWALTUNG\n1.Sofortgewinne-Übersicht\n2.Coupon-Übersicht\n3.Gewinn erstellen\n4.Zurück");
                    subMenueOptions = 4;
                }
                if (userMenueSelection == 6)
                {
                    Console.WriteLine("\nACHIEVEMENTVERWALTUNG\n1.Achievement-Übersicht\n2.Achievement erstellen\n3.Zurück");
                    subMenueOptions = 3;
                }
                if (userMenueSelection == 7)
                {
                    Console.WriteLine("\nNACHRICHTEN\n1.Terminal-Benachrichtigungen\n2.User-Benachrichtigungen\n3.Nachricht erstellen\n4.Aufgabe erstellen\n5.News erstellen\n6.Zurück");
                    subMenueOptions = 6;
                }
            }
            return subMenueOptions;
        }

        //public static Donation ShowUserDonation(User user)
        //{
            //List<Donation> userDonationList =


            //foreach (Donation userDonation in userDonationList)
            //{
            //    int Donation
            //}

            //return userDonation;
        //}
    }
}
