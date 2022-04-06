﻿using LeaveApp_UI.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public async Task<string> CreateUser(Models.User model)
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

        public async Task<List<Models.User>> GetAllUsers()
        {
            var url = Enpoints.GetAllUser;
            List<Models.User> result = new List<Models.User>();
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Models.User>>(responseData);
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

        public async Task<Models.User> GetUserById(int Id)
        {
            var url = Enpoints.GetUser;
            Models.User result = new Models.User();
            HttpClient client = _httpClient.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Models.User>(responseData);
            }

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException("Failed to get list");
            }
        }

        public async Task<string> UpdateUser(Models.User model)
        {
            var url = Enpoints.UpdateUser;
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
                return "Updated Successfully";
            }
            else
            {
                return "Failed to Update. Contact your administrator";
            }
        }
    }
}
