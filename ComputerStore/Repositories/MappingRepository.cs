using AutoMapper;
using ComputerStore.Data;
using ComputerStore.Lib.Models;

namespace ComputerStore.Api.Repositories
{
    public class MappingRepository<T> : Repository<T> where T : EntityBase
    {
        protected readonly IMapper mapper;
        public MappingRepository(DataContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
    }
}
