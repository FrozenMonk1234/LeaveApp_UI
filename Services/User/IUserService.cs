using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Services.User
{
    public interface IUserService
    {
        Task<Models.User> GetUserById(int Id);
        Task<List<Models.User>> GetAllUsers();
        Task<string> UpdateUser(Models.User model);
        Task<string> CreateUser(Models.User model);
    }
}
