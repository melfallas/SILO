using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class ServerParameterService
    {

        public static SPR_ServerParameter getServerParameter(string pParamName)
        {
            ServerParameterRepository serverParamRepo = new ServerParameterRepository();
            return serverParamRepo.getByName(pParamName);
        }

        public static string getServerParameterValue(string pParamName)
        {
            ServerParameterRepository serverParamRepo = new ServerParameterRepository();
            return serverParamRepo.getParamValue(pParamName);
        }

        public static void setServerParameterValue(string pParamName, string pParamValue)
        {
            ServerParameterRepository serverParamRepo = new ServerParameterRepository();
            SPR_ServerParameter serverParam = new SPR_ServerParameter();
            serverParam.SPR_Name = pParamName;
            serverParam.SPR_Value = pParamValue;
            serverParamRepo.save(serverParam);
        }


        public static string getServerDenomination()
        {
            return ServerParameterService.getServerParameterValue(ParameterConstants.SERVICE_DENOMINATION_PARAM_NAME);
        }

        public static string getServerEndPoint()
        {
            return ServerParameterService.getServerParameterValue(ParameterConstants.SERVICE_ENDPOINT_PARAM_NAME);
        }

        public static string getServerPath()
        {
            return ServerParameterService.getServerParameterValue(ParameterConstants.SERVICE_PATH_PARAM_NAME);
        }

        public static string getProhibitedFactor()
        {
            return ServerParameterService.getServerParameterValue(ParameterConstants.SERVER_PROHIBITED_MARGIN_PARAM_NAME);
        }

        public static string getMaxPrintLines()
        {
            return ServerParameterService.getServerParameterValue(ParameterConstants.SERVER_MAX_PRINT_LINES_PARAM_NAME);
        }

    }
}
