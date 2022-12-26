using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleWebApplication.ProfilData;

namespace LittleWebApplication.Users
{
    public class PrivatUserDummy
    {
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
    }
}
