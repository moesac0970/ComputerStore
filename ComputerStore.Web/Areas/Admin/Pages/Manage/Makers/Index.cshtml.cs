using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ComputerStore.Web.Areas.Admin.Pages.Manage.Makers
{
    [Authorize("AdminRole")]
    public class IndexModel : PageModel
    {

        public IndexModel(IConfiguration configuration)
        {
        }

        public void OnGet()
        {
        }
    }
}
