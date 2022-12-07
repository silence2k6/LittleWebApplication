using LittleWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LittleWebApplication
{
    public class UserProfil
    {
        //public static PrivatUserDummy newPrivatUser = new()
        //{

        //}
        
        
        //private AdressInformations newAdress = new AdressInformations();
        //private LoginInformations newLogin = new LoginInformations();
        //private NameInformations newName = new NameInformations();
        //private ContactInformations newContact = new ContactInformations();
        //private AccountInformations newAccount = new AccountInformations();
    }

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
        public string userTel;
        public string userMail;
    }

    public class LoginInformations
    {
        public string userNumber;
        public string userLoginPasswort;
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

    public class AccountInformations
    {
        string userAccountCreationDate;
        string accountStatus;
    }

    public string CreateUserNumber(int userNumberCounter, Enum.UserType artOfUser)
    {
        XmlSerializer serializerString = new(typeof(List<string>));
        XmlSerializer serializerInt = new(typeof(List<int>));

        string privatUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\privatUserNumberList.xml";
        string businessUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\businessUserNumberList.xml";
        string serviceUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\serviceUserNumberList.xml";
        string adminUserListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\adminUserNumberList.xml";

        List<string> privatUserNumberList = new();
        List<string> businessUserNumberList = new();
        List<string> serviceUserNumberList = new();
        List<string> adminUserNumberList = new();

        privatUserNumberList = Backup.stringListRepository(privatUserNumberList, serializerString, privatUserListPath);
        businessUserNumberList = Backup.stringListRepository(privatUserNumberList, serializerString, businessUserListPath);
        serviceUserNumberList = Backup.stringListRepository(privatUserNumberList, serializerString, serviceUserListPath);
        adminUserNumberList = Backup.stringListRepository(privatUserNumberList, serializerString, adminUserListPath);

        int listPos = 0;
        string userPreNumber = "";
        string userNumberPlaceholder = "";
        string userNumber = "";
        List<string> userNumberList = new();
        string path = "";

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

        string UserNumberPlaceholder()
        {
            if (userNumberCounter < 10)
            {
                userNumberPlaceholder = "0000";
            }
            if (userNumberCounter > 10 && userNumberCounter < 100)
            {
                userNumberPlaceholder = "000";
            }
            if (userNumberCounter > 100 && userNumberCounter < 1000)
            {
                userNumberPlaceholder = "00";
            }
            if (userNumberCounter > 1000 && userNumberCounter < 10000)
            {
                userNumberPlaceholder = "0";
            }
            return userNumberPlaceholder;
        }
        userNumberPlaceholder = UserNumberPlaceholder();

        List<string> UserNumber()
        {
            if (artOfUser == Enum.UserType.privatUser)
            {
                userNumberList = privatUserNumberList;
                path = privatUserListPath;
            }
            if (artOfUser == Enum.UserType.businessUser)
            {
                userNumberList = businessUserNumberList;
                path = businessUserListPath;
            }
            if (artOfUser == Enum.UserType.serviceUser)
            {
                userNumberList = serviceUserNumberList;
                path = serviceUserListPath;
            }
            if (artOfUser == Enum.UserType.adminUser)
            {
                userNumberList = adminUserNumberList;
                path = adminUserListPath;
            }
            return userNumberList;
        }
        userNumberList = UserNumber();

        while (listPos <= userNumberList.Count)
        {
            if (userNumberList[listPos] == "unused")
            {
                userNumber = $"{userPreNumber}{userNumberPlaceholder}{userNumberCounter}";
                userNumberList[listPos] = userNumber;
                userNumberCounter++;
                Backup.stringListRepository(userNumberList, serializerString, path);
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
