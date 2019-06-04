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
        public const string DEVICE_ID_PARAM = "Device";
        public const string PERIODIC_SYNC_ENABLED_PARAM = "Habilitar_Sync_Periodica";
        public const string PERIODIC_SYNC_INTERVAL_PARAM = "Interval_Sync";
        public const string INITIAL_DRAW_INCREMENT_PARAM = "InitialDrawIncrementValue";
        public const string INITIAL_LIST_INCREMENT_PARAM = "InitialListIncrementValue";


        public static LPR_LocalParameter getLocalParameter(string pParamName)
        {
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            return localParamRepo.getByName(pParamName);
        }

        public static string getLocalParameterValue(string pParamName)
        {
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            return localParamRepo.getParamValue(pParamName);
        }

        public static void setLocalParameterValue(string pParamName, string pParamValue, long pType = 0)
        {
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            LPR_LocalParameter paramToSave = getLocalParameter(pParamName);
            if (paramToSave == null)
            {
                paramToSave = new LPR_LocalParameter();
                paramToSave.LPR_Name = pParamName;
            }
            paramToSave.LPR_Value = pParamValue;
            paramToSave.LPT_LocalParameterType = pType == 0 ? paramToSave.LPT_LocalParameterType : pType;
            localParamRepo.save(paramToSave);
        }

        public static LPR_LocalParameter getInitialListIncrementParam()
        {
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            return getLocalParameter(INITIAL_DRAW_INCREMENT_PARAM);
        }

        public static void setInitialListIncrementParam(string pIncrementValue, long pType = 0)
        {
            LocalParameterRepository localParamRepo = new LocalParameterRepository();
            setLocalParameterValue(INITIAL_DRAW_INCREMENT_PARAM, pIncrementValue, pType);
        }

        public static string getDeviceValue()
        {
            return getLocalParameterValue(DEVICE_ID_PARAM);
        }

        public static void setDeviceValue(string pParamValue)
        {
            setLocalParameterValue(DEVICE_ID_PARAM, pParamValue);
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

        public static bool isPeriodSyncEnabled()
        {
            return getLocalParameterValue(PERIODIC_SYNC_ENABLED_PARAM) == "1" ? true : false;
        }

        public static void setPeriodSyncEnabled(bool pIsEnabled)
        {
            setLocalParameterValue(PERIODIC_SYNC_ENABLED_PARAM, pIsEnabled ? "1" : "0");
        }

        public static int getPeriodSyncInterval()
        {
            return Int32.Parse(getLocalParameterValue(PERIODIC_SYNC_INTERVAL_PARAM)) * 1000;
        }

        public static int getPeriodSyncIntervalInSeconds()
        {
            return Int32.Parse(getLocalParameterValue(PERIODIC_SYNC_INTERVAL_PARAM));
        }

        public static void setPeriodSyncInterval(string pParamValue)
        {
            setLocalParameterValue(PERIODIC_SYNC_INTERVAL_PARAM, pParamValue);
        }

        public static string getPrinter()
        {
            return getLocalParameterValue("Nombre_Impresora");
        }

        public static string getEnablePrinter()
        {
            return getLocalParameterValue("Habilitar_Impresion");
        }

        public static void setPrinter(string pNewParamValue)
        {
            setLocalParameterValue("Nombre_Impresora", pNewParamValue);
        }

        public static void setEnablePrinter(string pNewParamValue)
        {
            setLocalParameterValue("Habilitar_Impresion", pNewParamValue);
        }


    }
}
