using LittleWebApplication.ProfilData;

namespace LittleWebApplication
{
    public class Fundraiser
    {
        public string fundraiserNumber;
        public CompanyInformations fundraiserCompany;
        public AdressInformations fundraiserAdress;
        public BankAccountInformations fundraiserBankAccount;

        public static int CreateFundraiserNumber()
        {
            List<Fundraiser> fundraiserList = Backup.LoadFundraiserRepository();

            int listNumber = fundraiserList.Count + 1;
            int fundraiserNumber = Convert.ToInt32(listNumber.ToString("D6"));
            return fundraiserNumber;
        }

        public static Fundraiser CreateFundraiser(List<Fundraiser> fundraiserList, Enums.AccountType artOfAccount)
        {
            int listNumber = fundraiserList.Count + 1;

            Fundraiser fundraiser = new();
            fundraiser.fundraiserNumber = "F#" + CreateFundraiserNumber();
            fundraiser.fundraiserCompany = UImethods.AskForCompanyInformations(artOfAccount);
            fundraiser.fundraiserAdress = UImethods.AskForUserAdressInformations();
            fundraiser.fundraiserBankAccount = UImethods.AskForBankAccountInformations();

            return fundraiser;
        }
    }
}
