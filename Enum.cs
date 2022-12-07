using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    public class Enum
    {
        public enum UserType
        {
            privatUser = 1,
            businessUser,
            serviceUser,
            adminUser
        }

        public enum Status
        {
            activ = 1,
            disabled,
            expired,
            used
        }

        public enum Service
        {
            emptying = 1,
            repair,
            remove,
            installation
        }
    }
}
