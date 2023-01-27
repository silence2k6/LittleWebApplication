namespace LittleWebApplication.ProfilData
{
    public class ContactInformations
    {
        public string userContactTel;
        public string userContactMail;

        public override string ToString()
        {
            return $"{userContactTel}\n{userContactMail}";
        }
    }
}
