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
        
        public static Fundraiser CreateNewFundraiser(List<Fundraiser> fundraiserList)
        {
            int listNumber = fundraiserList.Count + 1;

            CompanyInformations newFundraiserCompany = new();
            Console.WriteLine("Name Spendenorganisation:\t");
            newFundraiserCompany.companyName = Console.ReadLine();
            Console.WriteLine("Kontaktperson Vorname:\t");
            newFundraiserCompany.contactPersonFirstname = Console.ReadLine();
            Console.WriteLine("Kontaktperson Familienname:\t");
            newFundraiserCompany.contactPersonFamilyname = Console.ReadLine();
            Console.WriteLine("Kontaktperson Firmenfunktion:\t");
            newFundraiserCompany.contactPersonFunction = Console.ReadLine();
            Console.WriteLine("Kontaktperson Telefonnummer:\t");
            newFundraiserCompany.contactPersonTel = Console.ReadLine();
            Console.WriteLine("Kontaktperson Email-Adresse:\t");
            newFundraiserCompany.contactPersonMail = Console.ReadLine();

            AdressInformations newFundraiserAdress = new();
            //set adress informations

            BankAccountInformations newFundraiserBankAccount = new();
            //set bankaccount informations

            Fundraiser fundraiser = new();
            fundraiser.fundraiserNumber = "F#" + listNumber.ToString("D6");
            fundraiser.fundraiserCompany = newFundraiserCompany;

    
        }
    }
}
