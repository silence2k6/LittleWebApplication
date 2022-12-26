using LittleWebApplication.ProfilData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static LittleWebApplication.Enums;

namespace LittleWebApplication.Users
{
    internal class CreateUser
    {
        public static Random randomGenerator = new();

        public int AccountNumber()
        {
            int latestAccountIndex = accountInformationList.Count;
            AccountInformations latestAccount = accountInformationList[latestAccountIndex];
            int accountNumber = latestAccount.accountNumber + 1;
            return accountNumber;
        }
        public static string CreateUserNumber(Enums.UserType artOfUser)
        {
            XmlSerializer serializer = new(typeof(List<AccountInformations>));
            string accountInformationListPath = @"C:\Users\user\source\repos\LittleWebApplication\Backup\accountInformationList.xml";

            List<AccountInformations> accountInformationList = new();

            accountInformationList = Backup.AccountListRepository(accountInformationList, serializer, accountInformationListPath);

            string userPreNumber = "";
            string userNumberPlaceholder = "";
            int accountNumber = AccountNumber();

            string UserPreNumber()
            {
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

        public static NameInformations CreatePrivatUserDummyName()
        {
            int randomFirstNameIndex = randomGenerator.Next(firstNameDummyList.Count);
            int randomLastNameIndex = randomGenerator.Next(lastNameDummyList.Count);

            NameInformations userName = new()
            {
                userFirstName = firstNameDummyList[randomFirstNameIndex],
                userLastName = lastNameDummyList[randomLastNameIndex]
            };
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

        //public static LoginInformations CreatePrivatUserDummyLogin()
        //{
        //    static string CreatePasswod()
        //    {
        //        string userPasswort = "0000";

        //        return userPasswort;
        //    }
        //}

        //public static PrivatUserDummy CreateNewPrivatUserDummy()
        //{
        //    NameInformations newUserName = CreatePrivatUserDummyName();
        //    AdressInformations newUserAdress = CreateAdress();
        //    ContactInformations newUserContact = CreatePrivatUserDummyContact(newUserName);
        //    LoginInformations newUserLogin = new()
        //    {
        //        userLoginNumber = CreateUserNumber(UserType.privatUser),
        //        userLoginPasswort = "0000"
        //    };
        //}
    }
}
