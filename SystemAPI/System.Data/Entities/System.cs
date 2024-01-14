using System.ComponentModel.DataAnnotations;

namespace System.Data.Entities
{
    public class System : Entity
    {
        [Key]
        public int SystemId { get; set; }
        public string Adress { get; set; }

        public virtual IEnumerable<Device> Devices { get; set; }
    }
}
