using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Data
{
    public interface IDateModel
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
