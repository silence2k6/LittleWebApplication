using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    public class NameInformations
    {
        public string userFirstName;
        public string userLastName;

        public override string ToString()
        {
            return $"{userFirstName} {userLastName}";
        }
    }
}
