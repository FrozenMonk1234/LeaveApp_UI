using LeaveApp_UI.Data;
using LeaveApp_UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<bool> CreateLeave(Models.Leave model)
        {
            bool result = false;
            var url = Enpoints.CreateLeave;
            HttpClient client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<bool>(responseData);
            }

            return result;
        }

        public async Task<List<Models.Leave>> GetAllLeaveByUserId(int Id)
        {
            List<Models.Leave> result = new List<Models.Leave>();
            var url = Enpoints.GetAllLeaveByUserId + $"?Id={Id}";
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var reponse = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Models.Leave>>(reponse);
            }
            return result;
        }

        public async Task<List<TypeOfLeave>> GetAllTypeOfLeave()
        {
            List<TypeOfLeave> result = new List<TypeOfLeave>();
            var url = Enpoints.GetAllTypeOfLeave;
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var reponse = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<TypeOfLeave>>(reponse);
            }
            return result;
        }
    }
}
