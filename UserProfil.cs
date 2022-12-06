using LittleWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    public class UserProfil
    {
        private AdressInformations newAdress = new AdressInformations();
        private LoginInformations newLogin = new LoginInformations();
        private NameInformations newName = new NameInformations();
        private ContactInformations newContact = new ContactInformations();
        private AccountInformations newAccount = new AccountInformations();
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

}
