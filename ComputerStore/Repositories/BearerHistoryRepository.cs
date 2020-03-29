using ComputerStore.Data;
using ComputerStore.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Api.Repositories
{
    public class BearerHistoryRepository
    {
        public DataContext db;

        public BearerHistoryRepository(DataContext context)
        {
            db = context;
        }

        public async Task<BearerHistory> CreateBearerHistory(string token, User user)
        {

            var bearerEntity = new BearerHistory { BearerToken = token, User = user };

            db.Set<BearerHistory>().Add(bearerEntity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return bearerEntity;
        }

        public async Task<User> GetUserFromBearer(string bearer)
        {
            var userBearer = await db.BearerHistories
                    .Include(b => b.User)
                    .Where(b => b.BearerToken == bearer)
                    .FirstOrDefaultAsync();
            var user = userBearer.User;
            return user;
        }
    }
}
