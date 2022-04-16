using System.Data;

namespace WebApplication1.Models
{
    public interface IJobsRepo
    {
        Task<DataTable> Get(int id);
        Task Delete(int id);
        Task<DataTable> Insert(Jobs job);
        Task<int> RowCount();
    }
}
