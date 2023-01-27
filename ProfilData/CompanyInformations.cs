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
            return $"{companyName}\n{contactPersonFirstname} {contactPersonFamilyname}\n{contactPersonFunction}\n{contactPersonTel}";
        }
    }
}
