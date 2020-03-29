using ComputerStore.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Api.Services
{
    public class BearerTokenService
    {
        private readonly UsersRepository db;
        private BearerHistoryRepository BearerRepo;

        public BearerTokenService(UsersRepository context, BearerHistoryRepository bearerHistoryRepository)
        {
            db = context;
            BearerRepo = bearerHistoryRepository;
        }
        public async Task<string> GenerateBearerToken(HttpRequest request)
        {
            var header = request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {
                // header begins with 'Basic', and after follows base64encoded logincredentials 
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                // logincredentials decoded from base64 and put into variable
                var username = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //admin:pass
                // put into string array 
                var user = db.GetUserByNameAsync(username);


                if (user != null)
                {
                    var roles = await db.GetRolesById(user.Id);

                    var claimsdata = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

                    foreach (var role in roles)
                    {
                        claimsdata.Add(new Claim(ClaimTypes.Role, role.Name));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lkjqsdflkjsdfkljqsdfkljqsdlkfjslqdkfjlskdfjlskqdjfhlk"));
                    var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                         issuer: "computerstore.be",
                         audience: "computerstore.be",
                         expires: DateTime.Now.AddDays(300),
                         claims: claimsdata,
                         signingCredentials: signInCred
                        );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    //Update BearerHistory DB
                    await BearerRepo.CreateBearerHistory(tokenString, user);


                    return tokenString;
                }
                return "not valid user";
            }
            return "wrong request";
        }


    }
}
