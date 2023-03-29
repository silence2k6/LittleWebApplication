using LittleWebApplication.ProfilData;
using LittleWebApplication.Users;

namespace LittleWebApplication
{
    public class UImethods
    {
        /// <summary>
        /// prints a string to console
        /// </summary>
        /// <param name="something">anything you want to print on console</param>
        public static void PrintSomethingToConsole(string something)
        {
            Console.WriteLine(something);
        }

        /// <summary>
        /// print request to console and call for answer
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>console input (string)</returns>
        public static string GetConsoleInputToRequest (string request)
        {
            Console.Write($"{request}\t");
            string consoleInput = Console.ReadLine();
            return consoleInput;
        }

        /// <summary>
        /// asks user for login number
        /// </summary>
        /// <returns>user login number input</returns>
        public static string AskForUserLoginNumber(string question)
        {
            Console.Write($"{question}:\t");
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
                        Console.WriteLine("Benutzername exitiert nicht!\n");
                        user = null;
                        break;
                    }
                }
            }
            return user;
        }

        public static Fundraiser CheckForFundraiserNumberExist()
        {
            List<Fundraiser> fundraiserList = Backup.LoadFundraiserRepository();

            Console.Write("Spendenorganisation wählen:\t");
            int fundraiserNumberInput = Convert.ToInt32(Console.ReadLine());

            int fundraiserObjectPos = 0;
            Fundraiser fundraiser = new();

            while (fundraiserObjectPos <= fundraiserList.Count)
            {
                fundraiser = fundraiserList[fundraiserObjectPos];

                if (int.Equals(fundraiserNumberInput, fundraiser.fundraiserNumber))
                {
                    fundraiser = fundraiserList[fundraiserObjectPos];
                    break;
                }
                else
                {
                    fundraiserObjectPos++;

                    if (fundraiserObjectPos == fundraiserList.Count)
                    {
                        Console.WriteLine("Fundraiser exitiert nicht!\n");
                        fundraiser = null;
                        break;
                    }
                }
            }
            return fundraiser;
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
            else if (artOfAccount == Enums.AccountType.adminUser)
            {
                Console.WriteLine("Dein Account wurde leider deaktiviert. Bitte wende Dich an Deinen Supervisor.");
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
        public static ConsoleKey AskforMenueSelection(int menueOptions)
        {
            bool validUserInput = false;
            ConsoleKeyInfo userInput = new();

            while (validUserInput == false)
            {
                Console.Write("Menüauswahl:\t");
                userInput = Console.ReadKey();
                Console.WriteLine("\n");

                if (char.IsDigit(userInput.KeyChar))
                {
                    int intNumber = Convert.ToInt32(userInput.KeyChar.ToString());

                    if (intNumber <= 0 || intNumber > menueOptions)
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
                    break;
                }
                else if (userInput.Key == ConsoleKey.F1)
                {
                    break;
                }
                else if (userInput.Key == ConsoleKey.F2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Mögliche Menüauswahl beachten!!!");
                }
            }
            return userInput.Key;
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
        public static void ShowPrivatUserSubMenue(ConsoleKey userMainMenueSelection)
        {
            int subMenueOptions = 0;

            while (userMainMenueSelection != ConsoleKey.Escape)
            {
                ConsoleKey userSubMenueSelection;

                if (userMainMenueSelection == ConsoleKey.D1)
                {
                    //show donation list + sort/print function
                    Console.WriteLine("SPENDENÜBERSICHT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD SPENDENLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ConsoleKey.Escape)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D2)
                {
                    Console.WriteLine("\nSAMMLUNGEN\n1.Meine Gewinne\n2.Achievements\n3.Dailys\n4.Little-Missions\n(Press ESC to go back)");
                    subMenueOptions = 4;

                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ConsoleKey.Escape)
                    {
                        break;
                    }

                    while (userSubMenueSelection != ConsoleKey.Escape)
                    {
                        int subSubMenueOptions = 0;

                        if (userSubMenueSelection == ConsoleKey.D1)
                        {
                            Console.WriteLine("\nMEINE GEWINNE\n1.Cosmetics\n2.Bilder\n3.Videos\n4.Storys\n5.Zitate\n6.Coupons\n(Press ESC to go back)");
                            subSubMenueOptions = 6;

                            ConsoleKey userSubSubMenueSelection = AskforMenueSelection(subSubMenueOptions);

                            if (userSubSubMenueSelection == ConsoleKey.Escape)
                            {
                                break;
                            }

                            while (userSubSubMenueSelection != ConsoleKey.Escape)
                            {
                                int subSubSubMenueOptions = 0;

                                if (userSubSubMenueSelection == ConsoleKey.D1)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("COSMETICS");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN COSMETICS ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ConsoleKey.Escape)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == ConsoleKey.D2)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("BILDER");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN BILDER ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ConsoleKey.Escape)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == ConsoleKey.D3)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("VIDEOS");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN VIDEOS ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ConsoleKey.Escape)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == ConsoleKey.D4)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("STORYS");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN STORYS ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ConsoleKey.Escape)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == ConsoleKey.D5)
                                {
                                    //Show userCosmetics
                                    Console.WriteLine("ZITATE");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("HIER WERDEN ALLE ERHALTENEN ZITATE ANGEZEIGT");
                                    Console.WriteLine(new string('-', 10));
                                    Console.WriteLine("(Press ESC to go back)");

                                    while (userSubSubMenueSelection != ConsoleKey.Escape)
                                    {
                                        userSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                    }
                                }
                                else if (userSubSubMenueSelection == ConsoleKey.D6)
                                {
                                    Console.WriteLine("\nCOUPONS\n1.Aktive Coupons\n2.Spezial Coupons\n3.eingelöste Coupons\n4.abgelaufene Coupons\n(Press ESC to go back)");
                                    subSubSubMenueOptions = 4;

                                    ConsoleKey userSubSubSubMenueSelection = AskforMenueSelection(subSubSubMenueOptions);

                                    while (userSubSubMenueSelection != ConsoleKey.Escape)
                                    {
                                        if (userSubSubSubMenueSelection == ConsoleKey.D1)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("AKTIVE COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE AKTIVE COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ConsoleKey.Escape)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                        if (userSubSubSubMenueSelection == ConsoleKey.D2)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("SPEZIAL COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE SPEZIAL COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ConsoleKey.Escape)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                        if (userSubSubSubMenueSelection == ConsoleKey.D3)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("EINGELÖSTE COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE EINGELÖSTEN COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ConsoleKey.Escape)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                        if (userSubSubSubMenueSelection == ConsoleKey.D4)
                                        {
                                            //show all active Coupons
                                            Console.WriteLine("ABGELAUFENE COUPONS\n");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("HIER WERDEN ALLE ABGELAUFENEN COUPONS ANGEZEIGT");
                                            Console.WriteLine(new string('-', 10));
                                            Console.WriteLine("(Press ESC to go back)");

                                            while (userSubSubSubMenueSelection != ConsoleKey.Escape)
                                            {
                                                userSubSubSubMenueSelection = AskforMenueSelection(subMenueOptions);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (userSubMenueSelection == ConsoleKey.D2)
                        {
                            //show all achievements (finished ones in color and lighted)
                            Console.WriteLine("ACHIEVEMENTS\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE ACHIEVEMENTS ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        else if (userSubMenueSelection == ConsoleKey.D3)
                        {
                            //show daily challenges
                            Console.WriteLine("DAILY CHALLENGES\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE DAILY CHALLENGES ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }

                        }
                        else if (userSubMenueSelection == ConsoleKey.D4)
                        {
                            //show regular events if if eventList isn't empty
                            Console.WriteLine("EVENTS\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE AKTIVEN LITTLE-EVENTS ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D2)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Nachrichten\n2.Couponerinnerungen\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ConsoleKey.Escape)
                    {
                        break;
                    }

                    while (userSubMenueSelection != ConsoleKey.Escape)
                    {
                        if (userSubMenueSelection == ConsoleKey.D1)
                        {
                            //show all notifications (non read in bold)
                            Console.WriteLine("NACHRICHTEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE EINGEGANGENEN NACHRICHTEN ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        if (userSubMenueSelection == ConsoleKey.D2)
                        {
                            //show all couponreminder
                            Console.WriteLine("COUPONERINNERUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE COUPONERINNERUNGEN ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D4)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ConsoleKey.Escape)
                    {
                        break;
                    }

                    while (userSubMenueSelection != ConsoleKey.Escape)
                    {
                        if (userSubMenueSelection == ConsoleKey.D1)
                        {
                            //show userProfil
                            Console.WriteLine("PROFILEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WIRD USERPROFIL ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        if (userSubMenueSelection == ConsoleKey.D2)
                        {
                            //show password administration
                            Console.WriteLine("PASSWORTEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER KANN USER SEIN PASSWORT ÄNDERN");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D5)
                {
                    //userNotification administration
                    Console.WriteLine("TICKET ERSTELLEN");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER KANN USER EINE NEUE NACHRICHT FÜR DEN LITTLE-KUNDENSERVICE ERSTELLEN");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ConsoleKey.Escape)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D6)
                {
                    //show map(Google) with all terminal destinations
                    Console.WriteLine("LITTLE-STANDORTE");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD EINE MAP MIT ALLEN TERMINALSTANDORTEN ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ConsoleKey.Escape)
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
        public static void ShowBusinessUserSubMenue(ConsoleKey userMainMenueSelection)
        {
            int subMenueOptions = 0;

            while (userMainMenueSelection != ConsoleKey.Escape)
            {
                if (userMainMenueSelection == ConsoleKey.D1)
                {
                    //show userTerminals
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD TERMINALLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ConsoleKey.Escape)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D2)
                {
                    //show userCoupons
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD COUPONLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ConsoleKey.Escape)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D3)
                {
                    Console.WriteLine("\nEINSTELLUNGEN\n1.Profileinstellungen\n2.Passworteinstellungen\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    ConsoleKey userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ConsoleKey.Escape)
                    {
                        break;
                    }
                    while (userSubMenueSelection != ConsoleKey.Escape)
                    {
                        if (userSubMenueSelection == ConsoleKey.D1)
                        {
                            //show userProfil
                            Console.WriteLine("PROFILEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WIRD USERPROFIL ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        else if (userSubMenueSelection == ConsoleKey.D2)
                        {
                            //show password administration
                            Console.WriteLine("PASSWORTEINSTELLUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER KANN USER SEIN PASSWORT ÄNDERN");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
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
        public static void ShowServiceUserSubMenue(ConsoleKey userMainMenueSelection)
        {
            int subMenueOptions = 0;

            while (userMainMenueSelection != ConsoleKey.Escape)
            {
                if (userMainMenueSelection == ConsoleKey.D1)
                {
                    //show userTerminals
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("HIER WIRD TERMINALLISTE ANGEZEIGT");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine("(Press ESC to go back)");

                    while (userMainMenueSelection != ConsoleKey.Escape)
                    {
                        userMainMenueSelection = AskforMenueSelection(subMenueOptions);
                    }
                }
                else if (userMainMenueSelection == ConsoleKey.D2)
                {
                    Console.WriteLine("\nMELDUNGEN\n1.Terminalmeldungen\n2.Meine Aufgaben\n(Press ESC to go back)");
                    subMenueOptions = 2;

                    ConsoleKey userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                    if (userSubMenueSelection == ConsoleKey.Escape)
                    {
                        break;
                    }
                    while (userSubMenueSelection != ConsoleKey.Escape)
                    {
                        if (userSubMenueSelection == ConsoleKey.D1)
                        {
                            //show all terminalNotifications (complete notification to disapear)
                            Console.WriteLine("TERMINALMELDUNGEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WERDEN ALLE TERMINALMELDUNGEN ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
                            {
                                userSubMenueSelection = AskforMenueSelection(subMenueOptions);
                            }
                        }
                        if (userSubMenueSelection == ConsoleKey.D2)
                        {
                            //show all adminTasks (add note and complete task to disapear)
                            Console.WriteLine("MEINE AUFGABEN\n");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("HIER WIRD EINE AUFGABENLISTE ANGEZEIGT");
                            Console.WriteLine(new string('-', 10));
                            Console.WriteLine("(Press ESC to go back)");

                            while (userSubMenueSelection != ConsoleKey.Escape)
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
        public static void ShowAdminUserSubMenue(ConsoleKey userMainMenueSelection)
        {
            int subMenueOptions = 0;

            if (userMainMenueSelection == ConsoleKey.D1)
            {
                UserAdministration();
            }
            else if (userMainMenueSelection == ConsoleKey.D2)
            {
                Console.WriteLine("\nFINANZVERWALTUNG\n1.Gesamtspenden anzeigen\n2.Entleerungen anzeigen\n3.Spendenüberweisungen anzeigen\n4.Provisionen anzeigen\n(Press ESC to go back)");
                subMenueOptions = 4;
                //show finance administration
            }
            else if (userMainMenueSelection == ConsoleKey.D3)
            {
                TerminalAdministration();
            }
            else if (userMainMenueSelection == ConsoleKey.D4)
            {
                Console.WriteLine("\nSPENDENORGANISATIONSVERWALTUNG\n1.Spendenorganisationen-Übersicht\n2.Spendenorganisation erstellen\n(Press ESC to go back)");
                subMenueOptions = 2;
                //show fundraiser administration
            }
            else if (userMainMenueSelection == ConsoleKey.D5)
            {
                Console.WriteLine("\nGEWINNVERWALTUNG\n1.Sofortgewinne-Übersicht\n2.Coupon-Übersicht\n3.Gewinn erstellen\n(Press ESC to go back)");
                subMenueOptions = 3;
                //show reward administration
            }
            else if (userMainMenueSelection == ConsoleKey.D6)
            {
                Console.WriteLine("\nACHIEVEMENTVERWALTUNG\n1.Achievement-Übersicht\n2.Achievement erstellen\n(Press ESC to go back)");
                subMenueOptions = 2;
                //show achievement administration
            }
            else if (userMainMenueSelection == ConsoleKey.D7)
            {
                Console.WriteLine("\nNACHRICHTEN\n1.Terminal-Benachrichtigungen\n2.User-Benachrichtigungen\n3.Nachricht erstellen\n4.Aufgabe erstellen\n5.News erstellen\n(Press ESC to go back)");
                subMenueOptions = 5;
                //show notification administration
            }
        }

        /// <summary>
        /// administration method for edit existing user and create new user 
        /// </summary>
        /// <param name="userMainMenueSelection">user selection from main menue</param>
        public static void UserAdministration()
        {
            bool userMenueSelection = false;

            while (userMenueSelection == false)
            {
                ConsoleKey userSubMenueSelection = new();
                int subMenueOptions;
            
                Console.WriteLine("\nUSERVERWALTUNG\n1.PrivateUser-Übersicht\n2.BusinessUser-Übersicht\n3.ServiceUser-Übersicht\n4.AdminUser-Übersicht\n(Press ESC to go back)");
                subMenueOptions = 4;

                userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                if (userSubMenueSelection == ConsoleKey.Escape)
                {
                    break;
                }

                while (userSubMenueSelection != ConsoleKey.Escape)
                {
                    List<User> userList = new();

                    if (userSubMenueSelection == ConsoleKey.D1)
                    {
                        //add sort/search function
                        userList = ShowUserList(Enums.AccountType.privateUser);

                        while (userSubMenueSelection != ConsoleKey.Escape)
                        {
                            userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                            if (userSubMenueSelection == ConsoleKey.Escape)
                            {
                                break;
                            }
                        }
                    }
                    else if (userSubMenueSelection == ConsoleKey.D2)
                    {
                        while (userSubMenueSelection != ConsoleKey.Escape)
                        {
                            //add sort/search function
                            userList = ShowUserList(Enums.AccountType.businessUser);

                            userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                            if (userSubMenueSelection == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else if (userSubMenueSelection == ConsoleKey.F1)
                            {
                                List<Account> accountList = Backup.LoadAccountRepository();
                                string accountNumber = Account.CreateAccountNumber(accountList);
                                Account newAccount = Account.CreateAccount(accountNumber, Enums.AccountType.businessUser);

                                User newBusinessUser = User.CreateBusinessUser(accountNumber);

                                bool editsConfirmed = AskForSaveUserEdits(Enums.AccountType.businessUser);

                                if (editsConfirmed == true)
                                {
                                    accountList.Add(newAccount);
                                    Backup.StoreAccountRepository(accountList);
                                    userList.Add(newBusinessUser);
                                    Backup.StoreBusinessUserRepository(userList);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (userSubMenueSelection == ConsoleKey.F2)
                            {
                                ConsoleKey editUserProfil = 0;

                                while (editUserProfil != ConsoleKey.Escape)
                                {
                                    editUserProfil = EditUserProfil(userList, Enums.AccountType.businessUser);
                                }
                            }
                        }
                        break;
                    }
                    else if (userSubMenueSelection == ConsoleKey.D3)
                    {
                        while (userSubMenueSelection != ConsoleKey.Escape)
                        {
                            //add sort/search function
                            userList = ShowUserList(Enums.AccountType.serviceUser);

                            userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                            if (userSubMenueSelection == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else if (userSubMenueSelection == ConsoleKey.F1)
                            {
                                List<Account> accountList = Backup.LoadAccountRepository();
                                string accountNumber = Account.CreateAccountNumber(accountList);
                                Account newAccount = Account.CreateAccount(accountNumber, Enums.AccountType.serviceUser);

                                User newServiceUser = User.CreateServiceUser(accountNumber);

                                bool editsConfirmed = AskForSaveUserEdits(Enums.AccountType.serviceUser);

                                if (editsConfirmed == true)
                                {
                                    accountList.Add(newAccount);
                                    Backup.StoreAccountRepository(accountList);
                                    userList.Add(newServiceUser);
                                    Backup.StoreServiceUserRepository(userList);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (userSubMenueSelection == ConsoleKey.F2)
                            {
                                ConsoleKey editUserProfil = 0;

                                while (editUserProfil != ConsoleKey.Escape)
                                {
                                    editUserProfil = EditUserProfil(userList, Enums.AccountType.serviceUser);
                                }
                            }
                        }
                        break;
                    }
                    else if (userSubMenueSelection == ConsoleKey.D4)
                    {
                        while (userSubMenueSelection != ConsoleKey.Escape)
                        {
                            //add sort/search function
                            userList = ShowUserList(Enums.AccountType.adminUser);

                            userSubMenueSelection = AskforMenueSelection(subMenueOptions);

                            if (userSubMenueSelection == ConsoleKey.Escape)
                            {
                                break;
                            }
                            else if (userSubMenueSelection == ConsoleKey.F1)
                            {
                                List<Account> accountList = Backup.LoadAccountRepository();
                                string accountNumber = Account.CreateAccountNumber(accountList);
                                Account newAccount = Account.CreateAccount(accountNumber, Enums.AccountType.adminUser);

                                User newAdminUser = User.CreateAdminUser(accountNumber);

                                bool editsConfirmed = AskForSaveUserEdits(Enums.AccountType.adminUser);

                                if (editsConfirmed == true)
                                {
                                    accountList.Add(newAccount);
                                    Backup.StoreAccountRepository(accountList);
                                    userList.Add(newAdminUser);
                                    Backup.StoreAdminUserRepository(userList);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (userSubMenueSelection == ConsoleKey.F2)
                            {
                                ConsoleKey editUserProfil = 0;

                                while (editUserProfil != ConsoleKey.Escape)
                                {
                                    editUserProfil = EditUserProfil(userList, Enums.AccountType.adminUser);
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        public static void TerminalAdministration()
        {
            List<Terminal> terminalList = ShowTerminalList();
            int subMenueOptions = 0;

            ConsoleKey terminalSubMenueSelection = AskforMenueSelection(subMenueOptions);

            while (terminalSubMenueSelection != ConsoleKey.Escape)
            {
                if (terminalSubMenueSelection == ConsoleKey.Escape)
                {
                    break;
                }
                else if (terminalSubMenueSelection == ConsoleKey.F1)
                {
                    //load terminal repository
                    Terminal.CreateTerminal();
                    //break if terminal creation get stopped
                    //show new terminal
                    //ask user if want to save new terminal
                    //store new terminal in terminal repository
                }
                else if (terminalSubMenueSelection == ConsoleKey.F2)
                {
                    //show terminal details
                    //ask user if want to edit terminal
                }
            }
        }

        /// <summary>
        /// Shows all user profils which are saved in repository
        /// </summary>
        /// <param name="artOfAccount">determine repository</param>
        public static List<User> ShowUserList (Enums.AccountType artOfAccount)
        {
            List<User> userList = new();

            if (artOfAccount == Enums.AccountType.privateUser)
            {
                userList = Backup.LoadPrivateUserRepository();
                Console.WriteLine("PRIVATE-USER ÜBERSICHT");
            }
            else if (artOfAccount == Enums.AccountType.businessUser)
            {
                userList = Backup.LoadBusinessUserRepository();
                Console.WriteLine("BUSINESS-USER ÜBERSICHT");
            }
            else if (artOfAccount == Enums.AccountType.serviceUser)
            {
                userList = Backup.LoadServiceUserRepository();
                Console.WriteLine("SERVICE-USER ÜBERSICHT");
            }
            else if (artOfAccount == Enums.AccountType.adminUser)
            {
                userList = Backup.LoadAdminUserRepository();
                Console.WriteLine("ADMIN-USER ÜBERSICHT");
            }

            if (userList.Count <= 0)
            {
                Console.WriteLine($"{new string('-', 10)}\nKeine User vorhanden\n{new string('-', 10)}");
            }
            else
            {
                foreach (User user in userList)
                {
                    if (artOfAccount == Enums.AccountType.privateUser)
                    {
                        Console.WriteLine($"{new string('-', 10)}\nUsernummer:\t{user.userNumber}\nName:\t\t{user.userName.userFirstName} {user.userName.userLastName.ToUpper()}\nAdresse:\t{user.userAdress}\nKontakt:\t{user.userContact}\nAktiv seit:\t{user.joinDateTime}\t{user.accountStatus}\n{new string('-', 10)}");
                        Console.WriteLine("(Drücke ESC um Menü zu verlassen)");
                    }
                    else
                    {
                        if (artOfAccount == Enums.AccountType.businessUser)
                        {
                            Console.WriteLine($"{new string('-', 10)}\nUsernummer:\t{user.userNumber}\nFirma:\t\t{user.userCompany}\nFirmenadresse:\t{user.userAdress.userAdressStreet} {user.userAdress.userAdressNumber}\n\t\t{user.userAdress.userAdressPostalCode} {user.userAdress.userAdressTown}\n\t\t{user.userAdress.userAdressFederalState}\nBenutzername:\t{user.userLogin.userLoginNumber}\nPasswort:\t{user.userLogin.userLoginPassword}\nPartner seit:\t{user.joinDateTime}\t{user.accountStatus}\n{new string('-', 10)}");
                        }
                        else if (artOfAccount == Enums.AccountType.serviceUser)
                        {
                            Console.WriteLine($"{new string('-', 10)}\nUsernummer:\t{user.userNumber}\nName:\t\t{user.userName.userFirstName} {user.userName.userLastName.ToUpper()}\nAdresse:\t{user.userAdress}\nKontakt:\t{user.userContact}\nAktiv seit:\t{user.joinDateTime}\t{user.accountStatus}\n{new string('-', 10)}");
                        }
                        else if (artOfAccount == Enums.AccountType.adminUser)
                        {
                            Console.WriteLine($"{new string('-', 10)}\nUsernummer:\t{user.userNumber}\nName:\t\t{user.userName.userFirstName} {user.userName.userLastName.ToUpper()}\n{new string('-', 10)}");
                        }
                        Console.WriteLine("(Drücke 'F1' um einen neuen User zu erstellen oder 'F2' um einen User zu bearbeiten)\n(Drücke ESC um Menü zu verlassen)");
                    }
                }
            }
            return userList;
        }

        public static List<Terminal> ShowTerminalList()
        {
            List<Terminal> terminalList = Backup.LoadTerminalRepository();
            Console.WriteLine("TERMINAL ÜBERSICHT");

            if (terminalList.Count <= 0)
            {
                Console.WriteLine($"{new string('-', 10)}\nKeine Terminals vorhanden\n{new string('-', 10)}");
            }
            else
            {
                foreach (Terminal terminal in terminalList)
                {
                    Console.WriteLine(terminal); //+Terminal Owner +Terminal Fundraiser +Terminal Rewards +Terminal Coupons +Terminal Donations
                }
                Console.WriteLine("(Drücke 'F1' um einen neuen Terminal zu erstellen)\n" +
                "(Drücke 'F2' um in die Detailansicht eines Terminals zu gelangen)\n" +
                "(Drücke ESC um Menü zu verlassen)");
            }
            return terminalList;
        }

        /// <summary>
        /// shows private/business/service or admin user sub menue
        /// </summary>
        /// <param name="artOfAccount">art of user account</param>
        /// <param name="userMainMenueSelection">selected menue</param>
        public static void ShowUserSubMenues(Enums.AccountType artOfAccount, ConsoleKey userMainMenueSelection)
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
            Console.Write("Vorname:\t");
            newName.userFirstName = Console.ReadLine();
            Console.Write("Familienname:\t");
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
                Console.Write("Name Spendenorganisation:\t");
            }
            else if (artOfAccount == Enums.AccountType.businessUser)
            {
                Console.Write("Name Firma:\t\t\t");
            }
            newCompany.companyName = Console.ReadLine();
            Console.WriteLine("Kontaktperson Name:");
            newCompany.contactPersonName = AskForNameInformations();
            Console.Write("Kontaktperson Firmenfunktion:\t");
            newCompany.contactPersonFunction = Console.ReadLine();
            Console.Write("Kontaktperson Telefonnummer:\t");
            newCompany.contactPersonTel = Console.ReadLine();
            Console.Write("Kontaktperson Email-Adresse:\t");
            newCompany.contactPersonMail = Console.ReadLine();

            return newCompany;
        }

        /// <summary>
        /// asks user for adress informations
        /// </summary>
        /// <returns>adress as an object</returns>
        public static AdressInformations AskForUserAdressInformations()
        {
            AdressInformations newUserAdress = new();
            Console.Write("Straße:\t\t");
            newUserAdress.userAdressStreet = Console.ReadLine();
            Console.Write("Hausnummer:\t");
            newUserAdress.userAdressNumber = Console.ReadLine();
            Console.Write("PLZ:\t\t");
            newUserAdress.userAdressPostalCode = Console.ReadLine();
            Console.Write("Stadt:\t\t");
            newUserAdress.userAdressTown = Console.ReadLine();
            Console.Write("Bundesland:\t");
            newUserAdress.userAdressFederalState = Console.ReadLine();

            return newUserAdress;
        }

        public static AdressInformations AskForTerminalAdressInformations()
        {
            AdressInformations newTerminalAdress = new();
            Console.Write("Adressbezeichnung:\t");
            newTerminalAdress.terminalAdress = Console.ReadLine();
            Console.Write("Adresszusatz:\t\t");
            newTerminalAdress.terminalAdressExtraText = Console.ReadLine();
            Console.Write("GPS-Code:\t\t\t");
            newTerminalAdress.terminalAdressLocation = Console.ReadLine();

            return newTerminalAdress;
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
        public static LoginInformations CreateUserLogin(string accountNumber, Enums.AccountType artOfAccount)
        {
            LoginInformations newLogin = new();

            string newPassword = AskForNewUserPassword();
            newLogin.userLoginPassword = newPassword;

            string newLoginNumber = "";

            if(artOfAccount == Enums.AccountType.privateUser)
            {
                newLoginNumber = "P" + accountNumber;
            }
            else if(artOfAccount == Enums.AccountType.businessUser)
            {
                newLoginNumber = "B" + accountNumber;
            }
            else if (artOfAccount == Enums.AccountType.serviceUser)
            {
                newLoginNumber = "S" + accountNumber;
            }
            else if (artOfAccount == Enums.AccountType.adminUser)
            {
                newLoginNumber = "A" + accountNumber;
            }
            newLogin.userLoginNumber = newLoginNumber;

            return newLogin;
        }

        public static string AskForNewUserPassword()
        {
            string newPassword = "";
            
            Console.WriteLine("(Wählen Sie ein Passwort welches aus mindestens 6 Stellen besteht)");

            bool validPaswordLength = false;

            while (validPaswordLength == false)
            {
                Console.Write("Passwort wählen:\t");
                newPassword = Console.ReadLine();

                if (newPassword.Length < 6)
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
                Console.Write("Passwort wiederholen:\t");
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
        /// <param name="userList">business/service or admin user list</param>
        public static ConsoleKey EditUserProfil(List<User> userList, Enums.AccountType artOfAccount)
        {
            ConsoleKey editUserProfil = new();

            while (editUserProfil != ConsoleKey.Escape)
            {
                ConsoleKey userDecision = new();
                User userToEdit = new();

                while (userDecision != ConsoleKey.Escape)
                {
                    Console.WriteLine("\nUSERPROFIL BEARBEITEN\nWelchen User wollen Sie bearbeiten?");

                    string userLoginNumberInput = UImethods.AskForUserLoginNumber("Benutzername");

                    userToEdit = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, artOfAccount);

                    if (userToEdit != null)
                    {
                        if (artOfAccount == Enums.AccountType.businessUser)
                        {
                            Console.WriteLine($"\nAKTUELLES USERPROFIL:\n{new string('-', 10)}\nUsernummer:\t{userToEdit.userNumber}\nFirma:\t\t{userToEdit.userCompany}\nFirmenadresse:\t{userToEdit.userAdress.userAdressStreet} {userToEdit.userAdress.userAdressNumber}\n\t\t{userToEdit.userAdress.userAdressPostalCode} {userToEdit.userAdress.userAdressTown}\n\t\t{userToEdit.userAdress.userAdressFederalState}\nBenutzername:\t{userToEdit.userLogin.userLoginNumber}\nPasswort:\t{userToEdit.userLogin.userLoginPassword}\nPartner seit:\t{userToEdit.joinDateTime}\t{userToEdit.accountStatus}\n{new string('-', 10)}");
                            break;
                        }
                        else if (artOfAccount == Enums.AccountType.serviceUser)
                        {
                            Console.WriteLine($"\nAKTUELLES USERPROFIL:\n{new string('-', 10)}\nUsernummer:\t{userToEdit.userNumber}\nMitarbeiter:\t\t{userToEdit.userName}\nAdresse:\t{userToEdit.userAdress.userAdressStreet} {userToEdit.userAdress.userAdressNumber}\n\t\t{userToEdit.userAdress.userAdressPostalCode} {userToEdit.userAdress.userAdressTown}\n\t\t{userToEdit.userAdress.userAdressFederalState}\nBenutzername:\t{userToEdit.userLogin.userLoginNumber}\nPasswort:\t{userToEdit.userLogin.userLoginPassword}\nMitarbeiter seit:\t{userToEdit.joinDateTime}\t{userToEdit.accountStatus}\n{new string('-', 10)}");
                            break;
                        }
                        else if (artOfAccount == Enums.AccountType.adminUser)
                        {
                            if (userToEdit.userNumber == "A#000001")
                            {
                                Console.WriteLine("Bearbeitung des Hautadmins nicht möglich!!!");
                            }
                            else
                            {
                                Console.WriteLine($"\nAKTUELLES USERPROFIL:\n{new string('-', 10)}\nUsernummer:\t{userToEdit.userNumber}\nAdmin:\t\t{userToEdit.userName}\nBenutzername:\t{userToEdit.userLogin.userLoginNumber}\nPasswort:\t{userToEdit.userLogin.userLoginPassword}\nAdmin seit:\t{userToEdit.joinDateTime}\t{userToEdit.accountStatus}\n{new string('-', 10)}");
                                break;
                            }
                        }
                    }
                    else
                    {
                        userDecision = AskSomeQuestionOrPressESC("Auswahl ändern 'Y' oder Menü verlassen 'ESC':", "\n", "Userbearbeitung ABGEBROCHEN!");

                        if (userDecision == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }
                }

                int editOptions = 0;
                ConsoleKey userSelection = new();
                bool editsConfirmed;

                while (userSelection != ConsoleKey.Escape)
                {
                    Console.WriteLine("Was möchten Sie ändern?");

                    if (artOfAccount == Enums.AccountType.businessUser)
                    {
                        Console.WriteLine($"1.Firmenname\n2.Kontaktperson\n3.Firmenadresse\n4.Passwort\n5.Accountstatus\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                        editOptions = 5;
                    }
                    else if (artOfAccount == Enums.AccountType.serviceUser)
                    {
                        Console.WriteLine($"1.Name Mitarbeiter\n2.Adresse\n3.Kontakt\n4.Passwort\n5.Accountstatus\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                        editOptions = 5;
                    }
                    else if (artOfAccount == Enums.AccountType.adminUser)
                    {
                        Console.WriteLine($"1.Name Admin\n2.Passwort\n3.Accountstatus\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                        editOptions = 3;
                    }

                    userSelection = AskforMenueSelection(editOptions);

                    if (userSelection == ConsoleKey.Escape)
                    {
                        break;
                    }

                    while (userSelection != ConsoleKey.Escape)
                    {
                        if (artOfAccount == Enums.AccountType.businessUser)
                        {
                            if (userSelection == ConsoleKey.D1)
                            {
                                Console.Write($"aktueller Firmenname:\n{new string('-', 10)}\n{userToEdit.userCompany.companyName}\n{new string('-', 10)}\nneuer Firmenname:\t");
                                string oldCompanyName = userToEdit.userCompany.companyName;
                                userToEdit.userCompany.companyName = Console.ReadLine();
                                Console.WriteLine($"\nNEUES USERPROFIL:\n{new string('-', 10)}\nUsernummer:\t{userToEdit.userNumber}\nFirma:\t\t{userToEdit.userCompany}\nFirmenadresse:\t{userToEdit.userAdress.userAdressStreet} {userToEdit.userAdress.userAdressNumber}\n\t\t{userToEdit.userAdress.userAdressPostalCode} {userToEdit.userAdress.userAdressTown}\n\t\t{userToEdit.userAdress.userAdressFederalState}\nBenutzername:\t{userToEdit.userLogin.userLoginNumber}\nPasswort:\t{userToEdit.userLogin.userLoginPassword}\nPartner seit:\t{userToEdit.joinDateTime}\t{userToEdit.accountStatus}\n{new string('-', 10)}");

                                editsConfirmed = AskForSaveUserEdits(artOfAccount);

                                if (editsConfirmed == true)
                                {
                                    Backup.StoreBusinessUserRepository(userList);
                                }
                                else if (editsConfirmed == false)
                                {
                                    userToEdit.userCompany.companyName = oldCompanyName;
                                    Backup.StoreBusinessUserRepository(userList);
                                }
                            }
                            if (userSelection == ConsoleKey.D2)
                            {
                                NameInformations oldContactPerson = userToEdit.userName;
                                Console.WriteLine($"aktuelle Kontaktperson:\n{new string('-', 10)}\n{userToEdit.userCompany.contactPersonName.userFirstName} {userToEdit.userCompany.contactPersonName.userLastName.ToUpper()}\n{new string('-', 10)}\n1.Familienname ändern\n2.Vorname ändern\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                                editOptions = 2;

                                userSelection = AskforMenueSelection(editOptions);

                                if (userSelection == ConsoleKey.Escape)
                                {
                                    break;
                                }
                                else
                                {
                                    userToEdit.userName = EditUserName(userToEdit, userSelection);
                                }

                                editsConfirmed = AskForSaveUserEdits(artOfAccount);

                                if (editsConfirmed == true)
                                {
                                    Backup.StoreBusinessUserRepository(userList);
                                }
                                else if (editsConfirmed == false)
                                {
                                    userToEdit.userName = oldContactPerson;
                                    Backup.StoreBusinessUserRepository(userList);
                                }
                            }
                            break;
                        }

                        else if (artOfAccount == Enums.AccountType.serviceUser)
                        {
                            if (userSelection == ConsoleKey.D1)
                            {
                                NameInformations oldUserName = userToEdit.userName;
                                Console.WriteLine($"aktueller Name:\n{new string('-', 10)}\n{userToEdit.userName.userFirstName} {userToEdit.userName.userLastName.ToUpper()}\n{new string('-', 10)}\n1.Familienname ändern\n2.Vorname ändern\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                                editOptions = 2;

                                userSelection = AskforMenueSelection(editOptions);

                                if (userSelection == ConsoleKey.Escape)
                                {
                                    break;
                                }
                                else
                                {
                                    userToEdit.userName = EditUserName(userToEdit, userSelection);
                                }

                                editsConfirmed = AskForSaveUserEdits(artOfAccount);

                                if (editsConfirmed == true)
                                {
                                    Backup.StoreServiceUserRepository(userList);
                                }
                                else if (editsConfirmed == false)
                                {
                                    userToEdit.userName = oldUserName;
                                    Backup.StoreServiceUserRepository(userList);
                                }
                            }
                            else if (userSelection == ConsoleKey.D2)
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

                                //AskForSaveUserEdits(artOfAccount);
                            }
                            else if (userSelection == ConsoleKey.D3)
                            {
                                Console.WriteLine($"aktueller Kontakt:\n{new string('-', 10)}\n{userToEdit.userContact}\n{new string('-', 10)}\n1.Telefonnummer ändern\n2.Mailadresse ändern\n(Drücke ESC um Profilbearbeitung zu verlassen)\n");
                                editOptions = 2;

                                userSelection = AskforMenueSelection(editOptions);

                                if (userSelection == ConsoleKey.Escape)
                                {
                                    break;
                                }

                                else if (userSelection == ConsoleKey.D1)
                                {
                                    Console.WriteLine("neue Telefonnummer:\t");
                                    userToEdit.userContact.userContactTel = Console.ReadLine();
                                }
                                else if (userSelection == ConsoleKey.D2)
                                {
                                    Console.WriteLine("neue Mailadresse:\t");
                                    userToEdit.userContact.userContactMail = Console.ReadLine();
                                }

                                Console.WriteLine($"neuer Kontakt:\n{new string('-', 10)}\n{userToEdit.userContact}\n{new string('-', 10)}\n");

                                //AskForSaveUserEdits(artOfAccount);
                            }
                            else if (userSelection == ConsoleKey.D4)
                            {
                                Console.WriteLine($"aktuelles Passwort:\n{new string('-', 10)}\n{userToEdit.userLogin.userLoginPassword}\n{new string('-', 10)}\n");

                                userToEdit.userLogin.userLoginPassword = AskForNewUserPassword();

                                Console.WriteLine($"neues Passwort:\n{new string('-', 10)}\n{userToEdit.userLogin.userLoginPassword}\n{new string('-', 10)}\n");

                                //AskForSaveUserEdits(artOfAccount);
                            }
                            else if (userSelection == ConsoleKey.D5)
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
                                        else if (deactivateAccount == Convert.ToString(ConsoleKey.Escape))
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
                                        else if (deactivateAccount == Convert.ToString(ConsoleKey.Escape))
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
            return editUserProfil;
        }

        public static NameInformations EditUserName(User userToEdit, ConsoleKey userSelection)
        {
            if (userSelection == ConsoleKey.D1)
            {
                Console.Write("neuer Familienname:\t");
                userToEdit.userName.userLastName = Console.ReadLine();
            }
            else if (userSelection == ConsoleKey.D2)
            {
                Console.Write("neue Vorname:\t");
                userToEdit.userName.userFirstName = Console.ReadLine();
            }
            Console.WriteLine($"neuer Name:\n{new string('-', 10)}\n{userToEdit.userName}\n{new string('-', 10)}\n");
            return userToEdit.userName;
        }

        public static bool AskForSaveUserEdits(Enums.AccountType artOfAccount)
        {
            List<User> userList = new();
            bool editsConfirmed = false;

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

            ConsoleKey userDecision = AskSomeQuestionOrPressESC("Drücke 'Y' um zu speichern oder 'ESC' um Änderung zu verwerfen und in das vorherige Menü zurück zu kehren:\t", "Änderungen GESPEICHERT!", "Änderungen VERWORFEN!");

            if (userDecision == ConsoleKey.Y)
            {
                editsConfirmed = true;
            }
            return editsConfirmed;
        }

        public static ConsoleKey AskSomeQuestionOrPressESC(string someQuestion, string confirmText, string escapeText)
        {
            ConsoleKey userDesicion = new();
            bool validUserInput = false;

            while (validUserInput == false)
            {
                Console.Write($"{someQuestion}\t");
                ConsoleKeyInfo userInput = Console.ReadKey();
                userDesicion = userInput.Key;

                if (userInput.Key == ConsoleKey.Y)
                {
                    Console.WriteLine($"\n{confirmText}");
                    break;
                }
                else if (userInput.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine($"\n{escapeText}");
                    break;
                }
                Console.WriteLine("Eingabe ungültig! Bitte Auswahl beachten.");
            }
            return userDesicion;
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
