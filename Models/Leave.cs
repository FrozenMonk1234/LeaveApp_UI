using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_UI.Models
{
    public class Leave
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        public int? LeaveDays { get; set; }
        public int? LeaveLeft { get; set; }
        [Required]
        public string TypeOfLeave { get; set; }
        public string Reason { get; set; }
    }
}
