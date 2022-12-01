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
        private UserProfil newUserProfil = new UserProfil();

        private List<Donation> userDonationList = new List<Donation>();
        private Donation userDonation = new Donation();
        userDonationList.Add(userDonation);

        private List<Rewards> userRewards = new List<Rewards>();
        private List<Coupon> userCouponCollection = new List<Coupon>();
        userRewards.Add(userCouponCollection);
        privateList<Goodie> userGoodieCollection = new List<Goodie>();
        userReward.Add(userGoodieCollection);

        private List<Challanges> userChallanges = new List<Challanges>();
        private List<Achievement> userAchievementCollection = new List<Achievement>();
        userChallenges.Add(userAchievementCollection);
        private List<Mission> userMissionCollection = new List<Mission>();
        userChallanges.Add(userMissionCollection);

        private List<Notifications> userNotifications = new List<Notifications>();
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
        enum ArtOfUser;
        string userNumber;
        private UserProfil newUserProfil = new UserProfil();
        private CompanyInformations newCompany = new CompanyInformations();
        private List<Terminal> businessTerminalList = new List<Terminal>();
        private List<Coupon> businessCouponList new List<Coupon>();
    }

    public class ServiceUser
    {
        enum ArtOfUser;
        string userNumber;
        private UserProfil newUserProfil = new UserProfil();
        private List<TerminalService> userServiceList = new List<TerminalService>();
        private Service userService = new Service();
        userServiceList.Add(userService);
	    private List<adminTask> userTaskList = new List<adminTask>();
    }

    public class AdminUser
    {
        enum ArtOfUser;
        string userNumber;
        private UserProfil newUserProfil = new UserProfil();

        private List<Users> userAdministration = new List<User>();
        userAdministration.Add(privatUserList);
        userAdministration.Add(businessUserList);
        userAdministration.Add(serviceUserLIst);

	    private List<Fundraiser> fundraiserAdministration = new List<Fundraiser>();
        private Fundraiser fundraiser = new Fundraiser();
        fundraiserAdministration.Add(fundraiser);

	    private List<Terminal> terminalAdministration = new List<Terminal>();
        private Terminal terminal = new Terminal();
        terminalAdministration.Add(terminal);

	    private List<Rewards> rewardAdministration = new List<Rewards>();
        rewardAdministration.Add(couponList);
	    rewardAdministration.Add(goodieList);

	    private List<Challanges> challangeAdministration = new List<Challanges>();
        challangeAdministration.Add(achievementList);
	    challangeAdministration.Add(missionList);
	
        private List<Notifications> notificationAdministration = new List<Notifications>();
        notificationAdministration.Add(adminNotificationList);
        notificationAdministration.Add(newsList);
        notificationAdministration.Add(adminTaskList);
        notifiactionAdministration.Add(terminalNotificationList);

        private List<Payments> paymentAdministration = new List<Payments>();
        private List<Donation> totalDonationOverview = new List<Donation>();
        paymentAdministraiton.Add(totalDonationOverview);
        private List<Service> totalEmptyingOverview = new List<Service>();
        paymentAdministraion.Add(totalEmptyingOverview);
        private List<Payment> totalFundraiserPaymentOverview = new List<Payment>();
        private Payment fundraiserPayment = new Payment();
        totalFundraiserPaymentOverview.Add(fundraiserPayment);
        paymentAdministration.Add(totalFundraiserPaymentOverview);
    }



}
