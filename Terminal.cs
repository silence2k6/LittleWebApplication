using LittleWebApplication.ProfilData;
using LittleWebApplication.Rewards;
using LittleWebApplication.Users;

namespace LittleWebApplication
{
    public class Terminal
    {
        public int terminalNumber;
        public AdressInformations terminalAdress;
        public Enums.Status terminalStatus;
        public User terminalOwner;
        public Fundraiser terminalFundraiser;
        public List<Coupon> terminalCouponList;
        public List<Cosmetic> terminalCosmeticList;
        public List<Picture> terminalPictureList;
        public List<Quote> terminalQuoteList;
        public List<Story> terminalStoryList;
        public List<Video> terminalVideoList;
        public List<Donation> terminalDonationList;

        /// <summary>
        /// method prints terminal object with basic informations to console
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{new string('-', 10)}\n" +
            $"Terminalnummer:\t{terminalNumber}\n" +
            $"Standort:\t\t{terminalAdress.terminalAdress}\n\t\t\t{terminalAdress.terminalAdressExtraText}\n\t\t\t{terminalAdress.terminalAdressLocation}" +
            $"\t{terminalStatus}\n" +
            $"{new string('-', 10)}";
        }

        /// <summary>
        /// method creates new terminal object
        /// </summary>
        /// <returns>new terminal (object)</returns>
        public static Terminal CreateTerminal()
        {
            Terminal newTerminal = new();
            bool stopTerminalCreation = false;

            while (stopTerminalCreation == false)
            {
                newTerminal.terminalNumber = CreateTerminalNumber();
                newTerminal.terminalAdress = UImethods.AskForTerminalAdressInformations();
                newTerminal.terminalStatus = Enums.Status.active;

                newTerminal.terminalOwner = SetTerminalOwner(newTerminal);
                if (newTerminal.terminalOwner == null)
                {
                    UImethods.PrintSomethingToConsole("Terminalerstellung abgebrochen!");
                    newTerminal.terminalStatus = Enums.Status.incomplete;
                    break;
                }

                newTerminal.terminalFundraiser = SetTerminalFundraiser(newTerminal);
                if (newTerminal.terminalFundraiser == null)
                {
                    UImethods.PrintSomethingToConsole("Terminalerstellung abgebrochen!");
                    newTerminal.terminalStatus = Enums.Status.incomplete;
                    break;
                }

                //newTerminal.terminalCouponList = 
            }
            return newTerminal;
        }

        /// <summary>
        /// method creates new terminal number
        /// </summary>
        /// <returns>terminal number (int)</returns>
        public static int CreateTerminalNumber()
        {
            List<Terminal> terminalList = Backup.LoadTerminalRepository();

            int listNumber = terminalList.Count + 1;
            int terminalNumber = Convert.ToInt32(listNumber.ToString("D6"));
            return terminalNumber;
        }

        /// <summary>
        /// method link existing user to terminal
        /// </summary>
        /// <param name="newTerminal"></param>
        /// <returns>terminal owner (object)</returns>
        public static User SetTerminalOwner(Terminal newTerminal)
        {
            UImethods.PrintSomethingToConsole("Wähle einen Firmenkunden dem dieser Terminal zugeordnet werden soll.");

            bool validUserLogin = false;

            while (validUserLogin == false)
            {
                string userLoginNumberInput = UImethods.AskForUserLoginNumber("BussinessUser wählen");
                User terminalOwner = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, Enums.AccountType.businessUser);

                if (terminalOwner == null)
                {
                    ConsoleKey tryAnotherUserNumber = UImethods.AskSomeQuestionOrPressESC("Drücke 'Y' für neue Auswahl oder 'ESC' um Menü zu verlassen", "", "");

                    if (tryAnotherUserNumber == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
                else
                {
                    newTerminal.terminalOwner = terminalOwner;
                    break;
                }
            }
            return newTerminal.terminalOwner;
        }

        /// <summary>
        /// method link existing fundraiser to terminal
        /// </summary>
        /// <param name="newTerminal"></param>
        /// <returns>terminal fundraiser (object)</returns>
        public static Fundraiser SetTerminalFundraiser(Terminal newTerminal)
        {
            UImethods.PrintSomethingToConsole("Wähle eine Spendenorganisation die aus Spenden aus diesem Terminal begünstigt werden soll.");

            bool validUserLogin = false;

            while (validUserLogin == false)
            {
                Fundraiser terminalFundraiser = UImethods.CheckForFundraiserNumberExist();

                if (terminalFundraiser == null)
                {
                    ConsoleKey tryAnotherFundraiserNumber = UImethods.AskSomeQuestionOrPressESC("Drücke 'Y' für neue Auswahln oder 'ESC' um Menü zu verlassen", "", "");

                    if (tryAnotherFundraiserNumber == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
                else
                {
                    newTerminal.terminalFundraiser = terminalFundraiser;
                    break;
                }
            }
            return newTerminal.terminalFundraiser;
        }

        //public static void CreateTerminalService()
        //{

        //}
    }
}
