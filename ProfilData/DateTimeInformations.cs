namespace LittleWebApplication.ProfilData
{
    internal class DateTimeInformations
    {
        string donationDate;
        string donationTime;

        public override string ToString()
        {
            return $"{donationDate}\n{donationTime}";
        }
    }
}
