using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Constants
{
    public class ServiceConectionConstants
    {
        // Constantes para verbos HTTP
        public static string HTTP_GET_METHOD = "GET";
        public static string HTTP_POST_METHOD = "POST";
        public static string HTTP_PUT_METHOD = "PUT";
        public static string HTTP_DELETE_METHOD = "DELETE";

        // Constantes para end point urls de las API
        //public static string DEFAULT_ROOT_SERVICE_API_END_POINT          = "http://localhost:5555/";
        //public static string DEFAULT_ROOT_SERVICE_API_END_POINT          = "https://silo-services.herokuapp.com/";
        public static string DEFAULT_ROOT_SERVICE_API_END_POINT = "https://silo-services-prod1.herokuapp.com/";

        // URLs de los servicios principales
        public static string GET_ALL_SERVER_PARAMS_RESOURCE_URL = getRootServiceApiURL() + "serverparameter/";
        public static string GET_ALL_COMPANIES_RESOURCE_URL =  getRootServiceApiURL() + "company/";
        public static string GET_ALL_POINT_SALE_RESOURCE_URL =  getRootServiceApiURL() + "lotterypointsale/";
        public static string GET_ALL_ROLES_RESOURCE_URL =  getRootServiceApiURL() + "userrole/";
        public static string GET_ALL_USERS_RESOURCE_URL =  getRootServiceApiURL() + "applicationuser/";
        public static string GET_ALL_PRIZE_FACTOR_RESOURCE_URL =  getRootServiceApiURL() + "lotteryprizefactor/";
        public static string GET_REOPEN_DRAW_LIST_RESOURCE_URL =  getRootServiceApiURL() + "lotterydraw/reopen/?pos=";

        // Servicios para sincronización post login
        public static string GET_ALL_NUMBER_LIST_RESOURCE_URL = getRootServiceApiURL() + "lotterynumber/";
        public static string GET_ALL_DRAWTYPE_LIST_RESOURCE_URL = getRootServiceApiURL() + "lotterydrawtype/";


        public static string POST_SAVE_NUMBER_LIST_RESOURCE_URL =  getRootServiceApiURL() + "lotterynumber/saveList/";
        public static string POST_SAVE_DRAWTYPE_LIST_RESOURCE_URL =  getRootServiceApiURL() + "lotterydrawtype/saveList/";
        
        public static string DRAW_TYPE_RESOURCE_URL              =  getRootServiceApiURL() + "lotterydrawtype/";
        public static string DRAW_ASSOCIATION_RESOURCE_URL       =  getRootServiceApiURL() + "lotterydrawassociation/synchronize/";
        public static string ROOT_LIST_RESOURCE_URL               =  getRootServiceApiURL() + "lotterylist/";
        public static string LIST_RESOURCE_URL                   =  getRootServiceApiURL() + "lotterylist/generate/";

        // Cierre
        public static string CLOSING_DRAW_RESOURCE_URL = getRootServiceApiURL() + "lotterydraw/changestatus/";
        public static string WINNER_NUMBERS_RESOURCE_URL = getRootServiceApiURL() + "drawnumberwinning/sync/";

        // Servicios de máximos en sorteos y listas
        public static string GET_MAX_ID_DRAW_RESOURCE_URL = getRootServiceApiURL() + "lotterydraw/max-id";
        public static string GET_MAX_ID_LIST_RESOURCE_URL = getRootServiceApiURL() + "lotterylist/max-id";


        public static string getServiceApiEndPoint()
        {
            string url = "";
            string serviceEndPoint = ServerParameterService.getServerParameterValue(ParameterConstants.SERVICE_ENDPOINT_PARAM_NAME);
            string endPoint = serviceEndPoint.Trim();
            url = endPoint == "" ? DEFAULT_ROOT_SERVICE_API_END_POINT : endPoint;
            return url;
        }

        public static string getRootServiceApiURL()
        {
            string url = "";
            string serviceRootPath = ServerParameterService.getServerParameterValue(ParameterConstants.SERVICE_PATH_PARAM_NAME);
            string endPointPath = getServiceApiEndPoint() + serviceRootPath.Trim();
            url = endPointPath == "" ? DEFAULT_ROOT_SERVICE_API_END_POINT : endPointPath;
            return url;
        }

    }

}
