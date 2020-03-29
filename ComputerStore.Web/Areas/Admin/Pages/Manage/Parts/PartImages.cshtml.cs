using ComputerStore.Web.Helper;
using ComputerStore.Web.ViewModels.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ComputerStore.Web.Areas.Admin.Pages.Manage.Parts
{
    [Authorize("AdminRole")]
    public class PartImagesModel : PageModel
    {

        private string baseUri = "";

        public PartImagesModel(IConfiguration configuration)
        {
            baseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
        }



        public CatalogParamVm catalogParamVm;

        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        [Display(Name = "ImageFile")]
        public IFormFile ImageFile { get; set; }


        public void OnGet(int? id)
        {
            catalogParamVm = new CatalogParamVm
            {
                Range = 0,
                PartId = id ?? 0
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                await WebApiHelper.PostCallAPI<HttpResponse, IFormFile>(baseUri + $"pcparts/ImageUpload/?partId={catalogParamVm.PartId}", ImageFile);
                return LocalRedirect("/");
            }
            return LocalRedirect("/");


        }
    }
}
