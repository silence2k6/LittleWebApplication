using LittleWebApplication.Donations;
using LittleWebApplication.Rewards;
using LittleWebApplication.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.Terminal
{
    public class CreateTerminal
    {
        BusinessUser terminalOwner;
        Fundraiser terminalFundraiser;
        TerminalInformations terminalInformations;
        List<Coupon> terminalCouponList;
        List<Cosmetic> terminalCosmeticList;
        List<Picture> terminalPictureList;
        List<Quote> terminalQuoteList;
        List<Story> terminalStoryList;
        List<Video> terminalVideoList;
        List<Donation> terminalDonationList;
        List<TerminalService> terminalServiceList;

        public static string CreateTerminalNumber(List<TerminalInformations> terminalList)
        { 
            string terminalNumber = "T#" + terminalList.Count + 1;
            return terminalNumber;
        }
    }
}
