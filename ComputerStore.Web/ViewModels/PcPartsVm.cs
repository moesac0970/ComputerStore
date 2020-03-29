using ComputerStore.Web.Models;
using System.Collections.Generic;

namespace ComputerStore.Web.ViewModels
{
    public class PcPartsVm : PaginateModel
    {
        public string Name { get; set; }
        public bool Hot { get; set; }
        public double Price { get; set; }
        public IEnumerable<string> ImageNames { get; set; }

    }
}
