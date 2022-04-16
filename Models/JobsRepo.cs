using System.Data.SqlClient;
using WebApplication1.Database;
using System.Data;

namespace WebApplication1.Models
{
    public class JobsRepo : IJobsRepo
    {
        int rowCount;

        DbContext dbContext = new();

        public JobsRepo()
        {
            RowCount();
        }

        public Task<DataTable> Get(int id)
        {
            return Task.FromResult(dbContext.Select(id));
        }

        public Task Delete(int id)
        {
            return Task.FromResult(dbContext.Delete(id));
        } 

        public Task<DataTable> Insert(Jobs job)
        {
            if (rowCount == 0)
            {
                job.Id = 1001;
                job.Code = "JOB-" + 01;
                job.LocId = 10001;
                job.DeptId = 2001;
            }
            else
            {
                job.Id = 1001 + rowCount;
                job.Code = rowCount < 10 ? ("JOB-0" + (rowCount + 1)) : ("JOB-" + rowCount + 1);
                job.LocId = 10001 + rowCount;
                job.DeptId = 2001 + rowCount;
            }

            //DateTime PostedDate = job.PostedDate;
            //postedDate = PostedDate.ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            //job.PostedDate = DateTime.Parse(postedDate);

            //DateTime ClosingDate = job.ClosingDate;
            //closingDate = ClosingDate.ToString("yyyy-MM-dd'T'HH:mm:ssZ");
            //jobs.ClosingDate = DateTime.Parse(closingDate);

            return Task.FromResult(dbContext.Insert(job));
        }

        public Task<int> RowCount()
        {
            rowCount = dbContext.GetRowCount();
            return Task.FromResult(rowCount);
        }
    }
}
