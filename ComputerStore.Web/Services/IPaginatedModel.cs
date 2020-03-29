using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Web.Services
{
    public interface IPaginatedModel<T>
    {
        Task<List<T>> GetPaginatedResult(int currentPage, string url, int pageSize = 10);
        Task<int> GetCount(string url);
    }
}
