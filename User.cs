using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    public class User
    {
        private List<PrivatUser> privatUserList = new List<PrivatUser>();
        private PrivatUser privatUser = new PrivatUser();
        privatUserList.Add(privatUser);

	    private List<BusinessUser> businessUserList = new List<BusinessUser>();
        private BusinessUser businessUser = new BusinessUser();
        businessUserList.Add(businessUser);

	    private List<ServiceUser> serviceUserList = new List<ServiceUser>();
        private ServiceUser serviceUser = new ServiceUser();
        serviceUserList.Add(serviceUser);
    }

    public class PrivatUser
    {
        string artOfUser;
	    string userNumber;
        private ProfilData newUserProfil = new ProfilData();

        private List<Donation> userDonationList = new List<Donation>();
        private Donation userDonation = new Donation();
        userDonationList.Add(userDonation);

        private List<Reward> userRewards = new List<Reward>();
        private List<Coupon> userCouponCollection = new List<Coupon>();
        userRewards.Add(userCouponCollection);
        private List<Goodie> userGoodieCollection = new List<Goodie>();
        userReward.Add(userGoodieCollection);

        private List<Challenge> userChallanges = new List<Challenge>();
        private List<Achievement> userAchievementCollection = new List<Achievement>();
        userChallenges.Add(userAchievementCollection);
        private List<Mission> userMissionCollection = new List<Mission>();
        userChallanges.Add(userMissionCollection);

        private List<Notification> userNotifications = new List<Notification>();
        private List<AdminNotification> userAdminNotificationCollection = new List<AdminNotification>();
        userNotifications.Add(userAdminNotificationCollection);
        private List<News> userNewsCollection = new List<News>();
        userNotifications.Add(userNewsCollection);
        private List<CouponReminder> userCouponReminderCollection = new List<CouponReminder>();
        private CouponReminder userCouponReminder = new CouponReminder();
        userCouponReminderCollection.Add(userCouponReminder);
        userNotifications.Add(userCouponReminderCollection);
        private List<UserTicket> userTicketCollection = new List<UserTicket>();
        private UserTicket userTicket = new UserTicket();
        userTicketCollection.Add(userTicket);
        userNotifications.Add(userTicketCollection);
    }

    public class BusinessUser
    {
        int ArtOfUser;
        string userNumber;
        private ProfilData newUserProfil = new ProfilData();
        private CompanyInformations newCompany = new CompanyInformations();
        private List<Terminal> businessTerminalList = new List<Terminal>();
        private List<Coupon> businessCouponList new List<Coupon>();
    }

    public class ServiceUser
    {
        int ArtOfUser;
        string userNumber;
        private ProfilData newUserProfil = new ProfilData();
        private List<TerminalService> userServiceList = new List<TerminalService>();
        private TerminalService userService = new TerminalService();
        userServiceList.Add(userService);
	    private List<AdminTask> userTaskList = new List<AdminTask>();
    }

    public class AdminUser
    {
        int ArtOfUser;
        string userNumber;
        private ProfilData newUserProfil = new ProfilData();

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

	    private List<Reward> rewardAdministration = new List<Reward>();
        rewardAdministration.Add(couponList);
	    rewardAdministration.Add(goodieList);

	    private List<Challenge> challangeAdministration = new List<Challenge>();
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
