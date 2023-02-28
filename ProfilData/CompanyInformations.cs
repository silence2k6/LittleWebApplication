namespace LittleWebApplication.ProfilData
{
    public class CompanyInformations
    {
        public string companyName;
        public NameInformations contactPersonName;
        public string contactPersonFunction;
        public string contactPersonTel;
        public string contactPersonMail;

        public override string ToString()
        {
            return $"{companyName}\nKontaktperson:\t{contactPersonName}\n\t\t{contactPersonFunction}\n\t\t{contactPersonTel}\n\t\t{contactPersonMail}";
        }
    }
}
