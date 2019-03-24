using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SILO.DesktopApplication.Core.Model;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class SynchronizeService
    {

        private bool isValidResponse(ServiceResponseResult pResponseResult, string pCodeSectionDetail = "SynchronizeService: ")
        {
            bool validResponse = true;
            if (pResponseResult == null)
            {
                validResponse = false;
            }
            else
            {
                // Registrar evento de error en servicio rest
                if (pResponseResult.type != "success" /*|| pResponseResult.result == null*/)
                {
                    validResponse = false;
                    LogService.logErrorServiceResponse(pResponseResult.message, pResponseResult.type, pCodeSectionDetail);
                }
            }
            return validResponse;
        }

        /*
        private string getCodeSectionDetail()
        {
            return MethodBase.GetCurrentMethod().DeclaringType.Name + ": " + MethodBase.GetCurrentMethod().Name;
        }
        */


        //----------------- Sincronizaciones ServerToLocal -----------------//

        public bool syncCompany_ServerToLocal()
        {
            bool successProcess = true;
            // Realizar la petición http
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.getCompaniesFromServer();
            successProcess = this.isValidResponse(responseResult);
            if (successProcess)
            {
                string result = responseResult.result.ToString();
                // Parsear el json de respuesta
                JsonObjectParser parser = new JsonObjectParser((int)EntityType.Company);
                string parsedJsonString = parser.parse(result);
                // Realizar la persistencia de los cambios
                CompanyRepository companyRepo = new CompanyRepository();
                companyRepo.saveList(JsonConvert.DeserializeObject<List<CPN_Company>>(parsedJsonString));
            }
            return successProcess;
        }

        public bool syncSalePoint_ServerToLocal()
        {
            bool successProcess = true;
            // Realizar la petición http
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.getSalePointsFromServer();
            successProcess = this.isValidResponse(responseResult);
            if (successProcess)
            {
                string jsonStringResult = responseResult.result.ToString();
                JsonObjectParser parser = new JsonObjectParser((int)EntityType.PointSale);
                // Reemplazar objetos complejos en el json por su id
                JArray jsonArray = JArray.Parse(jsonStringResult);
                foreach (var item in jsonArray)
                {
                    parser.changeJsonProp(item, "company");
                    parser.changeJsonProp(item, "synchronyStatus");
                }
                // Parsear el json de respuesta
                string parsedJsonString = parser.parse(jsonArray.ToString());
                // Realizar la persistencia de los cambios
                LotteryPointSaleRepository posRepo = new LotteryPointSaleRepository();
                posRepo.saveList(JsonConvert.DeserializeObject<List<LPS_LotteryPointSale>>(parsedJsonString));
            }
            return successProcess;
        }

        public bool syncRole_ServerToLocal()
        {
            bool successProcess = true;
            // Realizar la petición http
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.getRolesFromServer();
            successProcess = this.isValidResponse(responseResult);
            if (successProcess)
            {
                string result = responseResult.result.ToString();
                // Parsear el json de respuesta
                JsonObjectParser parser = new JsonObjectParser((int)EntityType.UserRole);
                string parsedJsonString = parser.parse(result);
                // Realizar la persistencia de los cambios
                RoleRepository roleRepository = new RoleRepository();
                roleRepository.saveList(JsonConvert.DeserializeObject<List<USR_UserRole>>(parsedJsonString));
            }
            return successProcess;
        }

        public bool syncAppUsers_ServerToLocal()
        {
            bool successProcess = true;
            // Realizar la petición http
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.getUsersFromServer();
            successProcess = this.isValidResponse(responseResult);
            if (successProcess)
            {
                string jsonStringResult = responseResult.result.ToString();
                JsonObjectParser parser = new JsonObjectParser((int)EntityType.ApplicationUser);
                // Reemplazar objetos complejos en el json por su id
                JArray jsonArray = JArray.Parse(jsonStringResult);
                foreach (var item in jsonArray)
                {
                    parser.changeJsonProp(item, "userRole");
                    parser.changeJsonProp(item, "lotteryPointSale");
                }
                // Parsear el json de respuesta
                string parsedJsonString = parser.parse(jsonArray.ToString());
                // Realizar la persistencia de los cambios
                ApplicationUserRepository userRepo = new ApplicationUserRepository();
                userRepo.saveList(JsonConvert.DeserializeObject<List<AUS_ApplicationUser>>(parsedJsonString));
            }
            return successProcess;
        }


        //----------------- Sincronizaciones LocalToServer -----------------//

        public bool syncAppUsers_LocalToServer()
        {
            bool successProcess = true;
            ApplicationUserRepository userRepo = new ApplicationUserRepository();
            List <AUS_ApplicationUser> unsynUserList = userRepo.findUnsynUsers();
            foreach (var userItem in unsynUserList)
            {
                Console.WriteLine(userItem.AUS_Username);
            }
            return successProcess;
        }

        // Enviar sincronización de números al servidor
        public bool syncNumbers_LocalToServer()
        {
            bool successProcess = true;
            LotteryNumberRepository numberRepository = new LotteryNumberRepository();
            List<LNR_LotteryNumber> unsynNumberList = numberRepository.findUnsynUsers();
            // Crear JsonArray
            var jsonObjectArray = new dynamic[unsynNumberList.Count()];
            for (int i = 0; i < unsynNumberList.Count(); i++)
            {
                // Crear objeto json
                var jsonObject = new
                {
                    id = unsynNumberList[i].LNR_Id,
                    number = unsynNumberList[i].LNR_Number,
                    //isProhibited = unsynNumberList[i].LNR_IsProhibited
                    isProhibited = unsynNumberList[i].LNR_IsProhibited == 1 ? true : false
                };
                // Agregar el objeto al array
                jsonObjectArray[i] = jsonObject;
            }
            var jsonNumberArray = new { items = jsonObjectArray };
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.sendNumberDataToService(jsonNumberArray);
            string codeSectionDetail = MethodBase.GetCurrentMethod().DeclaringType.Name + ": " + MethodBase.GetCurrentMethod().Name;
            successProcess = this.isValidResponse(responseResult, codeSectionDetail);
            return successProcess;
        }

    }
}
