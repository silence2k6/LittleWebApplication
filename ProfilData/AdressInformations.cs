using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    public class AdressInformations
    {
        public string userAdressStreet;
        public string userAdressNumber;
        public string userAdressTown;
        public string userAdressFederalState;

        public override string ToString()
        {
            return $"{userAdressStreet} {userAdressNumber}\n\t\t{userAdressTown}\n\t\t{userAdressFederalState}";
        }
    }
}
