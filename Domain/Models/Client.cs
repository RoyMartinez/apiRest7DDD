
namespace Domain.Models
{
    public class Client: BaseEntity
    {
        public string? Ruc { get; set; }

        public string? Name { get; set; }
        public virtual ICollection<Sales> Sales { get; set; } = new List<Sales>();
    }
}
