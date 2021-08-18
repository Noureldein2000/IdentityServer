using IdentityServer.Data.Entities;
using IdentityServer.DTOs;
using IdentityServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class EntityService : IEntityService
    {
        private readonly IBaseRepository<Entity, int> _entity;
        private readonly IUnitOfWork _unitOfWork;
        public EntityService(IBaseRepository<Entity, int> entity, IUnitOfWork unitOfWork)
        {
            _entity = entity;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<EntityDTO> GetEntities()
        {
            return _entity.GetAll().Select(a => new EntityDTO()
            {
                ID = a.ID,
                Name = a.Name,
                NameAr = a.NameAr
            }).ToList();
        }
    }
}
