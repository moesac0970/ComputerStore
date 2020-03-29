using ComputerStore.Lib.Models.PartTypes.Enumerations;

namespace ComputerStore.Lib.Models
{
    public class Image : EntityBase
    {
        public virtual PcPart PcPart { get; set; }
        public int PcPartId { get; set; }

        public PartType Parttype { get; set; }
        public string FileName { get; set; }
        public double WeightMb { get; set; }
        public string Type { get; set; }
    }
}
