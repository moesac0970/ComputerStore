using ComputerStore.Web.Helper;
using ComputerStore.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Web.Components
{
    [ViewComponent(Name = "Catalog")]
    public class CatalogComponent : ViewComponent
    {
        string baseUri = "";
        List<CatalogVm> catalogItems = new List<CatalogVm>();

        public CatalogComponent(IConfiguration configuration)
        {
            baseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
            catalogItems = WebApiHelper.GetApiResult<List<CatalogVm>>(baseUri + "pcparts/basic");
        }
        public async Task<IViewComponentResult> InvokeAsync(CatalogParamVm catalogParam)
        {
            if (catalogParam.PartId == 0)
            {

                if (catalogParam.Range != 0)
                {
                    var rnd = new Random();
                    int skipRnd = rnd.Next(1, catalogItems.Count() - catalogParam.Range);
                    return await Task.FromResult<IViewComponentResult>(View(catalogItems.Skip(Convert.ToInt32(skipRnd)).Take(catalogParam.Range)));
                }
                else
                {
                    return await Task.FromResult<IViewComponentResult>(View(catalogItems));
                }
            }
            else
            {
                return await Task.FromResult<IViewComponentResult>(View(catalogItems.Where(c => c.Id == catalogParam.PartId)));
            }
        }
    }
}
