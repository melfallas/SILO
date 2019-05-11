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

        public static SPR_ServerParameter getLocalParameter(string pParamName)
        {
            ServerParameterRepository serverParamRepo = new ServerParameterRepository();
            return serverParamRepo.getByName(pParamName);
        }

        public static string getLocalParameterValue(string pParamName)
        {
            ServerParameterRepository serverParamRepo = new ServerParameterRepository();
            return serverParamRepo.getParamValue(pParamName);
        }

        public static void setLocalParameterValue(string pParamName, string pParamValue)
        {
            ServerParameterRepository serverParamRepo = new ServerParameterRepository();
            SPR_ServerParameter serverParam = new SPR_ServerParameter();
            serverParam.SPR_Name = pParamName;
            serverParam.SPR_Value = pParamValue;
            serverParamRepo.save(serverParam);
        }

    }
}
