using LeaveApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Services.Leave
{
    public interface ILeaveService
    {
        Task<bool> CreateLeave(Models.Leave model);
        Task<List<Models.Leave>> GetAllLeaveByUserId(int Id);
        Task<List<TypeOfLeave>> GetAllTypeOfLeave();
    }
}
