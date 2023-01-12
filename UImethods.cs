using LittleWebApplication.ProfilData;
using LittleWebApplication.Users;

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

        public static Enums.AccountType CheckUserLoginForArtOfUser(string userLoginNumberInput)
        {
            Enums.AccountType artOfUser = new();
            bool validPreNumberInput = false;

            while (validPreNumberInput == false)
            {
                if (userLoginNumberInput[0].Equals('P'))
                {
                    artOfUser = Enums.AccountType.privateUser;
                    break;
                }
                if (userLoginNumberInput[0].Equals('B'))
                {
                    artOfUser = Enums.AccountType.businessUser;
                    break;
                }
                if (userLoginNumberInput[0].Equals('S'))
                {
                    artOfUser = Enums.AccountType.serviceUser;
                    break;
                }
                if (userLoginNumberInput[0].Equals('A'))
                {
                    artOfUser = Enums.AccountType.adminUser;
                    break;
                }
                Console.WriteLine("Eingabe ungültig (Achten Sie darauf dass Ihr Benutzername mit einem Buchstaben beginnen und mit einer Zahlenfolge enden muss)");
                break;
            }
            return artOfUser;
        }

        public static CreateUser CheckUserLoginForUserNumberExist(string userLoginNumberInput, Enums.AccountType artOfAccount)
        {
            List<CreateUser> userList = new(); 

            if (artOfAccount == Enums.AccountType.privateUser)
            {
                userList = Backup.LoadPrivateUserRepository();
            }
            if (artOfAccount == Enums.AccountType.businessUser)
            {
                userList = Backup.LoadBusinessUserRepository();
            }
            if (artOfAccount == Enums.AccountType.serviceUser)
            {
                userList = Backup.LoadServiceUserRepository();
            }
            if (artOfAccount == Enums.AccountType.adminUser)
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

        public static int ShowMainMenue(Enums.AccountType artOfAccount)
        {
            int mainMenueOptions = 0;
            Console.WriteLine("\nHAUPTMENÜ");

            if (artOfAccount == Enums.AccountType.privateUser)
            {
                Console.WriteLine("1.Spendenübersicht\n2.Sammlungen\n3.Meldungen\n4.Einstellungen\n5.Kontakt\n6.Little-Standorte\n7.Logout");
                mainMenueOptions = 7;
            }
            if (artOfAccount == Enums.AccountType.businessUser)
            {
                Console.WriteLine("1.Terminalübersicht\n2.Couponübersicht\n3.Einstellungen\n4.Logout");
                mainMenueOptions = 4;
            }
            if (artOfAccount == Enums.AccountType.serviceUser)
            {
                Console.WriteLine("1.Terminalübersicht\n2.Meldungen\n3.Logout");
                mainMenueOptions = 3;
            }
            if (artOfAccount == Enums.AccountType.adminUser)
            {
                Console.WriteLine("1.Userverwaltung\n2.Finanzverwaltung\n3.Terminalverwaltung\n4.Spendenorganisationsverwaltung\n5.Gewinnverwaltung\n6.Achievementverwaltung\n7.Nachrichten\n8.Logout");
                mainMenueOptions = 8;
            }
            return mainMenueOptions;
        }

        public static int ShowSubMenue(Enums.AccountType artOfAccount, int userMenueSelection)
        {
            int subMenueOptions = 0;

            if (artOfAccount == Enums.AccountType.privateUser)
            {
                if (userMenueSelection == 1)
                {
                    //show all donations
                    Console.WriteLine("(Press ESC to go back)");
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
            if (artOfAccount == Enums.AccountType.businessUser)
            {
                if (userMenueSelection == 1)
                {
                    //show userTerminals
                    Console.WriteLine("(Press ESC to go back)");
                }
                if (userMenueSelection == 2)
                {
                    //show userCoupons
                    Console.WriteLine("(Press ESC to go back)");
                }
                if (userMenueSelection == 3)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n3.Zurück");
                    subMenueOptions = 3;
                }
            }
            if (artOfAccount == Enums.AccountType.serviceUser)
            {
                if (userMenueSelection == 1)
                {
                    //show userTerminals
                    Console.WriteLine("(Press ESC to go back)");
                }
                if (userMenueSelection == 2)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Terminalmeldungen\n2.Meine Aufgaben\n3.Zurück");
                    subMenueOptions = 3;
                }
            }
            if (artOfAccount == Enums.AccountType.adminUser)
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

        public static int ShowSubSubMenue (Enums.AccountType artOfAccount, int userSubMenueSelection)
        {
            int subSubMenueOptions = 0; 

            if(artOfAccount == Enums.AccountType.privateUser)
            {
               
            }
            if(artOfAccount == Enums.AccountType.businessUser)
            {
                
            }
            if(artOfAccount == Enums.AccountType.serviceUser)
            {
               
            }
            if (artOfAccount == Enums.AccountType.adminUser)
            {
                
            }
            return subSubMenueOptions;
        }

        public static NameInformations AskForNameInformations()
        {
            NameInformations newName = new();
            Console.WriteLine("Vorname:\t");
            newName.userFirstName = Console.ReadLine();
            Console.WriteLine("Familienname:\t");
            newName.userLastName = Console.ReadLine();

            return newName;
        }

        public static CompanyInformations AskForCompanyInformations(Enums.AccountType artOfAccount)
        {
            CompanyInformations newCompany = new();

            if (artOfAccount == Enums.AccountType.fundraiser)
            {
                Console.WriteLine("Name Spendenorganisation:\t");
            }
            if (artOfAccount == Enums.AccountType.businessUser)
            {
                Console.WriteLine("Name Firma:\t");
            }
            newCompany.companyName = Console.ReadLine();
            Console.WriteLine("Kontaktperson Vorname:\t");
            newCompany.contactPersonFirstname = Console.ReadLine();
            Console.WriteLine("Kontaktperson Familienname:\t");
            newCompany.contactPersonFamilyname = Console.ReadLine();
            Console.WriteLine("Kontaktperson Firmenfunktion:\t");
            newCompany.contactPersonFunction = Console.ReadLine();
            Console.WriteLine("Kontaktperson Telefonnummer:\t");
            newCompany.contactPersonTel = Console.ReadLine();
            Console.WriteLine("Kontaktperson Email-Adresse:\t");
            newCompany.contactPersonMail = Console.ReadLine();

            return newCompany;
        }

        public static AdressInformations AskForAdressInformations()
        {
            AdressInformations newAdress = new();
            Console.WriteLine("Straße:\t");
            newAdress.userAdressStreet = Console.ReadLine();
            Console.WriteLine("Hausnummer:\t");
            newAdress.userAdressNumber = Console.ReadLine();
            Console.WriteLine("Stadt:\t");
            newAdress.userAdressTown = Console.ReadLine();
            Console.WriteLine("Bundesland:\t");
            newAdress.userAdressFederalState = Console.ReadLine();

            return newAdress;
        }

        public static BankAccountInformations AskForBankAccountInformations()
        {
            BankAccountInformations newBankAccount = new();
            Console.WriteLine("IBAN:\t");
            newBankAccount.bankAccoungIBAN = Console.ReadLine();
            Console.WriteLine("Bankinstitut:\t");
            newBankAccount.bankAccountInstitut = Console.ReadLine();
            Console.WriteLine("Kontoinhaber:\t");
            newBankAccount.bankAccountOwner = Console.ReadLine();

            return newBankAccount;
        }

        public static string AskForUserPassword()
        {
            bool validPaswordConfirmation = false;

            Console.WriteLine("Passwort wählen:\t");
            string newPassword = Console.ReadLine();

            while (validPaswordConfirmation == false)
            {
                Console.WriteLine("Passwort wiederholen:\t");
                string passwordConfirmation = Console.ReadLine();

                if (passwordConfirmation == passwordConfirmation)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Passwortbestätigung stimmt nicht mit dem gewählten Passwort überein!");
                }
            }
            return newPassword;
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
