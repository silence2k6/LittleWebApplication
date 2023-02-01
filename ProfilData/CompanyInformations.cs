namespace LittleWebApplication.ProfilData
{
    public class CompanyInformations
    {
        public string companyName;
        public string contactPersonFirstname;
        public string contactPersonFamilyname;
        public string contactPersonFunction;
        public string contactPersonTel;
        public string contactPersonMail;

        public override string ToString()
        {
            return $"{companyName}\nKontaktperson:\t{contactPersonFirstname} {contactPersonFamilyname}\n\t\t{contactPersonFunction}\n\t\t{contactPersonTel}\n\t\t{contactPersonMail}";
        }
    }
}
