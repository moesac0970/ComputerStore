using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.Parts;
using ComputerStore.Web.Helper;
using ComputerStore.Web.ViewModels;
using ComputerStore.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ComputerStore.Web.Pages
{
    public class PcPartDetailModel : PageModel
    {
        public string BaseUri;
        public PcPartItem PcPart;
        public CatalogParamVm catalogParamVm;
        public PropertyInfo[] Properties;
        public IPcPart Part;

        public PcPartDetailModel(IConfiguration configuration)
        {
            BaseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
        }
        public void OnGet(int id)
        {
            catalogParamVm = new CatalogParamVm
            {
                Range = 4
            };
            PcPart = WebApiHelper.GetApiResult<PcPartItem>(BaseUri + "pcparts/basic/" + id);
            switch (PcPart.Type)
            {
                case "Cpu":
                    Part = WebApiHelper.GetApiResult<Cpu>(BaseUri + "pcparts/PartByPartId/" + id) ?? new Cpu { };
                    Properties = Part.GetType().GetProperties();
                    break;
                case "Gpu":
                    Part = WebApiHelper.GetApiResult<Gpu>(BaseUri + "pcparts/PartByPartId/" + id) ?? new Gpu();
                    Properties = Part.GetType().GetProperties();
                    break;
                case "PcCase":
                    Part = WebApiHelper.GetApiResult<PcCase>(BaseUri + "pcparts/PartByPartId/" + id) ?? new PcCase();
                    Properties = Part.GetType().GetProperties();
                    break;
                case "Memory":
                    Part = WebApiHelper.GetApiResult<Memory>(BaseUri + "pcparts/PartByPartId/" + id) ?? new Memory();

                    Properties = Part.GetType().GetProperties();
                    break;
                case "MotherBoard":
                    Part = WebApiHelper.GetApiResult<MotherBoard>(BaseUri + "pcparts/PartByPartId/" + id) ?? new MotherBoard();
                    Properties = Part.GetType().GetProperties();
                    break;
                default:
                    Properties = null;
                    break;
            }

        }
    }
}
