using Newtonsoft.Json;
using SILO.DesktopApplication.Core.Model;
using SILO.DesktopApplication.Core.Model.ServiceModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    class RestClientService
    {
        // Método para procesar un request con método GET
        public ServiceResponseResult processGetRequest(string pUrl)
        {
            ServiceResponseResult responseResult = null;
            try
            {
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(pUrl);
                using (WebResponse response = webrequest.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    responseResult = JsonConvert.DeserializeObject<ServiceResponseResult>(responseContent);
                }
            }
            catch (Exception e)
            {
                // Capturar errores en el log
                LogService.log(e.Message, e.StackTrace);
                //throw;
            }
            return responseResult;
        }

        // Método que procesa un request con el método especificado
        public ServiceResponseResult processHttpRequest(string pUrlEndPoint, Object pJsonObject, string pHttpMethod)
        {
            ServiceResponseResult responseResult = null;
            try
            {
                // Serializar objeto json y convertirlo a bits
                string jsonString = JsonConvert.SerializeObject(pJsonObject);
                // Configurar parámetros del request
                byte[] data = UTF8Encoding.UTF8.GetBytes(jsonString);
                HttpWebRequest request = WebRequest.Create(pUrlEndPoint) as HttpWebRequest;
                request.Timeout = 600 * 1000;
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
                responseResult = JsonConvert.DeserializeObject<ServiceResponseResult>(responseBody);
            }
            catch (Exception e)
            {
                // Capturar errores en el log
                LogService.log(e.Message, e.StackTrace);
                //throw;
            }
            return responseResult;
        }

        private static ManualResetEvent allDone = new ManualResetEvent(false);

        // Método que procesa un request con el método especificado
        public ServiceResponseResult processAsyncHttpRequest(string pUrlEndPoint, Object pJsonObject, 
            string pHttpMethod, Func<ServiceResponseResult, bool> processResponseFunction)
        {
            ServiceResponseResult responseResult = null;
            try
            {
                // Serializar objeto json y convertirlo a bits
                string jsonString = JsonConvert.SerializeObject(pJsonObject);
                // Configurar parámetros del request
                byte[] data = UTF8Encoding.UTF8.GetBytes(jsonString);
                HttpWebRequest request = WebRequest.Create(pUrlEndPoint) as HttpWebRequest;
                request.Timeout = 600 * 1000;
                request.Method = pHttpMethod;
                request.ContentLength = data.Length;
                request.ContentType = "application/json; charset=utf-8";
                // Bagin
                request.BeginGetRequestStream(new AsyncCallback(getRequestStreamCallback), new object[] { request, jsonString, processResponseFunction }); 
                allDone.WaitOne();
            }
            catch (Exception e)
            {
                // Capturar errores en el log
                LogService.log(e.Message, e.StackTrace);
                //throw;
            }
            return responseResult;
        }

        private static void getRequestStreamCallback(IAsyncResult asyncResult)
        {
            // Get request parameters
            object[] requestParams = (object[]) asyncResult.AsyncState;
            HttpWebRequest request = (HttpWebRequest) requestParams[0];
            string requestData = requestParams[1].ToString();
            Func<ServiceResponseResult, bool> proccessResponse = (Func<ServiceResponseResult, bool>) requestParams[2];
            // End the operation and process the result data
            Stream postStream = request.EndGetRequestStream(asyncResult);
            byte[] byteData = Encoding.UTF8.GetBytes(requestData);
            postStream.Write(byteData, 0, requestData.Length);
            postStream.Close();
            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(getResponseCallback), new object[] { request, proccessResponse });
        }

        private static void getResponseCallback(IAsyncResult asyncResult)
        {
            // Get request parameters
            object[] requestParams = (object[])asyncResult.AsyncState;
            HttpWebRequest request = (HttpWebRequest)requestParams[0];
            Func<ServiceResponseResult, bool> proccessResponse = (Func<ServiceResponseResult, bool>)requestParams[1];
            // End the operation
            HttpWebResponse response = (HttpWebResponse) request.EndGetResponse(asyncResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseBody = streamRead.ReadToEnd();
            ServiceResponseResult responseResult = JsonConvert.DeserializeObject<ServiceResponseResult>(responseBody);
            Console.WriteLine(responseResult.ToString());
            bool result = proccessResponse(responseResult);
            // Close the stream object
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse
            response.Close();
            allDone.Set();
        }


    }
}
