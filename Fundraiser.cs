using LittleWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    internal class Fundraiser
    {
        private string userNumber;
	    private CompanyInformations newFundraiser = new CompanyInformations();
        private AdressInformations newAdress = new AdressInformations();
        private BankAccountInformations newBankAccount = new BankAccountInformations();
        private List<Terminal> fundraiserTerminalList = new List<Terminal>();
        private List<Payment> fundraiserPaymentList = new List<Payment>();
    }
    public class Payment
    {
        doc paymentConfirmation;
        private DateTime paymentConfirmationDateTime = new DateTime();
    }

}
