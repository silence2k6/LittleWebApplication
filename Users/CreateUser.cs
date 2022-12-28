
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LittleWebApplication.Accounts;
using LittleWebApplication.ProfilData;
using LittleWebApplication.Users;

namespace LittleWebApplication.Users
{
    public class CreateUser
    {
        public AccountInformations userAccount;
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

            NameInformations userName = new();
            userName.userFirstName = PrivatUserDummy.firstNameDummyList[randomFirstNameIndex];
            userName.userLastName = PrivatUserDummy.lastNameDummyList[randomLastNameIndex];

            return userName;
        }

        public static ContactInformations CreatePrivatUserDummyContact(NameInformations userName)
        {
            ContactInformations userContact = new();
            userContact.userContactMail = CreatePrivatUserDummyMail(userName);
            userContact.userContactTel = CreateTel();

            static string CreateTel()
            {
                string praefix = "+43";
                List<string> areaCodeList = new()
            {
                "0650", "0660", "0676", "0664", "0688", "0699"
            };
                int[] randomTelNumbers = new int[7];
                for (int i = 0; i < randomTelNumbers.Length; i++)
                {
                    randomTelNumbers[i] = randomGenerator.Next(0, 9);
                }

                string userTel = $"{praefix}{areaCodeList}{randomTelNumbers}";

                return userTel;
            }

            static string CreatePrivatUserDummyMail(NameInformations userName)
            {
                string localPart1;
                string localPart2;
                List<string> domainList = new()
                {
                    "gmail.com", "gmx.at", "chello.at", "a1.at", "yahoo.com"
                };

                localPart1 = userName.userFirstName;
                localPart2 = userName.userLastName;

                int randomMailDomainIndex = randomGenerator.Next(domainList.Count);
                string randomMailDomain = domainList[randomMailDomainIndex];


                string userMail = $"{localPart1}.{localPart2}@{randomMailDomain}";

                return userMail;
            }
            return userContact;
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

        public static LoginInformations CreatePrivatUserDummyLogin(string userNumber)
        {
            LoginInformations userLogin = new();
            userLogin.userLoginNumber = userNumber;
            userLogin.userLoginPassword = "0000";

            return userLogin;
        }
    }
}
