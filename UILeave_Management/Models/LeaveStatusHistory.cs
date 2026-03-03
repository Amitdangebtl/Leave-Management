namespace UILeave_Management.Models
{
    public class LeaveStatusHistory
    {
        public int HistoryId { get; set; }

        public int LeaveId { get; set; }

        public int UpdatedBy { get; set; }

        public string OldStatus { get; set; } = null!;

        public string NewStatus { get; set; } = null!;

        public DateTime? UpdatedOn { get; set; }

        public virtual LeaveRequest Leave { get; set; } = null!;

        public virtual User UpdatedByNavigation { get; set; } = null!;
    }
}
