using ComputerStore.Lib.Dto;
using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.Parts;
using ComputerStore.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ComputerStore.Web.Areas.Admin.Pages.Manage.Parts
{
    [Authorize("AdminRole")]
    public class DetailModel : PageModel
    {
        public IPcPart Part;
        public PcPartBasic basicPart;
        public string type;
        public PropertyInfo[] Properties;

        private readonly string baseUri = "";

        public DetailModel(IConfiguration configuration)
        {
            baseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
        }

        public void OnGet(int id)
        {
            basicPart = WebApiHelper.GetApiResult<PcPartBasic>(baseUri + "pcparts/basic/" + id);
            switch (basicPart.Type)
            {
                case "Cpu":
                    Part = WebApiHelper.GetApiResult<Cpu>(baseUri + "pcparts/PartByPartId/" + id) ?? new Cpu { };
                    Properties = Part.GetType().GetProperties();
                    break;
                case "Gpu":
                    Part = WebApiHelper.GetApiResult<Gpu>(baseUri + "pcparts/PartByPartId/" + id) ?? new Gpu();
                    Properties = Part.GetType().GetProperties();
                    break;
                case "PcCase":
                    Part = WebApiHelper.GetApiResult<PcCase>(baseUri + "pcparts/PartByPartId/" + id) ?? new PcCase();
                    Properties = Part.GetType().GetProperties();
                    break;
                case "Memory":
                    Part = WebApiHelper.GetApiResult<Memory>(baseUri + "pcparts/PartByPartId/" + id) ?? new Memory();

                    Properties = Part.GetType().GetProperties();
                    break;
                case "MotherBoard":
                    Part = WebApiHelper.GetApiResult<MotherBoard>(baseUri + "pcparts/PartByPartId/" + id) ?? new MotherBoard();
                    Properties = Part.GetType().GetProperties();
                    break;
                default:
                    Properties = null;
                    break;
            }
        }
    }
}
