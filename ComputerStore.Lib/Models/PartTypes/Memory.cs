namespace ComputerStore.Lib.Models.Parts
{
    public class Memory : PartBase
    {
        public double Capacity { get; set; }
        public double Cache { get; set; }
        public double Speed { get; set; }
        public double PowerUsage { get; set; }
        public double Weight { get; set; }
        public string Interface { get; set; }
        public string Description { get; set; }

    }
}
