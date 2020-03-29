using ComputerStore.Lib.Models;
using ComputerStore.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Web.Areas.Identity.Pages.Forum
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private string baseUri;

        public PcBuildChatVm PcBuildChatVm;

        public IndexModel(IConfiguration configuration, UserManager<User> _userManager)
        {
            userManager = _userManager;
            baseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;

        }
        public async Task OnGet()
        {
            var currentUser = await userManager.GetUserAsync(User);
            PcBuildChatVm = new PcBuildChatVm
            {
                Messages = WebApiHelper.GetApiResult<List<Message>>(baseUri + "messages") ?? null,
                UserId = currentUser.Id
            };
        }
    }

    public class PcBuildChatVm
    {
        public string UserId { get; set; }
        public List<Message> Messages { get; set; }
    }
}
