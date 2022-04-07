using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Services.User
{
    public interface IUserService
    {
        Task<List<Models.User>> GetAllUsers();
        Task<Models.User> UpdateUser(Models.User model);
        Task<Models.User> CreateUser(Models.User model);
    }
}
