using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace appMobi.AppMobiCloudServiceExtension
{
    public class BReq
    {
        /// <summary>
        /// UserAgent to be used on the requests
        /// </summary>
        public string UserAgent = @"Mozilla/5.0 (Windows; Windows NT 6.1) AppleWebKit/534.23 (KHTML, like Gecko) Chrome/11.0.686.3 Safari/534.23";

        /// <summary>
        /// Cookie Container that will handle all the cookies.
        /// </summary>
        private CookieContainer cJar;

        /// <summary>
        /// Performs a basic HTTP GET request.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>HTML Content of the response.</returns>
        public string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.ContentType = "application/json; charset=utf-8";
            request.UserAgent = UserAgent;
            request.KeepAlive = false;
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Performs a basic HTTP POST request
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="post">POST Data to be passed.</param>
        /// <param name="refer">Referrer of the request</param>
        /// <returns>HTML Content of the response.</returns>
        public string HttpPost(string url, string post, string refer = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cJar;
            request.UserAgent = UserAgent;
            request.KeepAlive = false;
            request.Method = "POST";
            request.Referer = refer;

            byte[] postBytes = Encoding.ASCII.GetBytes(post);
            //request.ContentType = "application/x-www-form-urlencoded";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = postBytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            var jsonData = "";
            //get response-stream, and use a streamReader to read the content
            using (Stream s = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    jsonData = sr.ReadToEnd();
                }
            }

            return jsonData;
        }

        /// <summary>
        /// Creates an HTML file from the string.
        /// </summary>
        /// <param name="html">HTML String.</param>
        public void DebugHtml(string html)
        {
            StreamWriter sw = new StreamWriter("debug.html");
            sw.Write(html);
            sw.Close();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BReq"/> class.
        /// </summary>
        public BReq()
        {
            cJar = new CookieContainer();
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="BReq"/> is reclaimed by garbage collection.
        /// </summary>
        ~BReq()
        {
            // Nothing here
        }
    }
}
