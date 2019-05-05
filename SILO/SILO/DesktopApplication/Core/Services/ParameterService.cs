using SILO.DesktopApplication.Core.Constants;
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
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            return localParamRepo.getParamValue(pParamName);
        }

        public static LPR_LocalParameter getLocalParameter(string pParamName)
        {
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            return localParamRepo.getByName(pParamName);
        }

        public static void setLocalParameterValue(string pParamName, string pParamValue)
        {
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            LPR_LocalParameter localParam = new LPR_LocalParameter();
            localParam.LPR_Name = pParamName;
            localParam.LPR_Value = pParamValue;
            localParamRepo.save(localParam);
        }

        public static void setDeviceValue(string pParamValue)
        {
            setLocalParameterValue("Device", pParamValue);
        }

        public static string getCompanyId()
        {
            return getLocalParameterValue(COMPANY_ID_PARAM);
        }

        public static string getSalePointParamValue()
        {
            return getLocalParameterValue(ParameterConstants.POS_NAME_PARAM);
        }

        public static long getSalePointId()
        {
            string localParamValue = getSalePointParamValue();
            // TODO: Validar si es número
            return localParamValue.Trim() == "" ? 0 : Convert.ToInt64(localParamValue);
        }

        public static LPS_LotteryPointSale getSystemSalePoint()
        {
            LPS_LotteryPointSale pointSaleInstance = null;
            string localParam = getSalePointParamValue();
            if (localParam.Trim() != "")
            {
                LotteryPointSaleRepository posRepository = new LotteryPointSaleRepository();
                // TODO: Validar si es número
                long posId = Convert.ToInt64(localParam);
                pointSaleInstance = posRepository.getById(posId);
            }
            
            return pointSaleInstance;
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
