
using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MakersController : ControllerCrudBase<Maker, MakerRepository>
    {
        public MakersController(MakerRepository makerRepository) : base(makerRepository)
        {
        }
    }
}
