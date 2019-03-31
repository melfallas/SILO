using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class FormatService
    {
        public static string formatInt(int pNumberToFormat)
        {
            //return string.Format("{0:###,###,###,##0.00##}", pNumberToFormat);
            return string.Format("{0:###,###,###,##0}", pNumberToFormat);
        }

        public static string formatInt(string pNumberStringToFormat)
        {
            return formatInt(Int32.Parse(pNumberStringToFormat));
        }
    }
}
