using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Web.Services
{

    public class ClientBearerService
    {
        /// <summary>
        /// accepts the base uri for the endpoint  the 'auth/token' is added in the request
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<string> SendBearerRequest(string uri, string email)
        {
            var webRequest = WebRequest.Create(uri + "auth/token");
            webRequest.Headers["Authorization"] = "Basic "
                                                            + Convert.ToBase64String(Encoding.Default.GetBytes(email
                                                            ));
            webRequest.Method = "POST";

            // repsons from auth controller containing the bearer token 
            var respons = await webRequest.GetResponseAsync();
            var responsstream = respons.GetResponseStream();
            var reader = new StreamReader(responsstream);
            var bearerToken = reader.ReadToEnd();
            return bearerToken;
        }
    }
}
