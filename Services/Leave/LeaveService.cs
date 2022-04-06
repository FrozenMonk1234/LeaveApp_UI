using LeaveApp_UI.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeaveApp_UI.Services.Leave
{
    public class LeaveService : ILeaveService
    {
        private readonly IHttpClientFactory _httpClient;
        public LeaveService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> CreateLeave(Models.Leave model)
        {
            var url = Enpoints.CreateUser;
            bool result = false;
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<bool>(responseData);
            }

            if (result)
            {
                return "Created Successfully";
            }
            else
            {
                return "Failed to create. Contact your administrator";
            }
        }

        public async Task<List<Models.Leave>> GetAllLeaveRecordsByUserId(int Id)
        {
            var url = Enpoints.GetAllLeaveRecordsByUserId;
            List<Models.Leave> result = new List<Models.Leave>();
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Models.Leave>>(responseData);
            }

            if (result.Any())
            {
                return result;
            }
            else
            {
                throw new NullReferenceException("Failed to get list");
            }
        }

        public async Task<Models.Leave> GetLeaveById(int Id)
        {
            var url = Enpoints.GetAllLeaveRecordsByUserId;
            Models.Leave result = new Models.Leave();
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Models.Leave>(responseData);
            }

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException("Failed to get model");
            }
        }
    }
}
