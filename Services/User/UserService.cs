using LeaveApp_UI.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApp_UI.Services.User
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClient;
        public UserService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Models.User> CreateUser(Models.User model)
        {
            var url = Enpoints.CreateUser;
            Models.User result = new Models.User();
            HttpClient client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Models.User>(responseData);
            }

            return result;
        }

        public async Task<List<Models.User>> GetAllUsers()
        {
            List<Models.User> result = new List<Models.User>();
            var url = Enpoints.GetAllUsers;
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var reponse = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Models.User>>(reponse);
            }
            return result;

        }

        public async Task<Models.User> UpdateUser(Models.User model)
        {
            var url = Enpoints.UpdateUser;
            Models.User result = new Models.User();
            HttpClient client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Models.User>(responseData);
            }

            return result;
        }
    }
}
