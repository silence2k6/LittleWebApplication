using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleWebApplication.Donations;

namespace LittleWebApplication.Users
{
    public class User
    {
        CreateUser user = new();
        Donation donation = new();
        List<Donation> donationList = new();
    }
}
