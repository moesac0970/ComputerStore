using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController : ControllerCrudBase<Message, MessageRepository>
    {
        public MessagesController(MessageRepository messageRepository) : base(messageRepository)
        {
        }

        [HttpGet]
        [Route("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {

            if (userId == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await repository.GetByUserId(userId));
            }
        }

        [HttpPost]
        [Authorize]
        [Route("PostMessage")]
        public async Task<IActionResult> PostMessage(Message message)
        {
            var result = await repository.Add(message);
            return Ok();
        }

    }
}
