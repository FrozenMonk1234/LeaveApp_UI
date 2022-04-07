using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? LeaveDays { get; set; }
        public int? LeaveLeft { get; set; }
        public bool? IsActive { get; set; }
    }
}
