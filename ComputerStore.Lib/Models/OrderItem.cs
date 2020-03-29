namespace ComputerStore.Lib.Models
{
    public class OrderItem : EntityBase
    {
        public Order Order { get; set; }
        public bool? IsDelivered { get; set; }
        public PcPart PcParts { get; set; }
        public int Quantity { get; set; }

    }
}
