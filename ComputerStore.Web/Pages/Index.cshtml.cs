using ComputerStore.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComputerStore.Web.Pages
{
    public class IndexModel : PageModel
    {
        public CatalogParamVm catalogParamVm;
        public void OnGet()
        {
            catalogParamVm = new CatalogParamVm
            {
                PartId = 0,
                Range = 8
            };
        }
    }
}
