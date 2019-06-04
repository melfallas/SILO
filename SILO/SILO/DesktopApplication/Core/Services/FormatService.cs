using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class FormatService
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

        public static string formatDrawDateToString(DateTime pDate)
        {
            return pDate.ToString("yyyy-MM-dd") + " 00:00:00";
        }

        public static string formatDrawDateToString(DateTime? pDate)
        {
            return pDate?.ToString("yyyy-MM-dd") + " 00:00:00";
        }
        
        public static DateTime formatDrawDate(DateTime? pDate)
        {
            return DateTime.Parse(pDate?.ToString("yyyy-MM-dd") + " 00:00:00");
        }

        public static string formatDrawDateToSimpleString(DateTime pDate)
        {
            return pDate.ToString("dd-MM-yyyy");
        }

        public static string formatSecondsToMinutes(int pSeconds)
        {
            int minutes = pSeconds / 60;
            int seconds = pSeconds % 60;
            string timeInMinutes = UtilityService.fillNumberString(minutes.ToString(), 2) + ":" + UtilityService.fillNumberString(seconds.ToString(), 2);
            return timeInMinutes;
            //return pSeconds / 60 + ":" + ((pSeconds % 60) >= 10 ? (pSeconds % 60).ToString() : "0" + pSeconds % 60);
        }

    }
}
