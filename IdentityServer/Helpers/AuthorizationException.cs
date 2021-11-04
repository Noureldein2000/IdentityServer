using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Helpers
{
    [Serializable]
    public class AuthorizationException : Exception
    {
        public string ErrorCode { get; private set; }
        public object ExceptionDate { get; set; }
        public AuthorizationException(): base()
        {

        }

        public AuthorizationException(string message, string errorCode)
            :base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
