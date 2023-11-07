using System.ComponentModel.DataAnnotations;

namespace Domain.Models 
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserCreated {  get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserUpdated { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
