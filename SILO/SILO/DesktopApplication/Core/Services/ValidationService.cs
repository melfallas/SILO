using SILO.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class ValidationService
    {
        public static bool isValidId(string pStringId)
        {
            bool valid = true;
            if (pStringId == null || pStringId.Trim() == GeneralConstants.EMPTY_STRING || long.Parse(pStringId) < 1)
            {
                valid = false;
            }
            return valid;
        }
    }
}
