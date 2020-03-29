using ComputerStore.Api.Repositories;
using ComputerStore.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersRepository db;
        private readonly BearerHistoryRepository BearerRepo;
        public AuthController(UsersRepository context, BearerHistoryRepository bearerHistoryRepository)
        {
            db = context;
            BearerRepo = bearerHistoryRepository;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Token()
        {

            //todo: simplify constructor
            BearerTokenService generator = new BearerTokenService(db, BearerRepo);
            var token = await generator.GenerateBearerToken(Request);

            if (token != "not valid user" || token != "wrong request")
            {
                return Ok(token);
            }
            return BadRequest(token);

        }
    }
}
