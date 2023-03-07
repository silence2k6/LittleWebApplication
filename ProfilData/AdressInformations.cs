namespace LittleWebApplication.ProfilData
{
    public class AdressInformations
    {
        public string userAdressStreet;
        public string userAdressNumber;
        public string userAdressPostalCode;
        public string userAdressTown;
        public string userAdressFederalState;
        public string terminalAdress;
        public string terminalAdressExtraText;
        public string terminalAdressLocation;


        public override string ToString()
        {
            return $"{userAdressStreet} {userAdressNumber}\n\t\t{userAdressPostalCode} {userAdressTown}\n\t\t{userAdressFederalState}";
        }
    }
}
