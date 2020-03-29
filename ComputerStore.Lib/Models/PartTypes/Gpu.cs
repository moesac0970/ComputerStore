namespace ComputerStore.Lib.Models.Parts
{
    public class Gpu : PartBase
    {
        public double PowerUsage { get; set; }
        public string Description { get; set; }
        public double Memory { get; set; }
        public double Frequency { get; set; }
        public double BoostFrequency { get; set; }
        public MemoryType MemoryType { get; set; }
        public string Ports { get; set; }
        public string Os { get; set; }
        public string Connection { get; set; }



    }
}
