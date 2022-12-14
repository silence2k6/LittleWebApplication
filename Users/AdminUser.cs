using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleWebApplication.Rewards;
using LittleWebApplication.ProfilData;
using LittleWebApplication.Challenges;
using LittleWebApplication.Terminal;
using LittleWebApplication.Notifications;

namespace LittleWebApplication.Users
{
    internal class AdminUser
    {
        public CreateUser adminUserProfil;
        public List<CreateUser> privatUserList;
        public List<CreateUser> businessUserList;
        public List<CreateUser> serviceUserList;
        public List<CreateUser> adminUserList;
        public List<Fundraiser> fundraiserList;
        public List<CreateTerminal> terminalList;
        public List<CreateGoodie> goodieList;
        public List<CreateCoupon> couponList;
        public List<CreateChallenge> challengeList;
        public List<CreateNotification> notificationList;
        public List<Payment> paymentList;
        public List<Donation> donationList; 
    }
}
