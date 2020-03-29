using AutoMapper;
using ComputerStore.Data;
using ComputerStore.Lib.Models;

namespace ComputerStore.Api.Repositories
{
    public class OrderRepository : MappingRepository<Order>
    {
        public OrderRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
