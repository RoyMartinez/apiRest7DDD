namespace Domain.Models
{
    public class Sales: BaseEntity
    {
        public required string SerialNumber { get; set; }
        public required Guid ClientId { get; set; }
        public required Guid VendorId { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Vendor? Vendor { get; set; }
    }
}
