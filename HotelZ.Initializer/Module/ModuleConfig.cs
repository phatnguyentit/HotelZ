namespace HotelZ.Initializer.Module
{
    public class ModuleConfig
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }

        public bool IsViewModule{ get; set; }
    }
}
