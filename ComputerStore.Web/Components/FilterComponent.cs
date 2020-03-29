using ComputerStore.Web.Helper;
using ComputerStore.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Web.Components
{
    [ViewComponent(Name = "Filter")]
    public class FilterComponent : ViewComponent
    {

        IConfiguration config;
        private IEnumerable<FilterVm> FilterCategories { get; set; }
        private List<string> categories { get; set; }
        public FilterComponent(IConfiguration _configuration)
        {
            config = _configuration;
            string baseUri = config.GetSection("Data").GetSection("ApiBaseUri").Value;
            categories = WebApiHelper.GetApiResult<List<string>>(baseUri + "pcparts/Categories");
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<FilterVm> ApiCategories = new List<FilterVm>();
            foreach (var category in categories)
            {
                ApiCategories.Add(new FilterVm { CategoryName = category.ToLower() });
            }
            FilterCategories = ApiCategories;

            return await Task.FromResult<IViewComponentResult>(View(FilterCategories));
        }

    }
}
