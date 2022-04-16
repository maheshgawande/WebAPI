using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class DbContext
    {
        string connetionString;
        string query = "";
        SqlCommand cmd = null;

        SqlConnection cnn = new SqlConnection();
        DataTable JobsDetails = new DataTable();
        DataTable Output = new DataTable();

        private void FillData()
        {
            query = "SELECT * FROM JobsDetails";

            try
            {
                if (cnn.State.ToString().Equals("Closed"))
                {
                    cnn.Open();
                }

                cmd = new SqlCommand(query, cnn);
                JobsDetails.Load(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (cnn.State.ToString().Equals("Open"))
                {
                    cnn.Close();
                }
            }

        }

        public DbContext()
        {
            connetionString = @"Server = DESKTOP-PPGD0B1\SQLEXPRESS; Database = JobsDb; Integrated Security = True;";
            
            try
            {
                cnn = new SqlConnection(connetionString);
                Jobs jobs = new Jobs();
                FillData();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public DataTable Select(int id)
        {
            DataRow[] row = JobsDetails.Select("id=" + id.ToString());
            Output.Rows.Add(row);

            return Output;
        }

        public DataTable Insert(Jobs jobs)
        {
            try
            {
                query = $"INSERT INTO JobsDetails VALUES({jobs.Id}, '{jobs.Code}', '{jobs.Title}', '{jobs.Desc}', {jobs.LocId}, {jobs.DeptId}, '{jobs.PostedDate}', '{jobs.ClosingDate}');";
                cmd = new SqlCommand(query, cnn);

                if (cnn.State.ToString().Equals("Closed"))
                {
                    cnn.Open();
                }

                int n=cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (cnn.State.ToString().Equals("Open"))
                {
                    cnn.Close();
                }
            }

            FillData();

            return JobsDetails;
        }
        public DataTable Delete(int id)
        {
            query = $"DELETE FROM JobsDetails WHERE ID = {id}";

            try
            {
                if (cnn.State.ToString().Equals("Close"))
                {
                    cnn.Open();
                }

                cmd = new SqlCommand(query, cnn);
                cmd.ExecuteNonQuery();

                FillData();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (cnn.State.ToString().Equals("Open"))
                {
                    cnn.Close();
                }
            }


            return JobsDetails;

        }

        public int GetRowCount()
        {
            return JobsDetails.Rows.Count;
        }
    }
}
