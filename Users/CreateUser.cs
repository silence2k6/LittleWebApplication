using LittleWebApplication.Accounts;
using LittleWebApplication.ProfilData;

namespace LittleWebApplication.Users
{
    public class CreateUser
    {
        public AccountInformations userAccount;
        public string userNumber;
        public NameInformations userName;
        public AdressInformations userAdress;
        public ContactInformations userContact;
        public LoginInformations userLogin;
        public static Random randomGenerator = new();


        public static string CreateAccountNumber(List<AccountInformations> accountList)
        {
            int listNumber = accountList.Count + 1;
            string accountNumber = listNumber.ToString("D6");
            return accountNumber;
        }
        public static string CreateUserNumber(Enums.UserType artOfUser, string accountNumber)
        {
            string userPreNumber = "";

            if (artOfUser == Enums.UserType.privateUser)
            {
                userPreNumber = "P#";
            }
            if (artOfUser == Enums.UserType.businessUser)
            {
                userPreNumber = "B#";
            }
            if (artOfUser == Enums.UserType.serviceUser)
            {
                userPreNumber = "S#";
            }
            if (artOfUser == Enums.UserType.adminUser)
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
            int randomAdressTownIndex = randomGenerator.Next(PrivateUserDummy.adressTownDummyList.Count);
            int randomAdressFederalStateIndex = randomGenerator.Next(PrivateUserDummy.adressFederalStateDummyList.Count);

            AdressInformations userAdress = new();
            userAdress.userAdressStreet = PrivateUserDummy.adressStreetDummyList[randomAdressStreetIndex];
            userAdress.userAdressNumber = PrivateUserDummy.adressNumberDummyList[randomAdressNumberIndex];
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

        public static CreateUser CreatePrivateUserDummy(string accountNumber)
        {
            CreateUser privatUserDummy = new();
            privatUserDummy.userName = CreateUser.CreatePrivateUserDummyName();
            privatUserDummy.userAdress = CreateUser.CreatePrivateUserDummyAdress();
            privatUserDummy.userContact = CreateUser.CreatePrivateUserDummyContact(privatUserDummy.userName);
            privatUserDummy.userLogin = CreateUser.CreatePrivateUserDummyLogin(accountNumber);
            privatUserDummy.userNumber = CreateUser.CreateUserNumber(Enums.UserType.privateUser, accountNumber);

            return privatUserDummy;
        }
    }
}
