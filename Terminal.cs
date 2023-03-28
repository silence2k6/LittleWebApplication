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

        public override string ToString()
        {
            return $"{new string('-', 10)}\n" +
            $"Terminalnummer:\t{terminalNumber}\n" +
            $"Standort:\t\t{terminalAdress.terminalAdress}\n\t\t\t{terminalAdress.terminalAdressExtraText}\n\t\t\t{terminalAdress.terminalAdressLocation}" +
            $"\t{terminalStatus}\n" +
            $"{new string('-', 10)}";
        }

        public static int CreateTerminalNumber()
        {
            List<Terminal> terminalList = Backup.LoadTerminalRepository();

            int listNumber = terminalList.Count + 1;
            int terminalNumber = Convert.ToInt32(listNumber.ToString("D6"));
            return terminalNumber;
        }

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

                newTerminal.terminalFundraiser = SetTerminalFundraiser();
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

        public static User SetTerminalOwner(Terminal newTerminal)
        {
            UImethods.PrintSomethingToConsole("Wähle einen Firmenkunden dem dieser Terminal zugeordnet werden soll.");

            User terminalOwner = new();
            bool validUserLogin = false;

            while (validUserLogin == false)
            {
                string userLoginNumberInput = UImethods.AskForUserLoginNumber("BussinessUser wählen");
                terminalOwner = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, Enums.AccountType.businessUser);

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
                    break;
                }
            }
            return terminalOwner;
        }

        public static Fundraiser SetTerminalFundraiser()
        {
            UImethods.PrintSomethingToConsole("Wähle eine Spendenorganisation die aus Spenden aus diesem Terminal begünstigt werden soll.");

            Fundraiser terminalFundraiser = new();
            bool validUserLogin = false;

            while (validUserLogin == false)
            {
                terminalFundraiser = UImethods.CheckForFundraiserNumberExist();

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
                    break;
                }
            }
            return terminalFundraiser;
        }

        //public static void CreateTerminalService()
        //{

        //}
    }
}
