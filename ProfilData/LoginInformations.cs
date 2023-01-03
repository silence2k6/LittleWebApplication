using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    public class LoginInformations
    {
        public string userLoginNumber;
        public string userLoginPassword;

        public override string ToString()
        {
            return $"{userLoginNumber}\n\t\t{userLoginPassword}";
        }
    }
}
