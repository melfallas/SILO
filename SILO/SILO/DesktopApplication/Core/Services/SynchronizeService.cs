using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Model;
using SILO.DesktopApplication.Core.Model.ListModel;
using SILO.DesktopApplication.Core.Model.ServiceModel;
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
            List<AUS_ApplicationUser> unsynUserList = userRepo.findUnsynUsers();
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
            // Sincronizar a servidor si existen elementos pendientes en cliente
            if (unsynNumberList.Count > 0)
            {
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
                // Validar resultado de la sincronización
                if (successProcess)
                {
                    // Si el resultado del proceso es exitoso, cambiar estado a sincronizado
                    numberRepository.changeStates(unsynNumberList, SystemConstants.SYNC_STATUS_COMPLETED);
                }
            }
            return successProcess;
        }



        // Enviar sincronización de números al servidor
        public bool syncDrawType_LocalToServer()
        {
            bool successProcess = true;
            LotteryDrawTypeRepository drawTypeRepository = new LotteryDrawTypeRepository();
            List<LDT_LotteryDrawType> unsynDrawTypeList = drawTypeRepository.findUnsynTypes();
            // Sincronizar a servidor si existen elementos pendientes en cliente
            if (unsynDrawTypeList.Count > 0)
            {
                // Crear JsonArray
                var jsonObjectArray = new dynamic[unsynDrawTypeList.Count()];
                for (int i = 0; i < unsynDrawTypeList.Count(); i++)
                {
                    // Crear objeto json
                    var jsonObject = new
                    {
                        id = unsynDrawTypeList[i].LDT_Id,
                        code = unsynDrawTypeList[i].LDT_Code,
                        displayName = unsynDrawTypeList[i].LDT_DisplayName,
                        description = unsynDrawTypeList[i].LDT_Description
                    };
                    // Agregar el objeto al array
                    jsonObjectArray[i] = jsonObject;
                }
                var jsonNumberArray = new { items = jsonObjectArray };
                //Console.WriteLine(JsonConvert.SerializeObject(jsonNumberArray));
                ServerConnectionService connection = new ServerConnectionService();
                ServiceResponseResult responseResult = connection.sendDrawTypeToService(jsonNumberArray);
                string codeSectionDetail = MethodBase.GetCurrentMethod().DeclaringType.Name + ": " + MethodBase.GetCurrentMethod().Name;
                successProcess = this.isValidResponse(responseResult, codeSectionDetail);
                // Validar resultado de la sincronización
                if (successProcess)
                {
                    // Si el resultado del proceso es exitoso, cambiar estado a sincronizado
                    drawTypeRepository.changeStates(unsynDrawTypeList, SystemConstants.SYNC_STATUS_COMPLETED);
                }
            }
            return successProcess;
        }

        
        public void setListCompleteSync(LTL_LotteryList pList)
        {
            this.changeListSyncStatus(pList);
        }

        public void changeListSyncStatus(LTL_LotteryList pList, long pSyncStatus = SystemConstants.SYNC_STATUS_COMPLETED)
        {
            // Cambiar el estado de la lista local a Sincronizado
            LotteryListRepository listRepository = new LotteryListRepository();
            LTL_LotteryList syncList = listRepository.getById(pList.LTL_Id);
            syncList.SYS_SynchronyStatus = pSyncStatus;
            listRepository.save(syncList, syncList.LTL_Id, (e1, e2) => e1.copy(e2));
            //Console.WriteLine("Respuesta Venta: " + response.result);
            Console.WriteLine("Respuesta Venta");
        }
        

        public void setListCompleteSync(long pList)
        {
            this.changeListSyncStatus(pList);
        }

        public void changeListSyncStatus(long pList, long pSyncStatus = SystemConstants.SYNC_STATUS_COMPLETED)
        {
            // Cambiar el estado de la lista local a Sincronizado
            LotteryListRepository listRepository = new LotteryListRepository();
            LTL_LotteryList syncList = listRepository.getById(pList);
            syncList.SYS_SynchronyStatus = pSyncStatus;
            listRepository.save(syncList, syncList.LTL_Id, (e1, e2) => e1.copy(e2));
            //Console.WriteLine("Respuesta Venta: " + response.result);
            Console.WriteLine("Respuesta Venta");
        }


        //----------------- Servicios de Sincronización de Pago y Reversión -----------------//
        #region Servicios de Sincronización de Pago y Reversión

        public void sendListNumberToServer(LTL_LotteryList pList, List<LND_ListNumberDetail> pNumberDetail)
        {
            // Llamar al servicio de sincronización con el servidor
            ServerConnectionService service = new ServerConnectionService();
            ServiceResponseResult responseResult = service.syncListToServer(pList, pNumberDetail, result => processResponseToSendList(result));
            //this.processResponseToSendList(responseResult);
        }

        // Método para procesar el resultado del envío de la lista al servidor
        public bool processResponseToSendList(ServiceResponseResult pResponseResult)
        {
            //Console.WriteLine("Ejecutando processResponseToSendList...");
            bool processDone = false;
            if (ServiceValidator.isValidAndNotEmptyServiceResponse(pResponseResult))
            {
                // Obtener el JSON resultado de la sincronización
                String resultString = pResponseResult.result.ToString();
                SyncListResult listSyncResult = JsonConvert.DeserializeObject<SyncListResult>(resultString);
                long listId = listSyncResult.listNumber;
                //Console.WriteLine(listId);
                LotteryListRepository listRepository = new LotteryListRepository();
                listRepository.getById(listId);
                //this.setListCompleteSync(listRepository.getById(listId));
                // Cambiar el estado de la lista local a Sincronizado
                this.setListCompleteSync(listId);
                processDone = true;
            }
            else
            {
                // Error de sincronización
                string responseType = pResponseResult == null ? "N/A" : pResponseResult.type;
                LogService.logErrorServiceResponse("No se pudo sincronizar la venta", responseType, "Pendiente");
            }
            return processDone;
        }


        public void reverseListNumberFromServer(LTL_LotteryList pList)
        {
            // Llamar al servicio de sincronización con el servidor
            ServerConnectionService serverConection = new ServerConnectionService();
            ServiceResponseResult response = serverConection.reverseListToServer(pList);
            if (ServiceValidator.isValidServiceResponse(response))
            {
                // Cambiar el estado de la lista local a Sincronizado
                this.setListCompleteSync(pList);
            }
            else
            {
                // Error de sincronización
                string responseType = response == null ? "N/A" : response.type;
                LogService.logErrorServiceResponse("No se pudo sincronizar la venta", responseType, "Pendiente");
            }
        }
        

        public void syncPendingListNumberToServer()
        {
            LotteryListRepository listRepo = new LotteryListRepository();
            List<LTL_LotteryList> pendingTransactions = listRepo.getPosPendingTransactions();
            foreach (LTL_LotteryList item in pendingTransactions)
            {
                Console.Write(item.LTL_Id);
                switch (item.LLS_LotteryListStatus)
                {
                    case SystemConstants.LIST_STATUS_CREATED:
                        // Procesar creación de la lista en el servidor
                        Console.WriteLine(" - Creada ");
                        List<LND_ListNumberDetail> listNumber = listRepo.getListDetail(item.LTL_Id);
                        this.sendListNumberToServer(item, listNumber);
                        break;
                    case SystemConstants.LIST_STATUS_CANCELED:
                        // Procesar reversión de la lista en el servidor
                        Console.WriteLine(" - Anulada ");
                        this.reverseListNumberFromServer(item);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion


    }
}
