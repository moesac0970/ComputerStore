namespace ComputerStore.Lib.Models
{
    public class PartBase : EntityBase, IPcPart
    {
        public virtual PcPart PcPart { get; set; }
        public int PcPartId { get; set; }
    }
}
