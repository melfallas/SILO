﻿using Newtonsoft.Json;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class ServerConnectionService
    {

        //----------------- Métodos para obtener datos del Servidor -----------------//

        public ServiceResponseResult getCompaniesFromServer()
        {
            return this.processGetRequest(ServiceConectionConstants.GET_ALL_COMPANIES_RESOURCE_URL);
        }

        public ServiceResponseResult getSalePointsFromServer()
        {
            return this.processGetRequest(ServiceConectionConstants.GET_ALL_POINT_SALE_RESOURCE_URL);
        }

        public ServiceResponseResult getRolesFromServer()
        {
            return this.processGetRequest(ServiceConectionConstants.GET_ALL_ROLES_RESOURCE_URL);
        }

        public ServiceResponseResult getUsersFromServer()
        {
            return this.processGetRequest(ServiceConectionConstants.GET_ALL_USERS_RESOURCE_URL);
        }


        //----------------- Métodos para enviar datos al Servidor -----------------//

        public ServiceResponseResult sendNumberDataToService(Object pJsonObject, string pHttpMethod = "POST")
        {
            return this.callHttpRequest(ServiceConectionConstants.POST_SAVE_NUMBER_LIST_RESOURCE_URL, pJsonObject, pHttpMethod);
        }

        public ServiceResponseResult sendDrawTypeToService(Object pJsonObject, string pHttpMethod = "POST")
        {
            return this.callHttpRequest(ServiceConectionConstants.POST_SAVE_DRAWTYPE_LIST_RESOURCE_URL, pJsonObject, pHttpMethod);
        }



        //----------------- Métodos utilitarios para acceder a servicios -----------------//


        public ServiceResponseResult callHttpRequest(string pServiceURL, Object pJsonObject, string pHttpMethod)
        {
            RestClientService restClient = new RestClientService();
            return restClient.processHttpRequest(pServiceURL, pJsonObject, pHttpMethod);
        }

        public ServiceResponseResult processGetRequest(string pServiceURL)
        {
            RestClientService restClient = new RestClientService();
            return restClient.processGetRequest(pServiceURL);
        }


        /*
        public ServiceResponseResult processGetRequest()
        {
            RestClientService restClient = new RestClientService();
            var url = "https://silo-services.herokuapp.com/company/";
            return restClient.processGetRequest(url);
        }
        */

        public void getConnection()
        {
            string urlEndPoint = "https://time-control-app.herokuapp.com/company/";
            var postString = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(postString);

            HttpWebRequest request;
            request = WebRequest.Create(urlEndPoint) as HttpWebRequest;
            request.Timeout = 50 * 1000;
            request.Method = "GET";
            //request.ContentLength = data.Length;
            request.ContentType = "application/json; charset=utf-8";
            /*
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            */

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            Console.WriteLine("Response stream received.");
            Console.WriteLine(readStream.ReadToEnd());
            response.Close();
            readStream.Close();
        }


        public ServiceResponseResult generateList(LTL_LotteryList pListObject, List<LND_ListNumberDetail> pListNumberDetail)
        {
            // Trasnformar LND_ListNumberDetail en una lista de elementos para el json
            List<ListNumberDetail> numberDetail = pListNumberDetail.Select(
                x => new ListNumberDetail(x.LND_Id, x.LTL_LotteryList, x.LNR_LotteryNumber, x.LND_SaleImport)
            ).ToList();
            LotteryDrawRepository lotteryDrawRepository = new LotteryDrawRepository();
            LTD_LotteryDraw draw = lotteryDrawRepository.getById(pListObject.LTD_LotteryDraw);
            // Crear el objeto JSON
            var jsonObject = new
            {
                listNumber = pListObject.LTL_Id,
                lotteryPointSale = pListObject.LPS_LotteryPointSale,
                lotteryDraw = new
                {
                    id = pListObject.LTD_LotteryDraw,
                    lotteryDrawType = draw.LDT_LotteryDrawType,
                    lotteryDrawStatus = draw.LDS_LotteryDrawStatus,
                    createDate = draw.LTD_CreateDate
                },
                customerName = pListObject.LTL_CustomerName,
                createDate = pListObject.LTL_CreateDate.ToString("yyyy-MM-dd HH:mm:ss"),
                lotteryListStatus = SystemConstants.LIST_STATUS_CREATED,
                listNumberDetail = numberDetail
            }
            ;
            Console.WriteLine("Request Venta: " + jsonObject);
            string urlEndPoint = ServiceConectionConstants.LIST_RESOURCE_URL;
            return processHttpRequest(urlEndPoint, jsonObject, ServiceConectionConstants.HTTP_POST_METHOD);
        }

        public ServiceResponseResult synchronizeDrawAssociation()
        {
            var jsonObject = new
            {
                lotteryPointSale = 1,
                lotteryDraw = new
                {
                    id = 14,
                    lotteryDrawType = 2,
                    lotteryDrawStatus = 1,
                    createDate = "2019-01-30"
                },
                createDate = "2019-01-30 22:00:00"
            };
            string urlEndPoint = ServiceConectionConstants.DRAW_ASSOCIATION_RESOURCE_URL;
            return processHttpRequest(urlEndPoint, jsonObject, ServiceConectionConstants.HTTP_POST_METHOD);
        }

        public ServiceResponseResult synchronizeDrawType()
        {
            var jsonObject = new
            {
                code = "DOMI-NOCHE",
                displayName = "DOMINICANA NOCHE",
                description = "Sorteo Dominicana Noche"
            };
            string urlEndPoint = ServiceConectionConstants.DRAW_TYPE_RESOURCE_URL;
            return processHttpRequest(urlEndPoint, jsonObject, ServiceConectionConstants.HTTP_POST_METHOD);
        }


        //--******************** Método Utilizado para servicios *********************--//
        public ServiceResponseResult processHttpRequest(string pUrlEndPoint, Object pJsonObject, string pHttpMethod)
        {
            // Serializar objeto json y convertirlo a bits
            string jsonString = JsonConvert.SerializeObject(pJsonObject);
            // Configurar parámetros del request
            byte[] data = UTF8Encoding.UTF8.GetBytes(jsonString);
            HttpWebRequest request = WebRequest.Create(pUrlEndPoint) as HttpWebRequest;
            request.Timeout = 1000 * 1000;
            request.Method = pHttpMethod;
            request.ContentLength = data.Length;
            request.ContentType = "application/json; charset=utf-8";
            // Escribir parámetros del request en post Stream
            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            // Solicitar respuesta de la petición y procesarla
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            // Generar string body de la respuesta
            string responseBody = reader.ReadToEnd();
            Console.WriteLine(responseBody);
            ServiceResponseResult responseResult = JsonConvert.DeserializeObject<ServiceResponseResult>(responseBody);
            return responseResult;
        }

        public void postConnection()
        {
            string urlEndPoint = "http://localhost:5555/lotterydrawtype/";
            
            //var postString = new { clave1: valor1, clave2: valor2};

            var jsonObject = new {
                code = "DOMI-NOCHE",
                displayName = "DOMINICANA NOCHE",
                description = "Sorteo Dominicana Noche"
            };
            string jsonString = JsonConvert.SerializeObject(jsonObject);
            /*
            HttpClient wsClient = new HttpClient();
            var jsonResult = await wsClient.PostAsJsonAsync(urlEndPoint, jsonString);
            Console.WriteLine(jsonResult);
            */
            
            byte[] data = UTF8Encoding.UTF8.GetBytes(jsonString);
            HttpWebRequest request;
            request = WebRequest.Create(urlEndPoint) as HttpWebRequest;
            request.Timeout = 50 * 1000;
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json; charset=utf-8";

            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string body = reader.ReadToEnd();
            Console.WriteLine(body);
            ServiceResponseResult responseResult = JsonConvert.DeserializeObject<ServiceResponseResult>(body);
            Console.WriteLine(responseResult.message);

        }

        public void post()
        {
            string urlEndPoint = "http://localhost/ejemplo/api";
            var postString = "";
            //var postString = new { clave1: valor1, clave2: valor2};
            byte[] data = UTF8Encoding.UTF8.GetBytes(postString);

            HttpWebRequest request;
            request = WebRequest.Create(urlEndPoint) as HttpWebRequest;
            request.Timeout = 10 * 1000;
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json; charset=utf-8";

            Stream postStream = request.GetRequestStream();
            postStream.Write(data, 0, data.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string body = reader.ReadToEnd();

        }
    }
}