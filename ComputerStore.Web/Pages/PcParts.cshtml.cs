using ComputerStore.Web.Services;
using ComputerStore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Web.Pages
{
    public class PcPartsModel : PageModel
    {

        private readonly PcPartService<PcPartsVm> _partService;
        string url;
        public PcPartsModel(PcPartService<PcPartsVm> partService, IConfiguration configuration)
        {
            _partService = partService;
            url = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 8;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<PcPartsVm> Data { get; set; }

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;

        public async Task OnGetAsync(int CurrentPage = 1)
        {
            Data = await _partService.GetPaginatedResult(CurrentPage, url + "pcparts/basic", PageSize);
            Count = await _partService.GetCount(url + "pcparts/basic");
        }
    }
}
