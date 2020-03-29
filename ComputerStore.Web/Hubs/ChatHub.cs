using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ComputerStore.Web.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<User> userManager;
        private string baseUri;
        public ChatHub(UserManager<User> _userManager, IConfiguration configuration)
        {
            userManager = _userManager;
            baseUri = configuration.GetSection("Data").GetSection("ApiBaseUri").Value;
        }
        public async Task SendMessage(string user, string message, string bearerToken)
        {
            var usr = await userManager.FindByIdAsync(user);
            HttpClient client = new HttpClient();

            // add bearer token to client
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);

            // message to post to the endpoint
            Message postMessage = new Message { CreationDate = DateTime.UtcNow, Text = message, UserId = user, UserName = usr.UserName };



            await client.PostAsJsonAsync(baseUri + "messages/PostMessage", postMessage);
            await Clients.All.SendAsync("ReceiveMessage", usr.UserName, message);
        }
    }
}
