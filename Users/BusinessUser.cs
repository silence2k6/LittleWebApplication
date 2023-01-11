using LittleWebApplication.Rewards;
using LittleWebApplication.ProfilData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleWebApplication.Terminal;

namespace LittleWebApplication.Users
{
    public class BusinessUser
    {
        public CreateUser businessUserProfil;
        public List<TerminalInformations> businessUserTerminalList;
        public List<Coupon> businessUserCouponList;
    }
}
