using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    public class ContactInformations
    {
        public string userContactTel;
        public string userContactMail;

        public override string ToString()
        {
            return $"{userContactTel}\n\t\t{userContactMail}";
        }
    }
}
