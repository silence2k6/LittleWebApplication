using LittleWebApplication.ProfilData;
using LittleWebApplication.Rewards;
using LittleWebApplication.Users;

namespace LittleWebApplication.Terminals
{
    public class Terminal
    {
        public string terminalNumber;
        public string terminalName;
        public string terminalAdressExtraText;
        public string terminalLocation;
        public string terminalStatus;
        public AdressInformations terminalAdress;
        public BusinessUser terminalOwner;
        public Fundraiser terminalFundraiser;
        public List<Coupon> terminalCouponList;
        public List<Cosmetic> terminalCosmeticList;
        public List<Picture> terminalPictureList;
        public List<Quote> terminalQuoteList;
        public List<Story> terminalStoryList;
        public List<Video> terminalVideoList;
        public List<Donation> terminalDonationList;
        public List<TerminalService> terminalServiceList;

        //public Terminal CreateTerminal()
        //{ 

        //}
    }
}
