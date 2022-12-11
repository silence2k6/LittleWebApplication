using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LittleWebApplication.ProfilData;
using static LittleWebApplication.Enum;

namespace LittleWebApplication
{
    public class PrivatUserDummy
    {
        public static Random randomGenerator = new();

        public static List<string> adressStreetDummyList = new()
        {
            "Antonstraße",
            "Bertaweg",
            "Cesarallee",
            "Doraplatz",
            "Emilsiedlung",
            "Friedrichstraße",
            "Gustavweg",
            "Heinrichallee",
            "Idaplatz",
            "Johannsiedlung",
            "Konradstraße",
            "Ludwigweg",
            "Martaallee",
            "Nordpolplatz",
            "Ottosiedlung",
            "Paulastraße",
            "Quallenweg",
            "Richardallee",
            "Siegfriedplatz",
            "Theodorsiedlung"
        };

        public static List<string> adressNumberDummyList = new()
        {
            "1a", "1b", "1c", "1d", "1e", "1f", "1g", "1h", "1i", "1j", "1k", "1l", "1m", "1n", "1o", "1p", "1q", "1r", "1s", "1t"
        };

        public static List<string> adressTownDummyList = new()
        {
            "Antonstadt",
            "Bertastadt",
            "Cesarstadt",
            "Emilstadt",
            "Gustavstadt",
            "Heinrichstadt",
            "Idastadt",
            "Johannstadt",
            "Konradstadt",
            "Ludwigstadt",
            "Martastadt",
            "Nordpolstadt",
            "Ottostadt",
            "Paulastadt",
            "Quellenstadt",
            "Richardstadt",
            "Siegfriedstadt",
            "Theodorstadt"
        };

        public static List<string> adressFederalStateDummyList = new()
        {
            "Wien",
            "Niederösterreich",
            "Oberösterreich",
            "Salzburg",
            "Tirol",
            "Vorarlberg",
            "Kärnten",
            "Steiermark",
            "Burgenland"
        };
        public static AdressInformations CreateAdress()
        {
            int randomAdressStreetIndex = randomGenerator.Next(adressStreetDummyList.Count);
            int randomAdressNumberIndex = randomGenerator.Next(adressNumberDummyList.Count);
            int randomAdressTownIndex = randomGenerator.Next(adressTownDummyList.Count);
            int randomAdressFederalStateIndex = randomGenerator.Next(adressFederalStateDummyList.Count);

            AdressInformations userAdress = new()
            {
                userAdressStreet = adressStreetDummyList[randomAdressStreetIndex],
                userAdressNumber = adressNumberDummyList[randomAdressNumberIndex],
                userAdressTown = adressTownDummyList[randomAdressTownIndex],
                userAdressFederalState = adressFederalStateDummyList[randomAdressFederalStateIndex]
            };

            return userAdress;
        }

        public static List<string> firstNameDummyList = new()
        {
            "Anton",
            "Berta",
            "Cesar",
            "Dora",
            "Emil",
            "Friedrich",
            "Gustav",
            "Heinrich",
            "Ida",
            "Johann",
            "Konrad",
            "Ludwig",
            "Marta",
            "Norbert",
            "Otto",
            "Paula",
            "Quentin",
            "Richard",
            "Siegfried",
            "Theodor"
        };

        public static List<string> lastNameDummyList = new()
        {
            "Antoner",
            "Bertaner",
            "Cesarner",
            "Doraner",
            "Emilner",
            "Friedrichner",
            "Gustavner",
            "Heinrichner",
            "Idaner",
            "Johanner",
            "Konradner",
            "Ludwigner",
            "Martaner",
            "Norbertner",
            "Ottoner",
            "Paulaner",
            "Quentiner",
            "Richardner",
            "Siegfriedner",
            "Theodorner"
        };

        public static NameInformations CreateName()
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

        public static ContactInformations CreateContact(NameInformations userName)
        {
            ContactInformations userContact = new();
            userContact.userContactMail = CreateMail(userName);
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

            static string CreateMail(NameInformations userName)
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

        //public static LoginInformations CreateLogin()
        //{
        //    static string CreatePasswod()
        //    {
        //        string userPasswort = "0000";

        //        return userPasswort;
        //    }
        //}

        public static PrivatUserDummy CreateNewPrivatUserDummy()
        {
            NameInformations newUserName = CreateName();
            AdressInformations newUserAdress = CreateAdress();
            ContactInformations newUserContact = CreateContact(newUserName);
            LoginInformations newUserLogin = new()
            {
                userLoginNumber = CreateUserNumber(UserType.privatUser),
                userLoginPasswort = "0000"
            };
        }
    }
}
