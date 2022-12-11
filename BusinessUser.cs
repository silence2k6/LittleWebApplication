﻿using LittleWebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LittleWebApplication.ProfilData;

namespace LittleWebApplication
{
    internal class BusinessUser
    {
            int ArtOfUser;
            string userNumber;
            private ProfilData newUserProfil = new ProfilData();
            private CompanyInformations newCompany = new CompanyInformations();
            private List<Terminal> businessTerminalList = new List<Terminal>();
            private List<Coupon> businessCouponList new List<Coupon>();
    }
}