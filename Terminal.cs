using LittleWebApplication.ProfilData;
using LittleWebApplication.Rewards;
using LittleWebApplication.Users;

namespace LittleWebApplication
{
    public class Terminal
    {
        public string terminalNumber;
        public string terminalAdress;
        public string terminalAdressExtraText;
        public string terminalLocation;
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
            $"Standort:\t\t{terminalAdress}\n" +
            $"Zusatztext:\t{terminalAdressExtraText}\n" +
            $"Location(GPS):\t{terminalLocation}\tTerminalstatus:\t{terminalStatus}\n" +
            $"{new string('-', 10)}";
        }


        //public static Terminal CreateTerminal()
        //{ 

        //}

        //public static void CreateTerminalService()
        //{

        //}
    }
}
