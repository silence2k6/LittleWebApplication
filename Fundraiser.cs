using LittleWebApplication;
using LittleWebApplication.ProfilData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    public class Fundraiser
    {
        public string fundraiserNumber;
        public CompanyInformations fundraiserCompany;
        public AdressInformations fundraiserAdress;
        public BankAccountInformations fundraiserBankAccount;
        
        public static Fundraiser CreateFundraiser(List<Fundraiser> fundraiserList, Enums.AccountType artOfAccount)
        {
            int listNumber = fundraiserList.Count + 1;

            Fundraiser fundraiser = new();
            fundraiser.fundraiserNumber = "F#" + listNumber.ToString("D6");
            fundraiser.fundraiserCompany = UImethods.AskForCompanyInformations(artOfAccount);
            fundraiser.fundraiserAdress = UImethods.AskForAdressInformations();
            fundraiser.fundraiserBankAccount = UImethods.AskForBankAccountInformations();

            return fundraiser;
        }
    }
}
