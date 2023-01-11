using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    public class BankAccountInformations
    {
        public string bankAccoungIBAN;
        public string bankAccountInstitut;
        public string bankAccountOwner;

        public override string ToString()
        {
            return $"{bankAccoungIBAN}\n{bankAccountInstitut}\n{bankAccountOwner}";
        }
    }
}
