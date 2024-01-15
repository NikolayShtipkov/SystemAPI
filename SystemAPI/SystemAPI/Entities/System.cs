namespace SystemAPI.Entities
{
    public class System : Entity
    {
        public string? Adress { get; set; }

        public virtual IEnumerable<Device>? Devices { get; set; }
    }
}
