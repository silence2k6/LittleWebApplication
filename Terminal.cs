using LittleWebApplication.ProfilData;
using LittleWebApplication.Rewards;
using LittleWebApplication.Users;

namespace LittleWebApplication
{
    public class Terminal
    {
        public string terminalNumber;
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
            newTerminal.terminalNumber = "T#" + CreateTerminalNumber();
            newTerminal.terminalAdress = UImethods.AskForTerminalAdressInformations();
            newTerminal.terminalStatus = Enums.Status.active;
            newTerminal.terminalOwner = SetTerminalOwner(newTerminal);

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
            
                if (terminalOwner != null)
                {
                    break;
                }
            }
            return terminalOwner;
        }

        public static Fundraiser SetTerminalFundraiser(Fundraiser newFundraiser)
        {
            UImethods.PrintSomethingToConsole("Wähle eine Spendenorganisation die aus Spenden aus diesem Terminal begünstigt werden soll.");

            Fundraiser terminalFundraiser = new();
            bool validUserLogin = false;

            while (validUserLogin == false)
            {
                //string userLoginNumberInput = UImethods.AskForUserLoginNumber("Spendenorganisation wählen");
                //terminalFundraiser = UImethods.CheckUserLoginForUserNumberExist(userLoginNumberInput, Enums.AccountType.fundraiser);

                //if (terminalFundraiser != null)
                //{
                //    break;
                //}
            }
            return terminalFundraiser;
        }

        //public static void CreateTerminalService()
        //{

        //}
    }
}
