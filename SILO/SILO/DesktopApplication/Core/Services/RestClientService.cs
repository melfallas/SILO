using Newtonsoft.Json;
using SILO.DesktopApplication.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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


    }
}
