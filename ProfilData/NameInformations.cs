namespace LittleWebApplication.ProfilData
{
    public class NameInformations
    {
        public string userFirstName;
        public string userLastName;

        public override string ToString()
        {
            return $"{userFirstName} {userLastName}";
        }
    }
}
