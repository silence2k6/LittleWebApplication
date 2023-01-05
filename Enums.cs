using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWebApplication
{
    public class Enums
    {
        public enum UserType
        {
            privateUser = 1,
            businessUser,
            serviceUser,
            adminUser
        }

        public enum Status
        {
            active = 1,
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
