using System.ComponentModel.DataAnnotations;

namespace System.Data.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
