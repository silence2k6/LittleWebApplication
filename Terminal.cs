using LittleWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    internal class Terminal
    {
        string terminalNumber;
        private TerminalInformations newTerminal = new TerminalInformations();
        private BusinessUser terminalOwner = new BusinessUser();
        private Fundraiser terminalFundraiser = new Fundraiser();
        private List<Coupon> terminalCouponList = new List<Coupon>();
        private List<Goodie> terminalGoodieList = new List<Goodie>();
        private List<TerminalActivities> terminalActivityList = new List<TerminalActivities>();
        private List<Donation> terminalDonationList = new List<Donation>();
        terminalActivityList.Add(terminalDonationList);
	    private List<Service> terminalServiceList = new List<Service>();
        terminalActivityList.Add(terminalServiceList);
	    private List<TerminalNotification> terminalNotificationList = new List<TerminalNotification>();
        private TerminalNotification terminalNotification = new TerminalNotification();
        terminalNotificationList.Add(terminalNotification);
	    string terminalStatus;
    }

    public class TerminalInformations
    {
        string terminalName;
        private AdressInformations newAdress = new AdressInformations();
        string terminalAdressExtraText;
        string terminalLocation;
        string terminalStatus;
    }

    public class TerminalActivities
    {
        private List<Donation> DonationList = new List<Donation>();
        private Donation donation = new Donation();
        DonationList.Add(donation);

        private List<TerminalService> ServiceList = new List<TerminalService>();
        private TerminalService service = new TerminalService();
        ServiceList.Add(service);
    }

    public class TerminalService
    {
        string ArtOfService;
        private DateTime serviceDateTimeStart = new DateTime();
        private DateTime serviceDateTimeEnd = new DateTime();
        string terminalNumber;
        string userNumber;
    }



}
