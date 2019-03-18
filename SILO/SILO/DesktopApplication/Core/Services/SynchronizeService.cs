using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SILO.DesktopApplication.Core.Model;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class SynchronizeService
    {
        public void syncCompany_ServerToLocal()
        {
            // Realizar la petición http
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.getCompaniesFromServer();
            string result = responseResult.result.ToString();
            // Parsear el json de respuesta
            JsonObjectParser parser = new JsonObjectParser((int)EntityType.Company);
            string parsedJsonString = parser.parse(result);
            // Realizar la persistencia de los cambios
            CompanyRepository companyRepo = new CompanyRepository();
            companyRepo.saveList(JsonConvert.DeserializeObject<List<CPN_Company>>(parsedJsonString));
        }

        public void syncSalePoint_ServerToLocal()
        {
            // Realizar la petición http
            ServerConnectionService connection = new ServerConnectionService();
            ServiceResponseResult responseResult = connection.getSalePointsFromServer();
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
    }
}
