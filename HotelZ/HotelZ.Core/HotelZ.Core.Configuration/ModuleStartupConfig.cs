namespace HotelZ.Core.Configuration
{
    public class ModuleStartupConfig
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }

        public ModuleStartupConfig ViewModule { get; set; }
    }
}
