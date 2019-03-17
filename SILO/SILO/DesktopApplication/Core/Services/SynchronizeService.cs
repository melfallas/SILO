using Newtonsoft.Json;
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
            JsonObjectParser parser = new JsonObjectParser();
            string parsedJsonString = parser.parse(result);
            // Realizar la persistencia de los cambios
            CompanyRepository companyRepo = new CompanyRepository();
            companyRepo.saveList(JsonConvert.DeserializeObject<List<CPN_Company>>(parsedJsonString));
        }

        public void syncSalePoint_ServerToLocal()
        {

        }

    }
}
