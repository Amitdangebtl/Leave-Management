using Microsoft.AspNetCore.Mvc;
using Leave_ManagementAPI.Models;
using System.Linq;

namespace Leave_ManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly LeaveManagementDbContext _db;

        public LeaveRequestController(LeaveManagementDbContext db)
        {
            _db = db;
        }

        // 1. Apply for Leave (User)
        [HttpPost]
        public IActionResult ApplyLeave([FromBody] LeaveRequest lr)
        {
            _db.LeaveRequests.Add(lr);
            _db.SaveChanges();
            return Ok("Leave Applied Successfully 📩");
        }

        // 2. Get All Leave Requests (Admin/User)
        [HttpGet]
        public IActionResult GetLeaveList()
        {
            var list = _db.LeaveRequests.ToList();
            return Ok(list);
        }

        // 3. Approve or Reject Leave (Admin)
        [HttpPost]
        public IActionResult UpdateLeaveStatus(int leaveId, string newStatus, int updatedBy)
        {
            var leave = _db.LeaveRequests.Find(leaveId);
            if (leave == null)
                return Ok("Leave Request Not Found ❗");

            string oldStatus = leave.Status ?? "Pending";

            leave.Status = newStatus;
            _db.LeaveRequests.Update(leave);
            _db.SaveChanges();

            // Save status history
            LeaveStatusHistory history = new LeaveStatusHistory()
            {
                LeaveId = leaveId,
                OldStatus = oldStatus,
                NewStatus = newStatus,
                UpdatedBy = updatedBy
            };

            _db.LeaveStatusHistories.Add(history);
            _db.SaveChanges();

            return Ok($"Status Updated ✅ ({newStatus}) | History Saved 🕒");
        }

        // 4. Get Leave by ID
        [HttpGet]
        public IActionResult GetLeaveById(int leaveId)
        {
            var leave = _db.LeaveRequests.Find(leaveId);
            if (leave == null)
                return Ok("Leave Request Not Found ❗");

            return Ok(leave);
        }

        // 5. Delete Leave Request
        [HttpGet]
        public IActionResult DeleteLeave(int leaveId)
        {
            var leave = _db.LeaveRequests.Find(leaveId);
            if (leave == null)
                return Ok("Leave Request Not Found ❗");

            _db.LeaveRequests.Remove(leave);
            _db.SaveChanges();
            return Ok("Leave Deleted Successfully 🗑");
        }

        // 6. Update Leave Request (Optional Edit)
        [HttpPost]
        public IActionResult EditLeave([FromBody] LeaveRequest lr)
        {
            var leave = _db.LeaveRequests.Find(lr.LeaveId);
            if (leave == null)
                return Ok("Leave Request Not Found ❗");

            leave.LeaveType = lr.LeaveType;
            leave.StartDate = lr.StartDate;
            leave.EndDate = lr.EndDate;
            leave.Reason = lr.Reason;
            leave.Status = lr.Status;

            _db.LeaveRequests.Update(leave);
            _db.SaveChanges();

            return Ok("Leave Updated Successfully ✏");
        }
    }
}
