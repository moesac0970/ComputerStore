using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Web.Components
{
    [ViewComponent(Name = "Carousel")]
    public class CarouselComponent : ViewComponent
    {
        string baseUri = "";
        public IEnumerable<PcPart> PcParts;

        public CarouselComponent(IConfiguration configuration)
        {
            //mogelijkheid voor de iets mee te geven in de component, voorbeeld uitgewerkt met pcparts
            //baseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
            //PcParts = WebApiHelper.GetApiResult<List<PcPart>>(baseUri + "pcparts");

        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
