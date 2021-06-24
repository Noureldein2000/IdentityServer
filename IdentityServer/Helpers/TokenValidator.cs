using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Helpers
{
    public class TokenValidator : ICustomTokenRequestValidator
    {
        public Task ValidateAsync(IdentityServer4.Validation.CustomTokenRequestValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
