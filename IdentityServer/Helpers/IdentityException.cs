using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Helpers
{
   public class IdentityException :Exception
    {
        public string ErrorCode { get; private set; }
        public object ExceptionDate { get; set; }
        public IdentityException() : base()
        {

        }

        public IdentityException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
