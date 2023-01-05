using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.Accounts
{
    public class AccountInformations
    {
        public string accountNumber;
        public DateTime accountCreationDateTime;
        public Enums.Status accountStatus;
        public Enums.UserType artOfUser;

        public static AccountInformations CreateAccount(string accountNumber, Enums.UserType artOfUser, DateTime dateTime)
        {
            AccountInformations userAccount = new();
            userAccount.accountNumber = accountNumber;
            userAccount.accountCreationDateTime = dateTime;
            userAccount.artOfUser = artOfUser;
            userAccount.accountStatus = Enums.Status.active;

            return userAccount;
        }
    }
}
