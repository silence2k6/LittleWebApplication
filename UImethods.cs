using LittleWebApplication.ProfilData;
using LittleWebApplication.Users;
using System.Reflection.Metadata.Ecma335;

namespace LittleWebApplication
{
    public class UImethods
    {
        const int ESC_HASH = 1769499;

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
            ConsoleKeyInfo userInput;
            int userMenueSelection = 0;

            while (validUserInput == false)
            {
                Console.Write("\nMenüauswahl:\t");
                userInput = Console.ReadKey();
                Console.WriteLine("\n");

                if (char.IsDigit(userInput.KeyChar))
                {
                    userMenueSelection = int.Parse(userInput.KeyChar.ToString());

                    if (userMenueSelection <= 0 || userMenueSelection > menueOptions)
                    {
                        if (menueOptions > 0)
                        {
                            Console.WriteLine($"Menüauswahl nur von 1 bis {menueOptions} möglich!");
                        }
                        else
                        {
                            Console.WriteLine("Press ESC to go back");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if(userInput.Key == ConsoleKey.Escape)
                {
                    userMenueSelection = userInput.GetHashCode();
                    break;
                }
                else
                {
                    Console.WriteLine("Nur Ziffern für die Menüauswahl möglich!");
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
                Console.WriteLine("1.Spendenübersicht\n2.Sammlungen\n3.Meldungen\n4.Einstellungen\n5.Kontakt\n6.Little-Standorte\n(Press ESC to Logout)");
                mainMenueOptions = 6;
            }
            else if (artOfAccount == Enums.AccountType.businessUser)
            {
                Console.WriteLine("1.Terminalübersicht\n2.Couponübersicht\n3.Einstellungen\n(Press ESC to Logout)");
                mainMenueOptions = 3;
            }
            else if (artOfAccount == Enums.AccountType.serviceUser)
            {
                Console.WriteLine("1.Terminalübersicht\n2.Meldungen\n(Press ESC to Logout)");
                mainMenueOptions = 2;
            }
            else if (artOfAccount == Enums.AccountType.adminUser)
            {
                Console.WriteLine("1.Userverwaltung\n2.Finanzverwaltung\n3.Terminalverwaltung\n4.Spendenorganisationsverwaltung\n5.Gewinnverwaltung\n6.Achievementverwaltung\n7.Nachrichten\n(Press ESC to Logout)");
                mainMenueOptions = 7;
            }
            return mainMenueOptions;
        }

        public static void ShowPrivatUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;
            int userSubMenueSelection = 0;

            while (userMainMenueSelection != ESC_HASH)
            {
                if (userMainMenueSelection == 1)
                {
                    //show donation list
                    Console.WriteLine("SPENDENÜBERSICHT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD SPENDENLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userSubMenueSelection != ESC_HASH)
                    {
                        userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == 2)
                {
                    Console.WriteLine("\nSAMMLUNGEN\n1.Meine Gewinne\n2.Meine Achievements\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    while (userSubMenueSelection != ESC_HASH)
                    {
                        int subSubMenueOptions = 0;

                        if (userSubMenueSelection == 1)
                        {
                            Console.WriteLine("\nMEINE GEWINNE\n1.Cosmetics\n2.Bilder\n3.Videos\n4.Storys\n5.Zitate\n6.Coupons\n(Press ESC to go back)");
                            subSubMenueOptions = 6;

                            int userSubSubMenueSelection = AskforMenueSelection(subSubMenueOptions);

                            while (userSubSubMenueSelection != ESC_HASH)
                            {
                                int subSubSubMenueOptions = 0;

                                if (userSubSubMenueSelection == 1)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("COSMETICS");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN COSMETICS ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ESC_HASH)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == 2)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("BILDER");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN BILDER ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ESC_HASH)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == 3)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("VIDEOS");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN VIDEOS ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ESC_HASH)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == 4)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("STORYS");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN STORYS ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ESC_HASH)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == 5)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("ZITATE");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN ZITATE ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ESC_HASH)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == 6)
                                {
                                    Console.WriteLine("\nCOUPONS\n1.Aktive Coupons\n2.Spezial Coupons\n3.eingelöste Coupons\n4.abgelaufene Coupons\n(Press ESC to go back)");
                                    subSubSubMenueOptions = 4;

                                    int userSubSubSubMenueSelection = AskforMenueSelection(subSubSubMenueOptions);

                                    bool subSubSubMenueNavigation = false;

                                    while (subSubSubMenueNavigation == false)
                                    {
                                        if (userSubSubSubMenueSelection == 1)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("AKTIVE COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE AKTIVE COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ESC_HASH)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                        if (userSubSubSubMenueSelection == 2)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("SPEZIAL COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE SPEZIAL COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ESC_HASH)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                        if (userSubSubSubMenueSelection == 3)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("EINGELÖSTE COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE EINGELÖSTEN COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ESC_HASH)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                        if (userSubSubSubMenueSelection == 4)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("ABGELAUFENE COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE ABGELAUFENEN COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ESC_HASH)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        userSubMenueSelection = ESC_HASH;
                    }
                }
                else if (userMainMenueSelection == 3)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Nachrichten\n2.Couponerinnerungen\n(Press ESC to go back)");
                    subMenueOptions = 2;
                }
                else if (userMainMenueSelection == 4)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n(Press ESC to go back)");
                    subMenueOptions = 2;
                }
                else if (userMainMenueSelection == 5)
                {
                    Console.WriteLine("\nKONTAKT\n1.neues Ticket erstellen\n(Press ESC to go back)");
                    subMenueOptions = 1;
                }
                else if (userMainMenueSelection == 6)
                {
                    Console.WriteLine("\nLITTLE-STANDORTE\n1.Terminalstandorte anzeigen\n(Press ESC to go back)");
                    subMenueOptions = 1;
                }
            }
        }

        public static int ShowBusinessUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;

            if (userMainMenueSelection == 1)
            {
                //show userTerminals
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("HIER WIRD TERMINALLISTE ANGEZEIGT");
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("(Press ESC to go back)");
            }
            else if (userMainMenueSelection == 2)
            {
                //show userCoupons
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("HIER WIRD COUPONLISTE ANGEZEIGT");
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("(Press ESC to go back)");
            }
            else if (userMainMenueSelection == 3)
            {
                Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n(Press ESC to go back)");
                subMenueOptions = 2;
            }
            return subMenueOptions;
        }

        public static int ShowServiceUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;

            if (userMainMenueSelection == 1)
            {
                //show userTerminals
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("HIER WIRD TERMINALLISTE ANGEZEIGT");
                Console.WriteLine(new string('-', 10));
                Console.WriteLine("(Press ESC to go back)");
            }
            else if (userMainMenueSelection == 2)
            {
                Console.WriteLine("\nMELDUNGEN\n1.Terminalmeldungen\n2.Meine Aufgaben\n(Press ESC to go back)");
                subMenueOptions = 2;
            }
            return subMenueOptions;
        }

        public static int ShowAdminUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;

            if (userMainMenueSelection == 1)
            {
                Console.WriteLine("\nUSERVERWALTUNG\n1.PrivatUser-Übersicht\n2.BusinessUser-Übersicht\n3.ServiceUser-Übersicht\n4.AdminUser-Übersicht\n(Press ESC to go back)");
                subMenueOptions = 4;
            }
            else if (userMainMenueSelection == 2)
            {
                Console.WriteLine("\nFINANZVERWALTUNG\n1.Gesamtspenden anzeigen\n2.Entleerungen anzeigen\n3.Spendenüberweisungen anzeigen\n4.Provisionen anzeigen\n(Press ESC to go back)");
                subMenueOptions = 4;
            }
            else if (userMainMenueSelection == 3)
            {
                Console.WriteLine("\nTERMINALVERWALTUNG\n1.Terminal-Übersicht\n2.Terminal erstellen\n(Press ESC to go back)");
                subMenueOptions = 2;
            }
            else if (userMainMenueSelection == 4)
            {
                Console.WriteLine("\nSPENDENORGANISATIONSVERWALTUNG\n1.Spendenorganisationen-Übersicht\n2.Spendenorganisation erstellen\n(Press ESC to go back)");
                subMenueOptions = 2;
            }
            else if (userMainMenueSelection == 5)
            {
                Console.WriteLine("\nGEWINNVERWALTUNG\n1.Sofortgewinne-Übersicht\n2.Coupon-Übersicht\n3.Gewinn erstellen\n(Press ESC to go back)");
                subMenueOptions = 3;
            }
            else if (userMainMenueSelection == 6)
            {
                Console.WriteLine("\nACHIEVEMENTVERWALTUNG\n1.Achievement-Übersicht\n2.Achievement erstellen\n(Press ESC to go back)");
                subMenueOptions = 2;
            }
            else if (userMainMenueSelection == 7)
            {
                Console.WriteLine("\nNACHRICHTEN\n1.Terminal-Benachrichtigungen\n2.User-Benachrichtigungen\n3.Nachricht erstellen\n4.Aufgabe erstellen\n5.News erstellen\n(Press ESC to go back)");
                subMenueOptions = 5;
            }
            return subMenueOptions;
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
