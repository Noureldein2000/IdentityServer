using System;

namespace IdentityServer.Data.Entities
{
    public class BaseEntity<T>
    {
        public T ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
