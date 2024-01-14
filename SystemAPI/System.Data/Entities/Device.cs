using System.ComponentModel.DataAnnotations;

namespace System.Data.Entities
{
    public class Device : Entity
    {
        [Key]
        public int DeviceId { get; set; }
        public string Location { get; set; }

        public int? SystemId { get; set; }
        public virtual System system { get; set; }
    }
}
