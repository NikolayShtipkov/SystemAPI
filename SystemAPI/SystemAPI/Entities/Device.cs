using System.ComponentModel.DataAnnotations.Schema;

namespace SystemAPI.Entities
{
    public class Device : Entity
    {
        public string? Location { get; set; }

        [ForeignKey("SystemId")]
        public int? SystemId { get; set; }
        public virtual System? System { get; set; }
    }
}
