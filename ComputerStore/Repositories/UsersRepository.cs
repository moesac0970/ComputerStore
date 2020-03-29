using ComputerStore.Data;
using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Api.Repositories
{
    public class UsersRepository
    {

        private readonly DataContext db;

        public UsersRepository(DataContext context)
        {
            db = context;
        }

        public async Task<IQueryable<User>> GetUsersAsync()
        {
            var users = db.Users.ToList().AsQueryable();
            return await Task.FromResult(users);
        }

        public User GetUserByNameAsync(string UserName)
        {
            var user = db.Users
                .Where(u => u.Email == UserName || u.UserName == UserName)
                .FirstOrDefault();

            return user;
        }

        public async Task<List<IdentityRole<string>>> GetRolesById(string id)
        {
            var claims = await db.UserRoles
                                .Where(ur => ur.UserId == id)
                                .ToListAsync();

            List<IdentityRole<string>> roles = new List<IdentityRole<string>>();
            foreach (var claim in claims)
            {
                roles.Add(db.Roles
                            .Where(r => r.Id == claim.RoleId)
                            .FirstOrDefault());
            }

            return roles;

        }

        public async Task<User> UpdateUser(User user)
        {
            var oldUser = db.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            db.Users.Remove(oldUser);
            db.Users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<User> GetUserByBearerAsync(string bearer)
        {
            //get user by bearer with include
            var userBearer = await db.BearerHistories
                    .Include(b => b.User)
                    .Where(b => b.BearerToken == bearer)
                    .FirstOrDefaultAsync();
            var user = userBearer.User;
            return user;
        }
    }
}
