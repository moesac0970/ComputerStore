namespace ComputerStore.Lib.Models.Parts
{
    public class MotherBoard : PartBase
    {
        public string Chipset { get; set; }
        public string Inputs { get; set; }
        public string Usage { get; set; }
        public double MaxMemory { get; set; }
        public MemoryType SupportedMemoryType { get; set; }
        public int MemorySlotCount { get; set; }
        public string BiosType { get; set; }
        public string Description { get; set; }


    }
}
