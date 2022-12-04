﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    internal class PrivatUserDummy
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

        public List<string> adressNumberDummyList = new()
        {
            "1a", "1b", "1c", "1d", "1e", "1f", "1g", "1h", "1i", "1j", "1k", "1l", "1m", "1n", "1o", "1p", "1q", "1r", "1s", "1t"
        };

        public List<string> adressTownDummyList = new()
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

        public List<string> adressFederalStateDummyList = new()
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
        public static List<AdressInformations> createAdress(List<AdressInformations> AdressRepository)
        {
            int randomAdressStreetIndex = randomGenerator.Next(adressStreetDummyList.Count);
            int randomAdressNumberIndex = randomGenerator.Next(adressStreetDummyList.Count);
            int randomAdressTownIndex = randomGenerator.Next(adressStreetDummyList.Count);
            int randomAdressFederalStateIndex = randomGenerator.Next(adressStreetDummyList.Count);

            AdressInformations newAdress = new();
            newAdress.userAdressStreet = adressStreetDummyList[randomAdressStreetIndex];
            newAdress.userAdressNumber = adressStreetDummyList[randomAdressNumberIndex];
            newAdress.userAdressTown = adressStreetDummyList[randomAdressTownIndex];
            newAdress.userAdressFederalState = adressStreetDummyList[randomAdressFederalStateIndex];

            AdressRepository.Add(newAdress);

            return AdressRepository;
        }
    }
}
