namespace IdentityServer.Data.Entities
{
    public class AccountChannelType : BaseEntity<int>
    {
        public int AccountID { get; set; }
        public int ChannelTypeID { get; set; }
        public bool HasLimitedAccess { get; set; }
        public int ExpirationPeriod { get; set; }

        public virtual ChannelType ChannelType { get; set; }
        public virtual Account Account { get; set; }
    }
}
