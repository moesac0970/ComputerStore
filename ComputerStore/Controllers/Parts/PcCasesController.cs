using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models.Parts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PcCasesController : ControllerCrudBase<PcCase, PartRepository<PcCase>>
    {
        public PcCasesController(PartRepository<PcCase> partRepository) : base(partRepository)
        {
        }
    }
}
