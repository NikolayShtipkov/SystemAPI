using System.ComponentModel.DataAnnotations;

namespace System.Data.Entities
{
    public class Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
