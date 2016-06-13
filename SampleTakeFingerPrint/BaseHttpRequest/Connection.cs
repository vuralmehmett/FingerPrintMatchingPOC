using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using SampleTakeFingerPrint.Model;

namespace SampleTakeFingerPrint.BaseHttpRequest
{
    public class Connection
    {
        public static string Url
        {
            get
            {
                return ConfigurationManager.AppSettings["FingerPrintServiceApiAddress"];
            }
        }
        public string Get()
        {
            var webrequest = (HttpWebRequest)WebRequest.Create(Url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            var webresponse = (HttpWebResponse)webrequest.GetResponse();
            var enc = Encoding.GetEncoding("utf-8");
            // ReSharper disable once AssignNullToNotNullAttribute
            var responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            var result = responseStream.ReadToEnd();
            webresponse.Close();

            return result;
        }

        public string Post(FingerPrintRequest model)
        {
            string result = "";
            Random rnd = new Random();

            model.ImagePath = model.ImagePath;
            var webrequest = WebRequest.Create(Url + "MatchFingerPrint");
            var enc = new UTF8Encoding(false);
            var serializedJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var data = enc.GetBytes(serializedJson);

            webrequest.Method = "POST";
            webrequest.ContentType = "application/json";
            webrequest.ContentLength = data.Length;
            webrequest.Timeout = 500000000;

            using (var sr = webrequest.GetRequestStream())
            {
                sr.Write(data, 0, data.Length);
            }
            var res = webrequest.GetResponse();

            // ReSharper disable once AssignNullToNotNullAttribute
            result = new StreamReader(res.GetResponseStream()).ReadToEnd();

            return result;
        }
    }
}
