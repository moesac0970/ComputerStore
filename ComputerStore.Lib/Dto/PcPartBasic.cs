using System.Collections.Generic;

namespace ComputerStore.Lib.Dto
{
    /// <summary>
    /// basic pc part for the catalog component
    /// </summary>
    public class PcPartBasic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Hot { get; set; }
        public double Price { get; set; }
        public IEnumerable<string> ImageNames { get; set; }
        public string Type { get; set; }
    }
}
