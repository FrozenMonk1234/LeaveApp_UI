using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Services.Leave
{
    public interface ILeaveService
    {
        Task<string> CreateLeave(Models.Leave model);
        Task<List<Models.Leave>> GetAllLeaveRecordsByUserId(int Id);
        Task<Models.Leave> GetLeaveById(int Id);
    }
}
