using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    public class BankAccountInformations
    {
        string bankAccoungIBAN;
        string bankAccountInstitut;
        string bankAccountOwner;

        public override string ToString()
        {
            return $"{bankAccoungIBAN}\n{bankAccountInstitut}\n{bankAccountOwner}";
        }
    }
}
