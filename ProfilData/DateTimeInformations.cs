using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication.ProfilData
{
    internal class DateTimeInformations
    {
        string donationDate;
        string donationTime;

        public override string ToString()
        {
            return $"{donationDate}\n{donationTime}";
        }
    }
}
