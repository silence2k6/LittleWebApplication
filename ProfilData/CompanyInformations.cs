using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    public class CompanyInformations
    {
        string companyName;
        string contactPersonFirstname;
        string contactPersonFamilyname;
        string contactPersonFunction;
        string contactPersonTel;

        public override string ToString()
        {
            return $"{companyName}\n{contactPersonFirstname} {contactPersonFamilyname}\n{contactPersonFunction}\n{contactPersonTel}";
        }
    }
}
