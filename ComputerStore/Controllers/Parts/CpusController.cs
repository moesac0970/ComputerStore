using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models.Parts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CpusController : ControllerCrudBase<Cpu, PartRepository<Cpu>>
    {
        public CpusController(PartRepository<Cpu> partRepository) : base(partRepository)
        {
        }


    }
}
