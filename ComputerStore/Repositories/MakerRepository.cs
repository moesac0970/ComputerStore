using AutoMapper;
using ComputerStore.Data;
using ComputerStore.Lib.Models;

namespace ComputerStore.Api.Repositories
{
    public class MakerRepository : MappingRepository<Maker>
    {
        public MakerRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
