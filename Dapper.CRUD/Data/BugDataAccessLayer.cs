using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.CRUD.Data
{
    public class BugDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string BUGTRACKER_DATABASE = "BugTrackerDatabase";
        private const string SELECT_BUG = "select * from bugs";
        public BugDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Bug>> GetBugsAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                IEnumerable<Bug> result = await db.QueryAsync<Bug>(SELECT_BUG);
                return result.ToList();
            }
        }

        public async Task<int> GetBugCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from bugs");
                return result;
            }
        }

        public async Task AddBugAsync(Bug bug)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("insert into bugs (Summary, BugPriority, Assignee, BugStatus) values (@Summary, @BugPriority, @Assignee, @BugStatus)", bug);
            }
        }

        public async Task UpdateBugAsync(Bug bug)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update bugs set Summary=@Summary, BugPriority=@BugPriority, Assignee=@Assignee, BugStatus=@BugStatus where id=@Id", bug);
            }
        }

        public async Task RemoveBugAsync(int bugid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from bugs Where id=@BugId", new { BugId = bugid });
            }
        }
    }
}
