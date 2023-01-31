using LittleWebApplication.ProfilData;
using LittleWebApplication.Users;

namespace LittleWebApplication
{
    public class UImethods
    {
        const int ESC_HASH = 1769499;
        const int FONE_HASH = 7340032;
        const int FTWO_HASH = 7405568;

        /// <summary>
        /// asks user for login number
        /// </summary>
        /// <returns>user login number input</returns>
        public static string AskForUserLoginNumber()
        {
            Console.Write("Benutzername:\t");
            string userLoginNumberInput = Console.ReadLine().ToUpper();
            return userLoginNumberInput;
        }

        /// <summary>
        /// checks if login number is a private/business/service or admin account
        /// </summary>
        /// <param name="userLoginNumberInput">user lpgin number input</param>
        /// <returns>art of user account</returns>
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

        /// <summary>
        /// checks if user account exists in repository
        /// </summary>
        /// <param name="userLoginNumberInput">user login number input</param>
        /// <param name="artOfAccount">art of user account</param>
        /// <returns>selected user as an object</returns>
        public static User CheckUserLoginForUserNumberExist(string userLoginNumberInput, Enums.AccountType artOfAccount)
        {
            List<User> userList = new();

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
            User user = new();

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
                        Console.WriteLine("Benutzername exitiert nicht! Neuen Account anlegen oder Eingabe überprüfen.");
                        user = null;
                        break;
                    }
                }
            }
            return user;
        }

        public static void AccountInacticeNotificaton(Enums.AccountType artOfAccount)
        {
            if (artOfAccount == Enums.AccountType.privateUser)
            {
                Console.WriteLine("Dein Account ist leider nicht aktiv. Du kannst diesen über Deine Little-App reaktivieren.");
            }
            else if (artOfAccount == Enums.AccountType.serviceUser || artOfAccount == Enums.AccountType.businessUser)
            {
                Console.WriteLine("Ihr Account ist leider nicht aktiv. Bitte wenden Sie sich an Ihren Servicebetreuer.");
            }
        }

        /// <summary>
        /// asks user for his password
        /// </summary>
        /// <returns>user password input</returns>
        public static string AskForUserLoginPassword()
        {
            Console.Write("Passwort:\t");
            string userPasswordInput = Console.ReadLine();
            return userPasswordInput;
        }

        /// <summary>
        /// checks if users password input is correct to his saved password
        /// </summary>
        /// <param name="user">user profil</param>
        /// <param name="userPasswordInput">user password input</param>
        /// <returns>true if correct/false if incorrect</returns>
        public static bool CheckUserLoginForValidPassword(User user, string userPasswordInput)
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

        /// <summary>
        /// asks user for menue selection 
        /// </summary>
        /// <param name="menueOptions">how many menues are aviable</param>
        /// <returns>selected menue</returns>
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
                else if (userInput.Key == ConsoleKey.Escape)
                {
                    userMenueSelection = userInput.GetHashCode();
                    break;
                }
                else if (userInput.Key == ConsoleKey.F1)
                {
                    userMenueSelection = userInput.GetHashCode();
                    break;
                }
                else if (userInput.Key == ConsoleKey.F2)
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


        /// <summary>
        /// shows private/business/service or admin user main menue
        /// </summary>
        /// <param name="artOfAccount">art of user account</param>
        /// <returns>how many menues are aviable</returns>
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


        /// <summary>
        /// shows whole private user sub menue
        /// </summary>
        /// <param name="userMainMenueSelection">users selected menue</param>
        public static void ShowPrivatUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;

            while (userMainMenueSelection != ESC_HASH)
            {
                int userSubMenueSelection;

                if (userMainMenueSelection == 1)
                {
                    //show donation list + sort/print function
                    Console.WriteLine("SPENDENÜBERSICHT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD SPENDENLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ESC_HASH)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == 2)
                {
                    Console.WriteLine("\nSAMMLUNGEN\n1.Meine Gewinne\n2.Achievements\n3.Dailys\n4.Little-Missions\n(Press ESC to go back)");
                    subMenueOptions = 4;

                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ESC_HASH)
                    {
                        break;
                    }

                    while (userSubMenueSelection != ESC_HASH)
                    {
                        int subSubMenueOptions = 0;

                        if (userSubMenueSelection == 1)
                        {
                            Console.WriteLine("\nMEINE GEWINNE\n1.Cosmetics\n2.Bilder\n3.Videos\n4.Storys\n5.Zitate\n6.Coupons\n(Press ESC to go back)");
                            subSubMenueOptions = 6;

                            int userSubSubMenueSelection = AskforMenueSelection(subSubMenueOptions);

                            if (userSubSubMenueSelection == ESC_HASH)
                            {
                                break;
                            }

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

                                    while (userSubSubMenueSelection != ESC_HASH)
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
                        else if (userSubMenueSelection == 2)
                        {
                            //show all achievements (finished ones in color and lighted)
                            Console.WriteLine("ACHIEVEMENTS\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE ACHIEVEMENTS ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        else if (userSubMenueSelection == 3)
                        {
                            //show daily challenges
                            Console.WriteLine("DAILY CHALLENGES\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE DAILY CHALLENGES ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }

                        }
                        else if (userSubMenueSelection == 4)
                        {
                            //show regular events if if eventList isn't empty
                            Console.WriteLine("EVENTS\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE AKTIVEN LITTLE-EVENTS ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
                else if (userMainMenueSelection == 3)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Nachrichten\n2.Couponerinnerungen\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ESC_HASH)
                    {
                        break;
                    }

                    while (userSubMenueSelection != ESC_HASH)
                    {
                        if (userSubMenueSelection == 1)
                        {
                            //show all notifications (non read in bold)
                            Console.WriteLine("NACHRICHTEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE EINGEGANGENEN NACHRICHTEN ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        if (userSubMenueSelection == 2)
                        {
                            //show all couponreminder
                            Console.WriteLine("COUPONERINNERUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE COUPONERINNERUNGEN ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
                else if (userMainMenueSelection == 4)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ESC_HASH)
                    {
                        break;
                    }

                    while (userSubMenueSelection != ESC_HASH)
                    {
                        if (userSubMenueSelection == 1)
                        {
                            //show userProfil
                            Console.WriteLine("PROFILEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WIRD USERPROFIL ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        if (userSubMenueSelection == 2)
                        {
                            //show password administration
                            Console.WriteLine("PASSWORTEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER KANN USER SEIN PASSWORT ÄNDERN");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
                else if (userMainMenueSelection == 5)
                {
                    //userNotification administration
                    Console.WriteLine("TICKET ERSTELLEN");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER KANN USER EINE NEUE NACHRICHT FÜR DEN LITTLE-KUNDENSERVICE ERSTELLEN");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ESC_HASH)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == 6)
                {
                    //show map(Google) with all terminal destinations
                    Console.WriteLine("LITTLE-STANDORTE");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD EINE MAP MIT ALLEN TERMINALSTANDORTEN ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ESC_HASH)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
            }
        }

        /// <summary>
        /// shows whole business user sub menue
        /// </summary>
        /// <param name="userMainMenueSelection">selected menue</param>
        /// <returns></returns>
        public static void ShowBusinessUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;

            while (userMainMenueSelection != ESC_HASH)
            {
                if (userMainMenueSelection == 1)
                {
                    //show userTerminals
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD TERMINALLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ESC_HASH)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == 2)
                {
                    //show userCoupons
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD COUPONLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ESC_HASH)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == 3)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    int userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ESC_HASH)
                    {
                        break;
                    }
                    while (userSubMenueSelection != ESC_HASH)
                    {
                        if (userSubMenueSelection == 1)
                        {
                            //show userProfil
                            Console.WriteLine("PROFILEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WIRD USERPROFIL ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        else if (userSubMenueSelection == 2)
                        {
                            //show password administration
                            Console.WriteLine("PASSWORTEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER KANN USER SEIN PASSWORT ÄNDERN");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// shows whole service user sub menue
        /// </summary>
        /// <param name="userMainMenueSelection">selected menue</param>
        /// <returns></returns>
        public static void ShowServiceUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;

            while (userMainMenueSelection != ESC_HASH)
            {
                if (userMainMenueSelection == 1)
                {
                    //show userTerminals
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD TERMINALLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ESC_HASH)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == 2)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Terminalmeldungen\n2.Meine Aufgaben\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    int userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ESC_HASH)
                    {
                        break;
                    }
                    while (userSubMenueSelection != ESC_HASH)
                    {
                        if (userSubMenueSelection == 1)
                        {
                            //show all terminalNotifications (complete notification to disapear)
                            Console.WriteLine("TERMINALMELDUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE TERMINALMELDUNGEN ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        if (userSubMenueSelection == 1)
                        {
                            //show all adminTasks (add note and complete task to disapear)
                            Console.WriteLine("MEINE AUFGABEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WIRD EINE AUFGABENLISTE ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// shows whole admin user sub menue
        /// </summary>
        /// <param name="userMainMenueSelection">selected menue</param>
        /// <returns></returns>
        public static void ShowAdminUserSubMenue(int userMainMenueSelection)
        {
            int subMenueOptions = 0;

            while (userMainMenueSelection != ESC_HASH)
            {
                if (userMainMenueSelection == 1)
                {
                    Console.WriteLine("\nUSERVERWALTUNG\n1.PrivateUser-Übersicht\n2.BusinessUser-Übersicht\n3.ServiceUser-Übersicht\n4.AdminUser-Übersicht\n(Press ESC to go back)");
                    subMenueOptions = 4;

                    int userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ESC_HASH)
                    {
                        break;
                    }
                    while (userSubMenueSelection != ESC_HASH)
                    {
                        if (userSubMenueSelection == 1)
                        {
                            //add sort/search function
                            List<User> privateUserList = Backup.LoadPrivateUserRepository();

                            Console.WriteLine("PRIVATE-USER ÜBERSICHT\n");

                            foreach (User user in privateUserList)
                            {
                                Console.WriteLine(new string('-', 10));
                                Console.WriteLine($"Usernummer:\t{user.userNumber}\nName:\t\t{user.userName}\nAdresse:\t{user.userAdress}\nKontakt:\t{user.userContact}\nAktiv seit:\t{user.joinDateTime}\t{user.accountStatus}");
                                Console.WriteLine(new string('-', 10));
                            }

                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ESC_HASH)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        else if (userSubMenueSelection == 2)
                        {
                            //add sort/search function
                            List<User> businessUserList = Backup.LoadBusinessUserRepository();

                            Console.WriteLine("BUSINESS-USER ÜBERSICHT\n");

                            foreach (User user in businessUserList)
                            {
                                Console.WriteLine(new string('-', 10));
                                Console.WriteLine($"Usernummer:\t{user.userNumber}\nFirma:\t\t{user.userCompany}\nFirmenadresse:\t{user.userAdress}\nPasswort:{user.userLogin.userLoginPassword}\nPartner seit:\t{user.joinDateTime}\t{user.accountStatus}\n");
                                Console.WriteLine(new string('-', 10));
                            }

                            Console.WriteLine("(Press 'F1' to create new businessUser or 'F2' to edit businessUser)\n(Press ESC to go back)");

                            userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                            if (userSubMenueSelection == ESC_HASH)
                            {
                                break;
                            }
                            else if (userSubMenueSelection == FONE_HASH)
                            {
                                while (userSubMenueSelection != ESC_HASH)
                                {
                                    List<Account> accountList = Backup.LoadAccountRepository();
                                    string accountNumber = Account.CreateAccountNumber(accountList);
                                    Account newAccount = Account.CreateAccount(accountNumber, Enums.AccountType.businessUser);
                                    accountList.Add(newAccount);
                                    Backup.StoreAccountRepository(accountList);

                                    User newBusinessUser = User.CreateBusinessUser(Enums.AccountType.businessUser, accountNumber);

                                    //Console.WriteLine(newBusinessUser);
                                    //Console.WriteLine("Drücke ENTER um neuen businessPartner anzulegen");
                                    //string safeNewUser = Console.ReadLine();

                                    businessUserList.Add(newBusinessUser);
                                    Backup.StoreBusinessUserRepository(businessUserList);

                                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                                    if (userSubMenueSelection == ESC_HASH)
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (userSubMenueSelection == FTWO_HASH)
                            {
                                EditUserProfil(businessUserList,Enums.AccountType.businessUser);
                            }
                        }
                    }
                }
                else if (userMainMenueSelection == 2)
                {
                    Console.WriteLine("\nFINANZVERWALTUNG\n1.Gesamtspenden anzeigen\n2.Entleerungen anzeigen\n3.Spendenüberweisungen anzeigen\n4.Provisionen anzeigen\n(Press ESC to go back)");
                    subMenueOptions = 4;
                    //show finance administration
                }
                else if (userMainMenueSelection == 3)
                {
                    Console.WriteLine("\nTERMINALVERWALTUNG\n1.Terminal-Übersicht\n2.Terminal erstellen\n(Press ESC to go back)");
                    subMenueOptions = 2;
                    //show terminal administration
                }
                else if (userMainMenueSelection == 4)
                {
                    Console.WriteLine("\nSPENDENORGANISATIONSVERWALTUNG\n1.Spendenorganisationen-Übersicht\n2.Spendenorganisation erstellen\n(Press ESC to go back)");
                    subMenueOptions = 2;
                    //show fundraiser administration
                }
                else if (userMainMenueSelection == 5)
                {
                    Console.WriteLine("\nGEWINNVERWALTUNG\n1.Sofortgewinne-Übersicht\n2.Coupon-Übersicht\n3.Gewinn erstellen\n(Press ESC to go back)");
                    subMenueOptions = 3;
                    //show reward administration
                }
                else if (userMainMenueSelection == 6)
                {
                    Console.WriteLine("\nACHIEVEMENTVERWALTUNG\n1.Achievement-Übersicht\n2.Achievement erstellen\n(Press ESC to go back)");
                    subMenueOptions = 2;
                    //show achievement administration
                }
                else if (userMainMenueSelection == 7)
                {
                    Console.WriteLine("\nNACHRICHTEN\n1.Terminal-Benachrichtigungen\n2.User-Benachrichtigungen\n3.Nachricht erstellen\n4.Aufgabe erstellen\n5.News erstellen\n(Press ESC to go back)");
                    subMenueOptions = 5;
                    //show notification administration
                }
            }
        }

        /// <summary>
        /// shows private/business/service or admin user sub menue
        /// </summary>
        /// <param name="artOfAccount">art of user account</param>
        /// <param name="userMainMenueSelection">selected menue</param>
        public static void ShowSubMenue(Enums.AccountType artOfAccount, int userMainMenueSelection)
        {
            if (artOfAccount == Enums.AccountType.privateUser)
            {
                ShowPrivatUserSubMenue(userMainMenueSelection);
            }
            else if (artOfAccount == Enums.AccountType.businessUser)
            {
                ShowBusinessUserSubMenue(userMainMenueSelection);
            }
            else if (artOfAccount == Enums.AccountType.serviceUser)
            {
                ShowServiceUserSubMenue(userMainMenueSelection);
            }
            else if (artOfAccount == Enums.AccountType.adminUser)
            {
                ShowAdminUserSubMenue(userMainMenueSelection);
            }
        }

        /// <summary>
        /// asks user for first- and lastname
        /// </summary>
        /// <returns>whole name as an object</returns>
        public static NameInformations AskForNameInformations()
        {
            NameInformations newName = new();
            Console.WriteLine("Vorname:\t");
            newName.userFirstName = Console.ReadLine();
            Console.WriteLine("Familienname:\t");
            newName.userLastName = Console.ReadLine();

            return newName;
        }

        /// <summary>
        /// asks user for company name and responsible contact person
        /// </summary>
        /// <param name="artOfAccount">art of user account</param>
        /// <returns>company name and contact person as an object</returns>
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

        /// <summary>
        /// asks user for adress informations
        /// </summary>
        /// <returns>adress as an object</returns>
        public static AdressInformations AskForAdressInformations()
        {
            AdressInformations newAdress = new();
            Console.WriteLine("Straße:\t");
            newAdress.userAdressStreet = Console.ReadLine();
            Console.WriteLine("Hausnummer:\t");
            newAdress.userAdressNumber = Console.ReadLine();
            Console.WriteLine("PLZ:\t");
            newAdress.userAdressPostalCode = Console.ReadLine();
            Console.WriteLine("Stadt:\t");
            newAdress.userAdressTown = Console.ReadLine();
            Console.WriteLine("Bundesland:\t");
            newAdress.userAdressFederalState = Console.ReadLine();

            return newAdress;
        }

        /// <summary>
        /// asks user for bank informations
        /// </summary>
        /// <returns>bankaccount as an object</returns>
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

        /// <summary>
        /// aks user to put in a new password
        /// </summary>
        /// <returns>new user password</returns>
        public static string CreateUserPassword()
        {
            Console.WriteLine("Passwort wählen:\t");
            string newPassword = Console.ReadLine();

            bool validPaswordLength = false;

            while (validPaswordLength == false)
            {
                if (newPassword.Length + 1 < 6)
                {
                    Console.WriteLine("Passwort muss mindestens 6 Stellen haben");
                }
                else
                {
                    break;
                }
            }

            bool validPaswordConfirmation = false;

            while (validPaswordConfirmation == false)
            {
                Console.WriteLine("Passwort wiederholen:\t");
                string passwordConfirmation = Console.ReadLine();

                if (passwordConfirmation == newPassword)
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

        /// <summary>
        /// enables user to edit existing user profil
        /// </summary>
        /// <param name="userList">private/business/service or admin user list</param>
        public static void EditUserProfil(List<User> userList, Enums.AccountType artOfAccount)
        {
            bool validUserLogin = false;
            string userLoginNumberInput = "";
            User userToEdit = new();

            Console.WriteLine("USERPROFIL BEARBEITEN\n");

            while (validUserLogin == false)
            {
                Console.WriteLine("Welchen User wollen Sie bearbeiten?");

                userLoginNumberInput = UImethods.AskForUserLoginNumber();

                userToEdit = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, artOfAccount);

                if (userToEdit != null)
                {
                    break;
                }
            }

            Console.WriteLine("Was möchten Sie ändern?");

            int editOptions = 0;
            int userSelection = 0;

            while (userSelection != ESC_HASH)
            {
                if (artOfAccount == Enums.AccountType.businessUser)
                {
                    Console.WriteLine($"1.Firmenname\n2.Kontaktperson\n3.Firmenadresse\n4.Passwort\n5.Accountstatus\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                    editOptions = 5;
                }
                else if (artOfAccount == Enums.AccountType.serviceUser)
                {
                    Console.WriteLine($"1.Name\n2.Adresse\n3.Kontakt\n4.Passwort\n5.Accountstatus\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                    editOptions = 5;
                }

                userSelection = AskforMenueSelection(editOptions);

                if (userSelection == ESC_HASH)
                {
                    break;
                }

                while (userSelection != ESC_HASH)
                {
                    if (artOfAccount == Enums.AccountType.businessUser)
                    {
                        //edit business user profil
                    }

                    if (artOfAccount == Enums.AccountType.serviceUser)
                    {
                        if (userSelection == 1)
                        {
                            Console.WriteLine($"aktueller Name:\n{new string('-', 10)}\n{userToEdit.userName}\n{new string('-', 10)}\n1.Familienname ändern\n2.Vorname ändern\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                            editOptions = 2;

                            userSelection = AskforMenueSelection(editOptions);

                            if (userSelection == ESC_HASH)
                            {
                                break;
                            }

                            else if (userSelection == 1)
                            {
                                Console.WriteLine("neuer Familienname:\t");
                                userToEdit.userName.userLastName = Console.ReadLine();
                            }
                            else if (userSelection == 2)
                            {
                                Console.WriteLine("neue Vorname:\t");
                                userToEdit.userName.userFirstName = Console.ReadLine();
                            }

                            Console.WriteLine($"neuer Name:\n{new string('-', 10)}\n{userToEdit.userName}\n{new string('-', 10)}\n");

                            SaveUserEdits(artOfAccount);
                        }
                        else if (userSelection == 2)
                        {
                            Console.WriteLine($"aktuelle Adresse:\n{new string('-', 10)}\n{userToEdit.userAdress}\n{new string('-', 10)}\n");

                            Console.WriteLine("neue Strasse:\t");
                            userToEdit.userAdress.userAdressStreet = Console.ReadLine();
                            Console.WriteLine("neue Hausnummer:\t");
                            userToEdit.userAdress.userAdressNumber = Console.ReadLine();
                            Console.WriteLine("neue PLZ:\t");
                            userToEdit.userAdress.userAdressPostalCode = Console.ReadLine();
                            Console.WriteLine("neue Stadt:\t");
                            userToEdit.userAdress.userAdressTown = Console.ReadLine();
                            Console.WriteLine("neues Bundesland:\t");
                            userToEdit.userAdress.userAdressFederalState = Console.ReadLine();

                            Console.WriteLine($"neuer Adresse:\n{new string('-', 10)}\n{userToEdit.userAdress}\n{new string('-', 10)}\n");

                            SaveUserEdits(artOfAccount);
                        }
                        else if (userSelection == 3)
                        {
                            Console.WriteLine($"aktueller Kontakt:\n{new string('-', 10)}\n{userToEdit.userContact}\n{new string('-', 10)}\n1.Telefonnummer ändern\n2.Mailadresse ändern\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                            editOptions = 2;

                            userSelection = AskforMenueSelection(editOptions);

                            if (userSelection == ESC_HASH)
                            {
                                break;
                            }

                            else if (userSelection == 1)
                            {
                                Console.WriteLine("neue Telefonnummer:\t");
                                userToEdit.userContact.userContactTel = Console.ReadLine();
                            }
                            else if (userSelection == 2)
                            {
                                Console.WriteLine("neue Mailadresse:\t");
                                userToEdit.userContact.userContactMail = Console.ReadLine();
                            }

                            Console.WriteLine($"neuer Kontakt:\n{new string('-', 10)}\n{userToEdit.userContact}\n{new string('-', 10)}\n");

                            SaveUserEdits(artOfAccount);
                        }
                        else if (userSelection == 4)
                        {
                            Console.WriteLine($"aktuelles Passwort:\n{new string('-', 10)}\n{userToEdit.userLogin.userLoginPassword}\n{new string('-', 10)}\n");

                            userToEdit.userLogin.userLoginPassword = CreateUserPassword();

                            Console.WriteLine($"neues Passwort:\n{new string('-', 10)}\n{userToEdit.userLogin.userLoginPassword}\n{new string('-', 10)}\n");

                            SaveUserEdits(artOfAccount);
                        }
                        else if (userSelection == 5)
                        {
                            List<Account> accountList = Backup.LoadAccountRepository();

                            Enums.Status accountStatus = Account.CheckAccountStatus(userToEdit, accountList);

                            Console.WriteLine($"aktueller Accountstatus:\n{new string('-', 10)}\n{accountStatus}\n{new string('-', 10)}\n");

                            if (accountStatus == Enums.Status.active)
                            {
                                bool validInput = false;

                                while (validInput == false)
                                {
                                    Console.WriteLine("Account deaktivieren? (Drücke 'Y' um Account zu deaktivieren oder 'ESC' um in das vorherige Menü zurück zu kehren):\t");
                                    string deactivateAccount = Console.ReadLine().ToUpper();

                                    if (deactivateAccount == "Y")
                                    {
                                        accountStatus = Enums.Status.disabled;
                                        Console.WriteLine("Account deaktiviert!");
                                        Backup.StoreAccountRepository(accountList);
                                        break;
                                    }
                                    else if (deactivateAccount == Convert.ToString(ESC_HASH)) ;
                                    {
                                        break;
                                    }
                                    Console.WriteLine("!!!Account deaktivieren mit 'Y' oder 'ESC' um in das vorherige Menü zurück zu kehren!!!");
                                }
                            }
                            else if (accountStatus == Enums.Status.disabled)
                            {
                                bool validInput = false;

                                while (validInput == false)
                                {
                                    Console.WriteLine("Account aktivieren? (Drücke 'Y' um Account zu deaktivieren oder 'ESC' um in das vorherige Menü zurück zu kehren):\t");
                                    string deactivateAccount = Console.ReadLine().ToUpper();

                                    if (deactivateAccount == "Y")
                                    {
                                        accountStatus = Enums.Status.active;
                                        Console.WriteLine("Account aktiviert!");
                                        Backup.StoreAccountRepository(accountList);
                                        break;
                                    }
                                    else if (deactivateAccount == Convert.ToString(ESC_HASH)) ;
                                    {
                                        break;
                                    }
                                    Console.WriteLine("!!!Account aktivieren mit 'Y' oder 'ESC' um in das vorherige Menü zurück zu kehren!!!");
                                }
                            }
                            Console.WriteLine($"neuer Accountstatus:\n{new string('-', 10)}\n{accountStatus}\n{new string('-', 10)}\n");
                        }
                    }
                }
            }
        }

        public static void SaveUserEdits(Enums.AccountType artOfAccount)
        {
            List<User> userList = new();

            if (artOfAccount == Enums.AccountType.privateUser)
            {
                userList = Backup.LoadPrivateUserRepository();
            }
            else if (artOfAccount == Enums.AccountType.businessUser)
            {
                userList = Backup.LoadBusinessUserRepository();
            }
            else if (artOfAccount == Enums.AccountType.serviceUser)
            {
                userList = Backup.LoadServiceUserRepository();
            }
            else if (artOfAccount == Enums.AccountType.adminUser)
            {
                userList = Backup.LoadAdminUserRepository();
            }

            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Änderungenspeichern? (Drücke 'Y' um zu speichern oder 'ESC' um Änderung zu verwerfen und in das vorherige Menü zurück zu kehren):\t");
                string safeEdits = Console.ReadLine().ToUpper();

                if (safeEdits == "Y")
                {
                    Backup.StoreServiceUserRepository(userList);
                    Console.WriteLine("Änderungen gespeichert!");
                    break;
                }
                else if (safeEdits == Convert.ToString(ESC_HASH)) ;
                {
                    Console.WriteLine("Änderungen verworfen!");
                    break;
                }
                Console.WriteLine("!!!Änderungen speichern mit 'Y' oder verwerfen und in das vorherigen Menü zurück kehren mit 'ESC'!!!");
            }
        }

        //public static Donation ShowUserDonation(User userToEdit)
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
