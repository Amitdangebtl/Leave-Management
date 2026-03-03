using System;
using System.Collections.Generic;

namespace Leave_ManagementAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    public virtual ICollection<LeaveStatusHistory> LeaveStatusHistories { get; set; } = new List<LeaveStatusHistory>();
}
