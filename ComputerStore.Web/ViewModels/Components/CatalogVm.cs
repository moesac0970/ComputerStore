using System.Collections.Generic;

namespace ComputerStore.Web.ViewModels.Components
{
    public class CatalogVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Hot { get; set; }
        public double Price { get; set; }
        public IEnumerable<string> ImageNames { get; set; }

    }
}
