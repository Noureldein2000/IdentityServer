using IdentityServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        ApplicationDbContext GetContext();
    }
}
