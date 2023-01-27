namespace LittleWebApplication
{
    public class Donation
    {
        DateTime donationDateTime;
        string terminalNumber;
        string userNumber;
        double donationAmmount;
        public static Random randomGenerator = new();


        //public static Donation CreateDummyDonation(List<TerminalInformations> terminalList)
        //{
        //    int randomTerminalIndex = randomGenerator.Next(terminalList.Count);
        //    TerminalInformations donationTerminal = terminalList[randomTerminalIndex];

        //    Donation userDonation = new();
        //    userDonation.donationDateTime = DateTime.Now;
        //    userDonation.terminalNumber = //donationTerminal.terminalNumber
        //}
    }
}
