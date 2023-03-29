using LittleWebApplication.ProfilData;

namespace LittleWebApplication
{
    public class Fundraiser
    {
        public int fundraiserNumber;
        public CompanyInformations fundraiserCompany;
        public AdressInformations fundraiserAdress;
        public BankAccountInformations fundraiserBankAccount;

        /// <summary>
        /// method creates new fundraiser object
        /// </summary>
        /// <param name="fundraiserList">list with all existing fundraiser</param>
        /// <param name="artOfAccount">art of account</param>
        /// <returns>new fundraiser (object)</returns>
        public static Fundraiser CreateFundraiser(List<Fundraiser> fundraiserList, Enums.AccountType artOfAccount)
        {
            int listNumber = fundraiserList.Count + 1;

            Fundraiser fundraiser = new();
            fundraiser.fundraiserNumber = CreateFundraiserNumber();
            fundraiser.fundraiserCompany = UImethods.AskForCompanyInformations(artOfAccount);
            fundraiser.fundraiserAdress = UImethods.AskForUserAdressInformations();
            fundraiser.fundraiserBankAccount = UImethods.AskForBankAccountInformations();

            return fundraiser;
        }

        /// <summary>
        /// method creates new fundraiser number
        /// </summary>
        /// <returns>fundraiser number (int)</returns>
        public static int CreateFundraiserNumber()
        {
            List<Fundraiser> fundraiserList = Backup.LoadFundraiserRepository();

            int listNumber = fundraiserList.Count + 1;
            int fundraiserNumber = Convert.ToInt32(listNumber.ToString("D6"));
            return fundraiserNumber;
        }
    }
}
