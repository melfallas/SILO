using SILO.DesktopApplication.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Util
{
    class ServiceValidator
    {

        public static bool isValidServiceResponse(ServiceResponseResult pResponseResult)
        {
            bool validResponse = true;
            if (pResponseResult == null)
            {
                validResponse = false;
            }
            else
            {
                if (pResponseResult.type != "success" || pResponseResult.result == null)
                {
                    validResponse = false;
                }
            }
            return validResponse;
        }

    }
}
