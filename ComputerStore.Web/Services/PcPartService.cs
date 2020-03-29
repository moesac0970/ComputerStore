using ComputerStore.Web.Helper;
using ComputerStore.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Web.Services
{
    public class PcPartService<T> : IPaginatedModel<T>
        where T : PaginateModel
    {
        public PcPartService()
        {
        }

        public async Task<List<T>> GetPaginatedResult(int currentPage, string url, int pageSize = 10)
        {
            var data = GetData(url);
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<int> GetCount(string url)
        {
            var data = GetData(url);
            return data.Count;
        }


        //  not async but could be
        private List<T> GetData(string url)
        {
            return WebApiHelper.GetApiResult<List<T>>(url);
        }
    }
}
