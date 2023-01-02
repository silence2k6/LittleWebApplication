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


        public static int CreateAccountNumber(List<AccountInformations> accountList)
        {
            int accountNumber = accountList.Count + 1;
            return accountNumber;
        }
        public static string CreateUserNumber(Enums.UserType artOfUser, int accountNumber)
        {
            string userPreNumber = "";

            if (artOfUser == Enums.UserType.privatUser)
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

            string userNumberPlaceholder = accountNumber.ToString("D6");
            
            string userNumber = $"{userPreNumber}{userNumberPlaceholder}";
            return userNumber;
        }

        public static NameInformations CreatePrivatUserDummyName()
        {
            int randomFirstNameIndex = randomGenerator.Next(PrivatUserDummy.firstNameDummyList.Count);
            int randomLastNameIndex = randomGenerator.Next(PrivatUserDummy.lastNameDummyList.Count);

            NameInformations userName = new()
            {
                userFirstName = PrivatUserDummy.firstNameDummyList[randomFirstNameIndex],
                userLastName = PrivatUserDummy.lastNameDummyList[randomLastNameIndex]
            };

            return userName;
        }

        public static AdressInformations CreatePrivatUserDummyAdress()
        {
            int randomAdressStreetIndex = randomGenerator.Next(PrivatUserDummy.adressStreetDummyList.Count);
            int randomAdressNumberIndex = randomGenerator.Next(PrivatUserDummy.adressNumberDummyList.Count);
            int randomAdressTownIndex = randomGenerator.Next(PrivatUserDummy.adressTownDummyList.Count);
            int randomAdressFederalStateIndex = randomGenerator.Next(PrivatUserDummy.adressFederalStateDummyList.Count);

            AdressInformations userAdress = new();
            userAdress.userAdressStreet = PrivatUserDummy.adressStreetDummyList[randomAdressStreetIndex];
            userAdress.userAdressNumber = PrivatUserDummy.adressNumberDummyList[randomAdressNumberIndex];
            userAdress.userAdressTown = PrivatUserDummy.adressTownDummyList[randomAdressTownIndex];
            userAdress.userAdressFederalState = PrivatUserDummy.adressFederalStateDummyList[randomAdressFederalStateIndex];

            return userAdress;
        }
        public static ContactInformations CreatePrivatUserDummyContact(NameInformations userName)
        {
            int countryPraefixIndex = randomGenerator.Next(PrivatUserDummy.countryPraefixDummyList.Count);
            string countryPraefix = PrivatUserDummy.countryPraefixDummyList[countryPraefixIndex];

            int telProviderIndex = randomGenerator.Next(PrivatUserDummy.telProviderDummyList.Count);
            string telProvider = PrivatUserDummy.telProviderDummyList[telProviderIndex];

            int[] randomTelNumbers = new int[7];
            for (int numberPos = 0; numberPos < randomTelNumbers.Length; numberPos++)
            {
                randomTelNumbers[numberPos] = randomGenerator.Next(0, 9);
            }
            string randomTel = String.Join("", randomTelNumbers);

            string userTel = $"{countryPraefix}/{telProvider}/{randomTel}";

            string mailLocalPart1 = userName.userFirstName;
            string mailLocalPart2 = userName.userLastName;

            int randomMailDomainIndex = randomGenerator.Next(PrivatUserDummy.domainProviderDummyList.Count);
            string randomMailDomain = PrivatUserDummy.domainProviderDummyList[randomMailDomainIndex];

            string userMail = $"{mailLocalPart1}.{mailLocalPart2}@{randomMailDomain}";

            ContactInformations userContact = new()
            {
                userContactTel = userTel,
                userContactMail = userMail
            };

            return userContact;
        }

        public static LoginInformations CreatePrivatUserDummyLogin(string userNumber)
        {
            LoginInformations userLogin = new()
            {
                userLoginNumber = userNumber,
                userLoginPassword = "0000"
            };

            return userLogin;
        }

        public static CreateUser CreatePrivatUserDummy(string userNumber)
        {
            CreateUser privatUserDummy = new();
            privatUserDummy.userName = CreateUser.CreatePrivatUserDummyName();
            privatUserDummy.userAdress = CreateUser.CreatePrivatUserDummyAdress();
            privatUserDummy.userContact = CreateUser.CreatePrivatUserDummyContact(privatUserDummy.userName);
            privatUserDummy.userLogin = CreateUser.CreatePrivatUserDummyLogin(userNumber);
            privatUserDummy.userNumber = privatUserDummy.userLogin.userLoginNumber;

            return privatUserDummy;
        }
    }
}
