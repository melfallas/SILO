using SILO.DesktopApplication.Core.SystemConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class LogService
    {
        public static void log(string pMessage, string pStackTraceError)
        {
            // Get Error Detail
            Match match = Regex.Match(pStackTraceError, @"\\[A-za-z]+.cs:line [0-9]+");
            string errorDetail = match.Success ? match.Captures[0].Value : "";
            string[] detailArray = errorDetail.Split('\\');
            errorDetail = detailArray.Length > 0 ? detailArray[detailArray.Length-1]: "";
            // Get Error Origin
            match = Regex.Match(pStackTraceError, @"at [A-za-z.]+");
            string errorOrigin = match.Success ? match.Captures[0].Value : "";
            // Get username
            string username = SystemSession.username == "" ? "N/A" : SystemSession.username;
            // Registrar error en el log
            string errorMessage = pMessage + " | " + errorOrigin + " | " + errorDetail + " | " + username + " | ";
            Console.WriteLine(errorMessage);
        }

        public static void logErrorServiceResponse(string pMessage, string pErrorType, string pDetail)
        {
            string username = SystemSession.username == "" ? "N/A" : SystemSession.username;
            string errorMessage = pMessage + " | " + pErrorType + " | " + pDetail + " | " + username + " | ";
            Console.WriteLine(errorMessage);
        }
    }
}
