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
            HttpWebRequest webrequest = (HttpWebRequest) WebRequest.Create(pUrl);
            using (WebResponse response = webrequest.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseContent = reader.ReadToEnd();
                responseResult = JsonConvert.DeserializeObject<ServiceResponseResult>(responseContent);
            }
            return responseResult;
        }
    }
}
