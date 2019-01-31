using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class ServerConnectionService
    {


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
