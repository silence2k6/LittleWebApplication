using LittleWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Web_Application
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
        string userAdressStreet;
        string userAdressNumber;
        string userAdressTown;
        string userAdressFederalState;
    }

    public class LoginInformations
    {
        string userLoginName;
        string userLoginPasswort;
    }

    public class NameInformations
    {
        string userFirstname;
        string userFamiliename;
    }

    public class ContactInformations
    {
        string userTel;
        string userMail;
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
