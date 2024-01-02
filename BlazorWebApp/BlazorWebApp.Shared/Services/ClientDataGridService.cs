using BlazorWebApp.Shared.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApp.Shared.Services
{
    public class ClientServices
    {
        private readonly HttpClient _httpClient;

        public ClientServices ( HttpClient httpClient )
        {
            _httpClient = httpClient;

        }

        public async Task<List<Bug>> GetBugs ()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Bug>>("https://localhost:7112/api/DataGrid");

            return result;
        }


        public async Task<Bug> InsertBug ( Bug value )
        {
            await _httpClient.PostAsJsonAsync<Bug>($"https://localhost:7112/api/DataGrid/", value);
            return value;
        }
        public async Task<int> RemoveBug ( int BugId )
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:7112/api/DataGrid/{BugId}");

            return BugId;
        }

        public async Task<Bug> UpdateBug ( Bug updatedBug )
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"https://localhost:7112/api/DataGrid/", updatedBug);

            return updatedBug;

        }
        public async Task<int> GetBugCountAsync ()
        {
            var response = await _httpClient.GetAsync("https://localhost:7112/api/DataGrid/BugCount");

            if (response.IsSuccessStatusCode)
            {
                // Assuming the API returns an integer value for bug count
                int bugCount = await response.Content.ReadFromJsonAsync<int>();
                return bugCount;
            }
            else
            {
                // Handle the error response
                // You might want to return a default value or throw an exception
                return 0;
            }

        }
    }
}
