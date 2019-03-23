using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Constants
{
    class ServiceConectionConstants
    {
        // Constantes para verbos HTTP
        public const string HTTP_GET_METHOD = "GET";
        public const string HTTP_POST_METHOD = "POST";
        public const string HTTP_PUT_METHOD = "PUT";
        public const string HTTP_DELETE_METHOD = "DELETE";

        // Constantes para end point urls de las API
        //public const string ROOT_SERVICE_API_END_POINT          = "http://localhost:5555/";
        public const string ROOT_SERVICE_API_END_POINT          = "https://silo-services.herokuapp.com/";

        // URLs de los servicios principales
        public const string GET_ALL_COMPANIES_RESOURCE_URL = ROOT_SERVICE_API_END_POINT + "company/";
        public const string GET_ALL_POINT_SALE_RESOURCE_URL = ROOT_SERVICE_API_END_POINT + "lotterypointsale/";
        public const string GET_ALL_ROLES_RESOURCE_URL = ROOT_SERVICE_API_END_POINT + "userrole/";
        public const string GET_ALL_USERS_RESOURCE_URL = ROOT_SERVICE_API_END_POINT + "applicationuser/";

        public const string DRAW_TYPE_RESOURCE_URL              = ROOT_SERVICE_API_END_POINT + "lotterydrawtype/";
        public const string DRAW_ASSOCIATION_RESOURCE_URL       = ROOT_SERVICE_API_END_POINT + "lotterydrawassociation/synchronize/";
        public const string LIST_RESOURCE_URL                   = ROOT_SERVICE_API_END_POINT + "lotterylist/generate/";
        //"listnumberdetail/summary/";

    }

}
