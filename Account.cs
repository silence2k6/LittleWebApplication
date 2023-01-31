using LittleWebApplication.Users;

namespace LittleWebApplication
{
    public class Account
    {
        const string SUPER_ADMIN = "A000001";

        public string accountNumber;
        public DateTime accountCreationDateTime;
        public Enums.Status accountStatus;
        public Enums.AccountType artOfUser;

        public static Account CreateAccount(string accountNumber, Enums.AccountType artOfUser)
        {
            Account userAccount = new();
            userAccount.accountNumber = accountNumber;
            userAccount.accountCreationDateTime = DateTime.Now;
            userAccount.artOfUser = artOfUser;
            userAccount.accountStatus = Enums.Status.active;

            return userAccount;
        }

        public static string CreateAccountNumber(List<Account> accountList)
        {
            int listNumber = accountList.Count + 1;
            string accountNumber = listNumber.ToString("D6");
            return accountNumber;
        }

        public static Enums.Status CheckAccountStatus(User user, List<Account> accountList)
        {
            Account account = new();
            string userNumber = user.userLogin.userLoginNumber;
            string userAccountNumber = Convert.ToString(userNumber[1..7]);

            bool checkForEquality = false;
            int listPosition = 0;

            while (checkForEquality == false)
            {
                if (user.userNumber == SUPER_ADMIN)
                {
                    break;
                }

                account = accountList[listPosition];
                string accountNumber = account.accountNumber;

                if (accountNumber.Equals(userAccountNumber))
                {
                    break;
                }
                listPosition++;
            }
            return account.accountStatus;
        }

        public override string ToString()
        {
            return $"{accountCreationDateTime}\t{artOfUser}\t{accountNumber}\t{accountStatus}";
        }
    }
}
