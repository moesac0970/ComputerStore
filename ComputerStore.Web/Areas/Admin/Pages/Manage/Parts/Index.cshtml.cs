using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ComputerStore.Web.Areas.Admin.Pages.Manage
{
    [Authorize("AdminRole")]
    public class PartsModel : PageModel
    {
        public IEnumerable<PcPart> Pcparts;
        public PartsModel(IConfiguration configuration)
        {
        }

        public void OnGet()
        {
        }

    }
}
