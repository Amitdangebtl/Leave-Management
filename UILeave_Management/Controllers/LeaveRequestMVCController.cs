using Microsoft.AspNetCore.Mvc;
using UILeave_Management.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LeaveUI.Controllers
{
    public class LeaveRequestMVCController : Controller
    {
        private readonly HttpClient _client;
        private const string BASE = "https://localhost:7002/api/LeaveRequest/";

        public LeaveRequestMVCController()
        {
            _client = new HttpClient();
        }

        // 1. Open Apply Leave Page
        [HttpGet]
        public IActionResult ApplyLeaveView()
        {
            return View("~/Views/Leave/ApplyLeave.cshtml");
        }

        // 1. Call API to Insert Leave
        [HttpPost]
        public async Task<IActionResult> ApplyLeave(LeaveRequest lr)
        {
            var json = JsonSerializer.Serialize(lr);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(BASE + "ApplyLeave", content);
            ViewBag.Msg = await res.Content.ReadAsStringAsync();

            return View("~/Views/Leave/ApplyLeave.cshtml");
        }

        // 2. List All Leaves Page (API Call + Return View)
        [HttpGet]
        public async Task<IActionResult> LeaveListView()
        {
            var res = await _client.GetAsync(BASE + "GetLeaveList");
            var json = await res.Content.ReadAsStringAsync();

            var leaves = JsonSerializer.Deserialize<List<LeaveRequest>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("~/Views/Leave/LeaveList.cshtml", leaves);
        }

        // 3. Delete Leave API Call + Redirect
        [HttpGet]
        public async Task<IActionResult> DeleteLeave(int leaveId)
        {
            var res = await _client.GetAsync(BASE + "DeleteLeave?leaveId=" + leaveId);
            TempData["Msg"] = await res.Content.ReadAsStringAsync();

            return RedirectToAction("LeaveListView", "LeaveRequestMVC");
        }

        // 4. Open Edit Leave Page
        [HttpGet]
        public IActionResult EditLeaveView(int id)
        {
            ViewBag.LeaveId = id;
            return View("~/Views/Leave/EditLeave.cshtml");
        }

        // 4. Edit Leave API Call + Return View
        [HttpPost]
        public async Task<IActionResult> EditLeave(LeaveRequest lr)
        {
            var json = JsonSerializer.Serialize(lr);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(BASE + "EditLeave", content);
            ViewBag.Msg = await res.Content.ReadAsStringAsync();

            return View("~/Views/Leave/EditLeave.cshtml");
        }

        // 5. View Leave Detail Page
        [HttpGet]
        public async Task<IActionResult> LeaveDetailView(int leaveId)
        {
            var res = await _client.GetAsync(BASE + "GetLeaveById?leaveId=" + leaveId);
            var json = await res.Content.ReadAsStringAsync();

            var leave = JsonSerializer.Deserialize<LeaveRequest>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("~/Views/Leave/LeaveDetail.cshtml", leave);
        }
    }
}
