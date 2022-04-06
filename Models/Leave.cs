using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? FromDate { get; set; } = DateTime.Now;
        public DateTime? ToDate { get; set; } = DateTime.Now;
        public int? LeaveDays { get; set; }
        public int? LeaveLeft { get; set; }
        public string TypeOfLeave { get; set; }
        public string Reason { get; set; }
    }
}
