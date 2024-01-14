using System.ComponentModel.DataAnnotations;

namespace SystemAPI.Entities
{
    public abstract class Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
