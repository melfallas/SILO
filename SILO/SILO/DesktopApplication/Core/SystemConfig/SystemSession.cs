using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.SystemConfig
{
    public static class SystemSession
    {
        public static  CPN_Company sessionCompany { get; set; }
        public static LPS_LotteryPointSale sessionPointSale { get; set; }
        public static AUS_ApplicationUser sessionUser { get; set; }

        public static string company { get { return sessionCompany == null ? "" : sessionCompany.CPN_DisplayName; } }
        public static string salePoint { get { return sessionPointSale == null ? "" : sessionPointSale.LPS_DisplayName; } }
        public static string username { get { return sessionUser == null ? "" : sessionUser.AUS_Username; } }

    }
}
