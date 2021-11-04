using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Helpers
{
    [Serializable]
    public class OkException : Exception
    {
        public string ErrorCode { get; private set; }
        public object ExceptionDate { get; set; }
        public OkException(): base()
        {

        }

        public OkException(string message, string errorCode)
            :base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
