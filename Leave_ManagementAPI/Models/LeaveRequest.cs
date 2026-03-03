using System;
using System.Collections.Generic;

namespace Leave_ManagementAPI.Models;

public partial class LeaveRequest
{
    public int LeaveId { get; set; }

    public int UserId { get; set; }

    public string LeaveType { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Reason { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? AppliedOn { get; set; }

    public virtual ICollection<LeaveStatusHistory> LeaveStatusHistories { get; set; } = new List<LeaveStatusHistory>();

    public virtual User User { get; set; } = null!;
}
