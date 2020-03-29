using AutoMapper;
using ComputerStore.Data;
using ComputerStore.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Api.Repositories
{
    public class MessageRepository : MappingRepository<Message>
    {


        public MessageRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<Message>> GetByUserId(string id)
        {
            return await db.Messages.Where(m => m.UserId == id).ToListAsync();
        }


    }
}
