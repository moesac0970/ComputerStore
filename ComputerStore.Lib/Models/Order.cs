using System.Collections.Generic;

namespace ComputerStore.Lib.Models
{
    public class Order : EntityBase
    {
        public User PlatformUser { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }

    }
}
