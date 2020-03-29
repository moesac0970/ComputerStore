using AutoMapper;
using ComputerStore.Data;
using ComputerStore.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Api.Repositories
{
    /// <summary>
    /// part repo with T type partbase to encapsulate all methods regarding parts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PartRepository<T> : MappingRepository<T> where T : PartBase
    {
        public PartRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<T> GetById(int id)
        {
            return await db.Set<T>()
                .Where(e => e.Id == id)
                .Include(e => e.PcPart)
                .ThenInclude(e => e.Images)
                .FirstOrDefaultAsync();
        }

    }
}
