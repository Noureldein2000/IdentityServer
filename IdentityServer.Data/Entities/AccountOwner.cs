namespace IdentityServer.Data.Entities
{
    public class AccountOwner : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NationalID { get; set; }
        public int AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
