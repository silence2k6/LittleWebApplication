using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleWebApplication.Rewards;
using LittleWebApplication.ProfilData;
using LittleWebApplication.Challenges;
using LittleWebApplication.Notifications;

namespace LittleWebApplication.Users
{
    internal class AdminUser
    {
        public User adminUserProfil;
        public List<User> privatUserList;
        public List<User> businessUserList;
        public List<User> serviceUserList;
        public List<User> adminUserList;
        public List<Fundraiser> fundraiserList;
        public List<Terminal> terminalList;
        public List<CreateGoodie> goodieList;
        public List<Coupon> couponList;
        public List<CreateChallenge> challengeList;
        public List<CreateNotification> notificationList;
        public List<Payment> paymentList;
        public List<Donation> donationList; 
    }
}
