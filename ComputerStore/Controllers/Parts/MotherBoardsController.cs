using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models.Parts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotherBoardsController : ControllerCrudBase<MotherBoard, PartRepository<MotherBoard>>
    {
        public MotherBoardsController(PartRepository<MotherBoard> partRepository) : base(partRepository)
        {
        }
    }
}
