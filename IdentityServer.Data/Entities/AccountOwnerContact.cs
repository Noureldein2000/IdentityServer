namespace IdentityServer.Data.Entities
{
    public class AccountOwnerContact : BaseEntity<int>
    {
        public int AccountOwnerID { get; set; }
        public virtual AccountOwner AccountOwner { get; set; }
        public string Mobile { get; set; }
    }
}
