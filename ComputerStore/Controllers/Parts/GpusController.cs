using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models.Parts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GpusController : ControllerCrudBase<Gpu, PartRepository<Gpu>>
    {
        public GpusController(PartRepository<Gpu> gpuRepository) : base(gpuRepository)
        {
        }
    }
}
