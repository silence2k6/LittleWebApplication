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
        //public static PrivatUserDummy newPrivatUser = new()
        //{

        //}


        //private AdressInformations newAdress = new AdressInformations();
        //private LoginInformations newLogin = new LoginInformations();
        //private NameInformations newName = new NameInformations();
        //private ContactInformations newContact = new ContactInformations();
        //private AccountInformations newAccount = new AccountInformations();

        public class AdressInformations
        {
            public string userAdressStreet;
            public string userAdressNumber;
            public string userAdressTown;
            public string userAdressFederalState;
        }
        public class NameInformations
        {
            public string userFirstName;
            public string userLastName;
        }

        public class ContactInformations
        {
            public string userContactTel;
            public string userContactMail;
        }

        public class LoginInformations
        {
            public string userLoginNumber;
            public string userLoginPasswort;
        }
        public class AccountInformations
        {
            public int accountNumber;
            public string accountCreationDate;
            public string accountStatus;
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

        public static string CreateUserNumber(List<AccountInformations> accountInformations, Enum.UserType artOfUser)
        {
            XmlSerializer serializerString = new(typeof(List<string>));
            XmlSerializer serializerObject = new(typeof(List<AccountInformations>));

            string privatUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\privatUserNumberList.xml";
            string businessUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\businessUserNumberList.xml";
            string serviceUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\serviceUserNumberList.xml";
            string adminUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\adminUserNumberList.xml";
            string accountInformationListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\accountInformationList.xml";


            List<string> privatUserNumberList = new();
            List<string> businessUserNumberList = new();
            List<string> serviceUserNumberList = new();
            List<string> adminUserNumberList = new();
            List<AccountInformations> accountInformationList = new();

            privatUserNumberList = Backup.StringListRepository(privatUserNumberList, serializerString, privatUserListPath);
            businessUserNumberList = Backup.StringListRepository(businessUserNumberList, serializerString, businessUserListPath);
            serviceUserNumberList = Backup.StringListRepository(serviceUserNumberList, serializerString, serviceUserListPath);
            adminUserNumberList = Backup.StringListRepository(adminUserNumberList, serializerString, adminUserListPath);
            accountInformationList = Backup.ObjectListRepository(accountInformationList, serializerString, accountInformationListPath);


            int listPos = 0;
            string userPreNumber = "";
            string userNumberPlaceholder = "";
            string userNumber = "";
            string path = "";
            int accountNumber = AccountNumber();
            List<string> userList = new();

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

            List<string> UserList()
            {
                if (artOfUser == Enum.UserType.privatUser)
                {
                    userList = privatUserNumberList;
                    path = privatUserListPath;
                }
                if (artOfUser == Enum.UserType.businessUser)
                {
                    userList = businessUserNumberList;
                    path = businessUserListPath;
                }
                if (artOfUser == Enum.UserType.serviceUser)
                {
                    userList = serviceUserNumberList;
                    path = serviceUserListPath;
                }
                if (artOfUser == Enum.UserType.adminUser)
                {
                    userList = adminUserNumberList;
                    path = adminUserListPath;
                }
                return userList;
            }
            userList = UserList();

            while (listPos <= userList.Count)
            {
                if (userList[listPos] == "unused")
                {
                    userNumber = $"{userPreNumber}{userNumberPlaceholder}{accountNumber}";
                    userList[listPos] = userNumber;
                    Backup.StringListRepository(userList, serializerString, path);
                    break;
                }
                else
                {
                    listPos++;
                }
            }
            return userNumber;
        }
    }
}
