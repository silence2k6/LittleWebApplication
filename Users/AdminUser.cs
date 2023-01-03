using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleWebApplication.Rewards;
using LittleWebApplication.ProfilData;
using LittleWebApplication.Challenges;
using LittleWebApplication.Terminal;

namespace LittleWebApplication.Users
{
    internal class AdminUser
    {
        int ArtOfUser;
        string userNumber;
        private CreateProfilData newUserProfil = new ();

        private List<User> userAdministration = new List<User>();
        userAdministration.Add(privatUserList);
        userAdministration.Add(businessUserList);
        userAdministration.Add(serviceUserLIst);

	    private List<Fundraiser> fundraiserAdministration = new List<Fundraiser>();
        private Fundraiser fundraiser = new Fundraiser();
        fundraiserAdministration.Add(fundraiser);

	    private List<Terminal> terminalAdministration = new List<Terminal>();
        private Terminal terminal = new Terminal();
        terminalAdministration.Add(terminal);

	    private List<CreateCoupon> rewardAdministration = new List<CreateCoupon>();
        rewardAdministration.Add(couponList);
	    rewardAdministration.Add(goodieList);

	    private List<CreateChallenge> challangeAdministration = new List<CreateChallenge>();
        challangeAdministration.Add(achievementList);
	    challangeAdministration.Add(missionList);
	
        private List<Notification> notificationAdministration = new List<Notification>();
        notificationAdministration.Add(adminNotificationList);
        notificationAdministration.Add(newsList);
        notificationAdministration.Add(adminTaskList);
        notifiactionAdministration.Add(terminalNotificationList);

        private List<Payment> paymentAdministration = new List<Payment>();
        private List<Donation> totalDonationOverview = new List<Donation>();
        paymentAdministraiton.Add(totalDonationOverview);
        private List<TerminalService> totalEmptyingOverview = new List<TerminalService>();
        paymentAdministraion.Add(totalEmptyingOverview);
        private List<Payment> totalFundraiserPaymentOverview = new List<Payment>();
        private Payment fundraiserPayment = new Payment();
        totalFundraiserPaymentOverview.Add(fundraiserPayment);
        paymentAdministration.Add(totalFundraiserPaymentOverview);
    }
}
