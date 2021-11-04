using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class VictorySMSService : ISMSService
    {
        private static HttpWebRequest CreateWebRequest(string endPoint)
        {
            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = "Get";
            request.ContentLength = 0;
            request.ContentType = "text/xml";
            return request;
        }
        public string SendMessage(string body, string lang, string receiver)
        {
            try
            {
                //var uri = string.Format("https://smsvas.vlserv.com/KannelSending/service.asmx/SendSMS?username={0}&password={1}&SMSText={2}&SMSLang={3}&SMSSender={4}&SMSReceiver={5}", "Momkn", "q99LMgp9i9", body, lang, "Momkn", receiver);
                //HttpWebRequest request = CreateWebRequest(uri);
                //using (var response = (HttpWebResponse)request.GetResponse())
                //{
                //    var responseValue = string.Empty;
                //    if (response.StatusCode != HttpStatusCode.OK)
                //    {
                //        string message = string.Format("POST failed. Received HTTP {0}", response.StatusCode);
                //        throw new ApplicationException(message);
                //    }
                //    //grab the response
                //    using (var responseStream = response.GetResponseStream())
                //    {
                //        using (var reader = new StreamReader(responseStream))
                //        {
                //            responseValue = reader.ReadToEnd();
                //        }
                //    }
                //    return responseValue;
                //}
                return null;
            }
            catch
            {
                return "0";
            }
        }
    }
}
