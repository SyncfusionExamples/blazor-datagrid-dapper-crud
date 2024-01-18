using Microsoft.AspNetCore.Mvc;
using Dapper;
using BlazorWebApp.Shared.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace BlazorWebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGridController : ControllerBase
    {
        public IConfiguration Configuration;
        private const string BUGTRACKER_DATABASE = "BugTrackerDatabase";
        private const string SELECT_BUG = "select * from bugs";
        public DataGridController ( IConfiguration configuration )
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        [HttpGet]
        public async Task<ActionResult<List<Bug>>> Get ()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                IEnumerable<Bug> result = await db.QueryAsync<Bug>(SELECT_BUG);
                return result.ToList();
            }
        }
        [HttpGet("BugCount")]
        public async Task<ActionResult<int>> GetBugCountAsync ()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
                {
                    db.Open();
                    int bugCount = await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM bugs");
                    return Ok(bugCount);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "Internal Server Error");
            }
        }
    

    [HttpPost]

        public async Task<ActionResult<Bug>> Post ( Bug value )
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("insert into bugs (Summary, BugPriority, Assignee, BugStatus) values (@Summary, @BugPriority, @Assignee, @BugStatus)", value) ;
            }
            return Ok(value);
        }

        [HttpPut]
        public async Task<ActionResult<Bug>> Put ( Bug updatedBook )
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update bugs set Summary=@Summary, BugPriority=@BugPriority, Assignee=@Assignee, BugStatus=@BugStatus where id=@Id", updatedBook);
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete ( long id )
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from bugs Where id=@BugId", new { BugId = id });
            }
            return NoContent();
        }
    }
}
