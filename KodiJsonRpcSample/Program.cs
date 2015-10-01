using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace KodiJsonRpcSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://{YOUR_IP}:{YOUR_PORT}/jsonrpc";

            // Create request
            var kodiRequest = new JsonRpcRequest()
            {
                Method = "VideoLibrary.GetMovies",
                Params = new
                {
                    properties = new string[] { "title", "genre", "year", "rating", "director", "plot", "plotoutline" },
                    limits = new { start = 1, end = 100 },
                    sort = new { order = "ascending", ignorearticle = true, method = "title" }
                }
            };

            // Write to console
            System.Console.WriteLine(kodiRequest.ToString());

            // Send request via HTTP
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.ContentType = "application/json";
                request.KeepAlive = false;
                request.Method = "POST";
                request.Timeout = 10000;

                using (Stream requestStream = request.GetRequestStream())
                {
                    using (StreamWriter requestWriter = new StreamWriter(requestStream, Encoding.ASCII))
                    {
                        // Set ID
                        kodiRequest.Id = 1;

                        // Write to stream
                        requestWriter.Write(kodiRequest.ToString());
                    }
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            // Get result
                            var json = JObject.Parse(responseReader.ReadToEnd());
                            // Write to console
                            System.Console.WriteLine(json.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}