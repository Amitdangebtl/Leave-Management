using Microsoft.AspNetCore.Mvc;
using Leave_ManagementAPI.Models;
using System.Linq;

namespace Leave_ManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaveStatusHistoryController : ControllerBase
    {
        private readonly LeaveManagementDbContext _db;

        public LeaveStatusHistoryController(LeaveManagementDbContext db)
        {
            _db = db;
        }

        // 1. Add new leave status history
        [HttpPost]
        public IActionResult AddHistory([FromBody] LeaveStatusHistory h)
        {
            _db.LeaveStatusHistories.Add(h);
            _db.SaveChanges();
            return Ok("Leave Status History Added Successfully 🕒");
        }

        // 2. Get all leave status history
        [HttpGet]
        public IActionResult GetHistoryList()
        {
            var list = _db.LeaveStatusHistories.ToList();
            return Ok(list);
        }

        // 3. Get history by LeaveId
        [HttpGet]
        public IActionResult GetHistoryByLeaveId(int leaveId)
        {
            var list = _db.LeaveStatusHistories.Where(x => x.LeaveId == leaveId).ToList();
            if (list.Count == 0)
                return Ok("No History Found for this Leave ❗");

            return Ok(list);
        }

        // 4. Delete history by HistoryId
        [HttpGet]
        public IActionResult DeleteHistory(int historyId)
        {
            var h = _db.LeaveStatusHistories.Find(historyId);
            if (h == null)
                return Ok("History Not Found ❗");

            _db.LeaveStatusHistories.Remove(h);
            _db.SaveChanges();
            return Ok("Leave Status History Deleted Successfully 🗑");
        }

        // 5. Get history by HistoryId
        [HttpGet]
        public IActionResult GetHistoryById(int historyId)
        {
            var h = _db.LeaveStatusHistories.Find(historyId);
            if (h == null)
                return Ok("History Not Found ❗");

            return Ok(h);
        }
    }
}
