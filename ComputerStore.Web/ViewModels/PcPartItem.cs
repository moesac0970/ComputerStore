using System.Collections.Generic;

namespace ComputerStore.Web.ViewModels
{
    public class PcPartItem
    {
        public string Name { get; set; }
        public bool Hot { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public IEnumerable<string> ImageNames { get; set; }
    }
}
