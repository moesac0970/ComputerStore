using ComputerStore.Web.Helper;
using ComputerStore.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Web.Components
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationComponent : ViewComponent
    {
        private IList<NavigationVm> PublicLinks { get; set; }
        private IList<NavigationVm> AdminLinks { get; set; }
        private IList<NavigationVm> MemberLinks { get; set; }
        private IList<NavigationVm> UserLinks { get; set; }

        private WebApiHelper webApiHelper;
        string baseUri;

        public NavigationComponent(IConfiguration configuration)
        {
            webApiHelper = new WebApiHelper();
            baseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;

            IEnumerable<LinkedNavigation> linkedNavigationHome = new List<LinkedNavigation>
            {
                // categories, products, cart, checkout, contact
                new LinkedNavigation{ Page="PcParts", IsActive = true, Text = "Products"},
                new LinkedNavigation{ Page="Cart",  IsActive = true, Text = "Cart"},
                new LinkedNavigation{ Page="CheckOut",  IsLoggedIn = true, IsActive = false, Text = "CheckOut" },
                new LinkedNavigation{ Page="Contact",  Text= "Contact", IsActive = true}
            };

            // categories: enum of the diffrent categories 
            List<LinkedNavigation> linkedNavigationsCategory = new List<LinkedNavigation>();

            // api call to get categories
            var categories = WebApiHelper.GetApiResult<string[]>(baseUri + "pcparts/Categories");
            foreach (var item in categories)
            {
                linkedNavigationsCategory.Add(new LinkedNavigation
                {
                    Page = item,
                    IsActive = true,
                    IsLoggedIn = false,
                    Text = item
                });
            }


            // publicLinks 
            PublicLinks = new List<NavigationVm>
            {
                new NavigationVm { Page="/index", Text="Home", LinkedNavigations = linkedNavigationHome, IsLinkedNav = true},
                new NavigationVm { Page="/PcParts", Text="Products", IsActive=true, IsLinkedNav = true, LinkedNavigations = linkedNavigationsCategory.OrderBy(l => l.Page)},
                new NavigationVm { Page="/PcBuilds", Text="PcBuilds", IsActive = true , IsLinkedNav = false },
                new NavigationVm { Page="/Contact", Text="Contact", IsActive = true, IsLinkedNav = false },
                new NavigationVm { Page="/orders", Text="My Orders" , IsLoggedIn=true, IsActive = true, IsLinkedNav = false},
            };

            // adminLinks
            AdminLinks = new List<NavigationVm>
            {
                new NavigationVm { Area="admin", Page="/manage/parts/index", Text="Manage Parts"},
                new NavigationVm { Area="admin", Page="/manage/Makers/index", Text="Manage Makers"}


            };

            // userLinks
            UserLinks = new List<NavigationVm>
            {
                new NavigationVm { Area="Identity", Page="/Forum/index", Text="Forum"}
            };

        }

        public async Task<IViewComponentResult> InvokeAsync(string signedInUser)
        {
            if (signedInUser == "admin")
            {
                foreach (var link in AdminLinks)
                {
                    PublicLinks.Add(link);
                }
            }
            if (signedInUser == "user")
            {
                foreach (var link in UserLinks)
                {
                    PublicLinks.Add(link);
                }
            }
            var navLinks = PublicLinks;
            foreach (var link in navLinks)
            {
                if (this.RouteData.Values["page"]?.ToString().ToLower() == link.Page.ToLower())
                {
                    link.IsActive = true;
                }
            }
            return await Task.FromResult<IViewComponentResult>(View(navLinks));
        }

    }
}
