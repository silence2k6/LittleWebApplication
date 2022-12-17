using LittleWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class ProfilData
    {
        string accountStatus;

        public class NameInformations
        {
            public string userFirstName;
            public string userLastName;
        }

        public class AdressInformations
        {
            public string userAdressStreet;
            public string userAdressNumber;
            public string userAdressTown;
            public string userAdressFederalState;
        }

        public class ContactInformations
        {
            public string userContactTel;
            public string userContactMail;
        }

        public class LoginInformations
        {
            public string userLoginNumber;
            public string userLoginPassword;
        }
        public class AccountInformations
        {
            public int accountNumber;
            public string accountCreationDate;
            public string accountStatus;
            public string artOfUser;
        }
        public class DateTime
        {
            string donationDate;
            string donationTime;
        }

        public class CompanyInformations
        {
            string companyName;
            string contactPersonFirstname;
            string contactPersonFamilyname;
            string contactPersonFunction;
            string contactPerson;
        }

        public class BankAccountInformations
        {
            string bankAccoungIBAN;
            string bankAccountInstitut;
            string bankAccountOwner;
        }

        public static string CreateUserNumber(Enum.UserType artOfUser)
        {
            XmlSerializer serializer = new(typeof(List<AccountInformations>));
            string accountInformationListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\accountInformationList.xml";

            List<AccountInformations> accountInformationList = new();

            accountInformationList = Backup.AccountListRepository(accountInformationList, serializer, accountInformationListPath);

            string userPreNumber = "";
            string userNumberPlaceholder = "";
            int accountNumber = AccountNumber();

            int AccountNumber()
            {
                int latestAccountIndex = accountInformationList.Count;
                AccountInformations latestAccount = accountInformationList[latestAccountIndex];
                int accountNumber = latestAccount.accountNumber + 1;
                return accountNumber;
            }          

            string UserPreNumber()
            {
                if (artOfUser == Enum.UserType.privatUser)
                {
                    userPreNumber = "P#";
                }
                if (artOfUser == Enum.UserType.businessUser)
                {
                    userPreNumber = "B#";
                }
                if (artOfUser == Enum.UserType.serviceUser)
                {
                    userPreNumber = "S#";
                }
                if (artOfUser == Enum.UserType.adminUser)
                {
                    userPreNumber = "A#";
                }
                return userPreNumber;
            }
            userPreNumber = UserPreNumber();

            string UserNumberPlaceholder(int accountNumber)
            {
                if (accountNumber < 10)
                {
                    userNumberPlaceholder = "0000";
                }
                if (accountNumber > 10 && accountNumber < 100)
                {
                    userNumberPlaceholder = "000";
                }
                if (accountNumber > 100 && accountNumber < 1000)
                {
                    userNumberPlaceholder = "00";
                }
                if (accountNumber > 1000 && accountNumber < 10000)
                {
                    userNumberPlaceholder = "0";
                }
                return userNumberPlaceholder;
            }
            userNumberPlaceholder = UserNumberPlaceholder(accountNumber);
            
            string userNumber = $"{userPreNumber}{userNumberPlaceholder}{accountNumber}";
            return userNumber;
        }
    }
}
