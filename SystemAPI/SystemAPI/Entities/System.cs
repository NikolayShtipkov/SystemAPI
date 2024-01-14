using System.ComponentModel.DataAnnotations;

namespace SystemAPI.Entities
{
    public class System : Entity
    {
        [Key]
        public int SystemId { get; set; }
        public string Adress { get; set; }

        public virtual IEnumerable<Device>? Devices { get; set; }
    }
}
