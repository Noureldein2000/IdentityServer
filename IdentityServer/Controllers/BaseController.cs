using IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult Unauthorized(string errorCode, string errorMessage)
        {
            var response = new AuthorizationErrorMessages
            {
                Code = errorCode,
                Message = errorMessage
            };
            return Unauthorized(response);
        }
        [NonAction]
        public IActionResult BadRequest(string errorCode, string errorMessage)
        {
            var response = new AuthorizationErrorMessages
            {
                Code = errorCode,
                Message = errorMessage
            };
            return BadRequest(response);
        }
        [NonAction]
        public IActionResult Ok(string errorCode, string errorMessage)
        {
            var response = new AuthorizationErrorMessages
            {
                Code = errorCode,
                Message = errorMessage
            };
            return Ok(response);
        }
        public int UserIdentity
        {
            get
            {
                return int.Parse(User.Identity.Name);
            }
        }
        protected string GetIPAddress()
        {
            HttpContext context = HttpContext;
            string ipAddress = context.GetServerVariable("HTTP_X_FORWARDED_FOR");

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.GetServerVariable("REMOTE_ADDR");
        }
        protected string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }
    }
}
