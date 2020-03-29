using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ComputerStore.Web.Areas.Identity.IdentityHostingStartup))]
namespace ComputerStore.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}