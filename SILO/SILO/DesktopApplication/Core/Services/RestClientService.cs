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
                // Capturar errores
                LogService.log(e.Message, e.StackTrace);
                //throw;
            }
            return responseResult;
        }
    }
}
