using SILO.DesktopApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class ParameterService
    {

        public const string COMPANY_ID_PARAM = "Empresa";
        public const string SYNC_ENABLED_PARAM = "Habilitar_Sync_Periodica";
        public const string SYNC_INTERVAL_PARAM = "Interval_Sync";



        public static string getLocalParameterValue(string pParamName)
        {
            LocalParameterRepository posParam = new LocalParameterRepository();
            return posParam.getParamValue(pParamName);
        }

        public static LPR_LocalParameter getLocalParameter(string pParamName)
        {
            LocalParameterRepository posParam = new LocalParameterRepository();
            return posParam.getByName(pParamName);
        }

        public static string getCompanyId()
        {
            return getLocalParameterValue(COMPANY_ID_PARAM);
        }



        public static bool isSyncEnabled()
        {
            return getLocalParameterValue(SYNC_ENABLED_PARAM) == "1" ? true : false;
        }

        public static int getSyncInterval()
        {
            return Int32.Parse(getLocalParameterValue(SYNC_INTERVAL_PARAM)) * 1000;
        }


    }
}
