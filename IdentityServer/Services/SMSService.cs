using AutoMapper.Configuration;
using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class SMSService : ISMSService
    {
        private readonly IBaseRepository<ProviderSMS, int> _providerSms;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISwitchService _switchService;
        private readonly IStringLocalizer<AuthenticationResource> _localizer;
        public SMSService(
            UserManager<ApplicationUser> userManager,
            IBaseRepository<ProviderSMS, int> providerSms,
            IUnitOfWork unitOfWork,
            ISwitchService switchService,
            IStringLocalizer<AuthenticationResource> localizer)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _switchService = switchService;
            _providerSms = providerSms;
            _localizer = localizer;
        }
        private static HttpWebRequest CreateWebRequest(string endPoint)
        {
            var request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = "Get";
            request.ContentLength = 0;
            request.ContentType = "text/xml";
            return request;
        }

        public ProviderSMSConfiguarationDTO GetProviderSMSConfiguaration()
        {
            return null;
        }

        public string SendMessage(string body, string receiver)
        {
            try
            {
                var model = _providerSms.Getwhere(x => true).Select(x => new
                {
                    URL = x.URL,
                    TimeOut = x.TimeOut,
                    UserName = x.UserName,
                    UserPassword = x.UserPassword,
                    AccountId = x.UserName,
                    Password = x.UserPassword,
                    ProviderID = x.ProviderID.ToString(),
                    SenderName = x.SenderName,
                    Secretkey = x.ProviderSMSParams.Value
                }).FirstOrDefault();

                var switchEndPointDTO = new SwitchEndPointDTO()
                {
                    URL = model.URL,
                    TimeOut = model.TimeOut,
                    UserName = model.UserName,
                    UserPassword = model.UserPassword,
                };

                var providerSMSDTO = new ProviderSMSDTO()
                {
                    AccountId = model.UserName,
                    Password = model.UserPassword,
                    ProviderID = model.ProviderID,
                    ReceiverMSISDN = receiver,
                    SMSText = body,
                    Secretkey = model.Secretkey,
                    SenderName = model.SenderName
                };

                string Response = _switchService.Connect(providerSMSDTO, switchEndPointDTO, "", "");

                return "1";
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        public string SendMessage(string body, string language, string receiver)
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
