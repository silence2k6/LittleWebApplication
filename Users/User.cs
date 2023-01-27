using LittleWebApplication.ProfilData;

namespace LittleWebApplication.Users
{
    public class User
    {
        public string userNumber;
        public DateTime joinDateTime;
        public NameInformations userName;
        public AdressInformations userAdress;
        public ContactInformations userContact;
        public CompanyInformations userCompany;
        public BankAccountInformations userBankAccount;
        public LoginInformations userLogin;
        public Enums.Status accountStatus;
        public static Random randomGenerator = new();

        public static User CreateSuperAdmin()
        {
            NameInformations userName = new();
            userName.userFirstName = "Robert";
            userName.userLastName = "Leithner";

            AdressInformations userAdress = new();
            userAdress.userAdressStreet = "Hauptstraße";
            userAdress.userAdressNumber = "32";
            userAdress.userAdressPostalCode = "2125";
            userAdress.userAdressTown = "Neubau";
            userAdress.userAdressFederalState = "Niederösterreich";

            LoginInformations userLogin = new();
            userLogin.userLoginNumber = "A000001";
            userLogin.userLoginPassword = "0000";

            User newSuperAdmin = new User();
            newSuperAdmin.userName = userName;
            newSuperAdmin.userAdress = userAdress;
            newSuperAdmin.userLogin = userLogin;
            newSuperAdmin.userNumber = "A#000001";
            newSuperAdmin.joinDateTime = DateTime.Now;
            newSuperAdmin.accountStatus = Enums.Status.active;

            return newSuperAdmin;
        }

        public static string CreateUserNumber(Enums.AccountType artOfAccount, string accountNumber)
        {
            string userPreNumber = "";

            if (artOfAccount == Enums.AccountType.privateUser)
            {
                userPreNumber = "P#";
            }
            if (artOfAccount == Enums.AccountType.businessUser)
            {
                userPreNumber = "B#";
            }
            if (artOfAccount == Enums.AccountType.serviceUser)
            {
                userPreNumber = "S#";
            }
            if (artOfAccount == Enums.AccountType.adminUser)
            {
                userPreNumber = "A#";
            }
           
            string userNumber = $"{userPreNumber}{accountNumber}";
            return userNumber;
        }

        public static NameInformations CreatePrivateUserDummyName()
        {
            int randomFirstNameIndex = randomGenerator.Next(PrivateUserDummy.firstNameDummyList.Count);
            int randomLastNameIndex = randomGenerator.Next(PrivateUserDummy.lastNameDummyList.Count);

            NameInformations userName = new()
            {
                userFirstName = PrivateUserDummy.firstNameDummyList[randomFirstNameIndex],
                userLastName = PrivateUserDummy.lastNameDummyList[randomLastNameIndex]
            };

            return userName;
        }

        public static AdressInformations CreatePrivateUserDummyAdress()
        {
            int randomAdressStreetIndex = randomGenerator.Next(PrivateUserDummy.adressStreetDummyList.Count);
            int randomAdressNumberIndex = randomGenerator.Next(PrivateUserDummy.adressNumberDummyList.Count);
            int randomAdressPostalCodeIndex = randomGenerator.Next(PrivateUserDummy.adressPostalCodeDummyList.Count);
            int randomAdressTownIndex = randomGenerator.Next(PrivateUserDummy.adressTownDummyList.Count);
            int randomAdressFederalStateIndex = randomGenerator.Next(PrivateUserDummy.adressFederalStateDummyList.Count);

            AdressInformations userAdress = new();
            userAdress.userAdressStreet = PrivateUserDummy.adressStreetDummyList[randomAdressStreetIndex];
            userAdress.userAdressNumber = PrivateUserDummy.adressNumberDummyList[randomAdressNumberIndex];
            userAdress.userAdressPostalCode = PrivateUserDummy.adressPostalCodeDummyList[randomAdressPostalCodeIndex];
            userAdress.userAdressTown = PrivateUserDummy.adressTownDummyList[randomAdressTownIndex];
            userAdress.userAdressFederalState = PrivateUserDummy.adressFederalStateDummyList[randomAdressFederalStateIndex];

            return userAdress;
        }
        public static ContactInformations CreatePrivateUserDummyContact(NameInformations userName)
        {
            int countryPraefixIndex = randomGenerator.Next(PrivateUserDummy.countryPraefixDummyList.Count);
            string countryPraefix = PrivateUserDummy.countryPraefixDummyList[countryPraefixIndex];

            int telProviderIndex = randomGenerator.Next(PrivateUserDummy.telProviderDummyList.Count);
            string telProvider = PrivateUserDummy.telProviderDummyList[telProviderIndex];

            int[] randomTelNumbers = new int[7];
            for (int numberPos = 0; numberPos < randomTelNumbers.Length; numberPos++)
            {
                randomTelNumbers[numberPos] = randomGenerator.Next(0, 9);
            }
            string randomTel = String.Join("", randomTelNumbers);

            string userTel = $"{countryPraefix}/{telProvider}/{randomTel}";

            string mailLocalPart1 = userName.userFirstName;
            string mailLocalPart2 = userName.userLastName;

            int randomMailDomainIndex = randomGenerator.Next(PrivateUserDummy.domainProviderDummyList.Count);
            string randomMailDomain = PrivateUserDummy.domainProviderDummyList[randomMailDomainIndex];

            string userMail = $"{mailLocalPart1}.{mailLocalPart2}@{randomMailDomain}";

            ContactInformations userContact = new()
            {
                userContactTel = userTel,
                userContactMail = userMail
            };

            return userContact;
        }

        public static LoginInformations CreatePrivateUserDummyLogin(string accountNumber)
        {
            LoginInformations userLogin = new()
            {
                userLoginNumber = "P" + accountNumber,
                userLoginPassword = "0000"
            };

            return userLogin;
        }

        public static User CreatePrivateUserDummy(string accountNumber)
        {
            User newPrivatUserDummy = new();
            List<Account> accountList = Backup.LoadAccountRepository();
            newPrivatUserDummy.userNumber = CreateUserNumber(Enums.AccountType.privateUser, accountNumber);
            newPrivatUserDummy.userName = CreatePrivateUserDummyName();
            newPrivatUserDummy.userAdress = CreatePrivateUserDummyAdress();
            newPrivatUserDummy.userContact = CreatePrivateUserDummyContact(newPrivatUserDummy.userName);
            newPrivatUserDummy.userLogin = CreatePrivateUserDummyLogin(accountNumber);
            newPrivatUserDummy.joinDateTime = DateTime.Now;
            newPrivatUserDummy.accountStatus = Account.CheckAccountStatus(newPrivatUserDummy, accountList);

            return newPrivatUserDummy;
        }

        public static User CreateBusinessUser(Enums.AccountType artOfAccount, string accountNumber)
        {
            User newBusinessUser = new();
            List<Account> accountList = Backup.LoadAccountRepository();
            newBusinessUser.joinDateTime = DateTime.Now;
            newBusinessUser.userNumber = CreateUserNumber(Enums.AccountType.businessUser, accountNumber);
            newBusinessUser.userCompany = UImethods.AskForCompanyInformations(artOfAccount);
            newBusinessUser.userAdress = UImethods.AskForAdressInformations();
            newBusinessUser.userLogin.userLoginNumber = "B" + accountNumber;
            newBusinessUser.userLogin.userLoginPassword = UImethods.CreateUserPassword();
            newBusinessUser.accountStatus = Account.CheckAccountStatus(newBusinessUser, accountList);


            return newBusinessUser;
        }

        public static User CreateServiceUser(string accountNumber)
        {
            User newServiceUser = new();
            List<Account> accountList = Backup.LoadAccountRepository();
            newServiceUser.joinDateTime = DateTime.Now;
            newServiceUser.userNumber = CreateUserNumber(Enums.AccountType.businessUser, accountNumber);
            newServiceUser.userAdress = UImethods.AskForAdressInformations();
            newServiceUser.userLogin.userLoginNumber = "B" + accountNumber;
            newServiceUser.userLogin.userLoginPassword = UImethods.CreateUserPassword();
            newServiceUser.accountStatus = Account.CheckAccountStatus(newServiceUser, accountList);

            return newServiceUser;
        }


        public static User CreateAdminUser(Enums.AccountType artOfAccount, string accountNumber)
        {
            User newAdminUser = new();
            newAdminUser.userNumber = CreateUserNumber(Enums.AccountType.adminUser, accountNumber);
            newAdminUser.userName = UImethods.AskForNameInformations();
            newAdminUser.userLogin.userLoginNumber = "A" + accountNumber;
            newAdminUser.userLogin.userLoginPassword = UImethods.CreateUserPassword();

            return newAdminUser;
        }
    }
}
