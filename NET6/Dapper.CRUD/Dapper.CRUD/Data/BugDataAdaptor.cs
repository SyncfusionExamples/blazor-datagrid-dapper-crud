using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace Dapper.CRUD.Data
{
    public class BugDataAdaptor : DataAdaptor
    {
        private BugDataAccessLayer _dataLayer;
        public BugDataAdaptor(BugDataAccessLayer bugDataAccessLayer)
        {
            _dataLayer = bugDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Bug> bugs = await _dataLayer.GetBugsAsync();
            int count = await _dataLayer.GetBugCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddBugAsync(data as Bug);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateBugAsync(data as Bug);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveBugAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
