using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using BlazorWebApp.Shared.Services;

namespace BlazorWebApp.Shared.Data
{
    public class BugDataAdaptor : DataAdaptor
    {

        ClientServices BugDetails = new ClientServices(new HttpClient());
        public override async Task<object> ReadAsync ( DataManagerRequest dataManagerRequest, string key = null )
        {
            List<Bug> bugs = await BugDetails.GetBugs();
            int count = await BugDetails.GetBugCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }
        public override async Task<object> InsertAsync ( DataManager dataManager, object data, string key )
        {
            await BugDetails.InsertBug(data as Bug);
            return data;
        }
        public override async Task<object> UpdateAsync ( DataManager dataManager, object data, string keyField, string key )
        {
            await BugDetails.UpdateBug(data as Bug);
            return data;
        }
        public override async Task<object> RemoveAsync ( DataManager dataManager, object primaryKeyValue, string keyField, string key )
        {
            await BugDetails.RemoveBug(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
