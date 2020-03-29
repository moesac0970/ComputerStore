using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models.Parts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemorysController : ControllerCrudBase<Memory, PartRepository<Memory>>
    {
        public MemorysController(PartRepository<Memory> partRepository) : base(partRepository)
        {
        }
    }
}
