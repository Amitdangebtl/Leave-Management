using Microsoft.AspNetCore.Mvc;
using UILeave_Management.Models;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LeaveUI.Controllers
{
    public class LeaveStatusHistoryMVCController : Controller
    {
        private readonly HttpClient _client;
        private const string BASE = "https://localhost:7002/api/LeaveStatusHistory/";

        public LeaveStatusHistoryMVCController()
        {
            _client = new HttpClient();
        }

        // 1. View: Add History Page
        [HttpGet]
        public IActionResult AddHistoryView()
        {
            return View("~/Views/LeaveStatusHistory/AddHistory.cshtml");
        }

        // 1. API Call: Add History
        [HttpPost]
        public async Task<IActionResult> AddHistory(LeaveStatusHistory h)
        {
            var json = JsonSerializer.Serialize(h);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(BASE + "AddHistory", content);
            ViewBag.Msg = await res.Content.ReadAsStringAsync();

            return View("~/Views/LeaveStatusHistory/AddHistory.cshtml");
        }

        // 2. View: History List Page (API Call + Return View)
        [HttpGet]
        public async Task<IActionResult> HistoryListView()
        {
            var res = await _client.GetAsync(BASE + "GetHistoryList");
            var json = await res.Content.ReadAsStringAsync();

            var history = JsonSerializer.Deserialize<List<LeaveStatusHistory>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("~/Views/LeaveStatusHistory/HistoryList.cshtml", history);
        }

        // 3. View: Get History by LeaveId
        [HttpGet]
        public IActionResult SearchByLeaveView()
        {
            return View("~/Views/LeaveStatusHistory/SearchByLeave.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SearchByLeave(int leaveId)
        {
            var res = await _client.GetAsync(BASE + "GetHistoryByLeaveId?leaveId=" + leaveId);
            var result = await res.Content.ReadAsStringAsync();
            ViewBag.Result = result;

            return View("~/Views/LeaveStatusHistory/SearchByLeave.cshtml");
        }

        // 4. API Call: Delete History + Redirect to List View
        [HttpGet]
        public async Task<IActionResult> DeleteHistory(int historyId)
        {
            var res = await _client.GetAsync(BASE + "DeleteHistory?historyId=" + historyId);
            TempData["Msg"] = await res.Content.ReadAsStringAsync();

            return RedirectToAction("HistoryListView", "LeaveStatusHistoryMVC");
        }

        // 5. View: History Detail by HistoryId
        [HttpGet]
        public async Task<IActionResult> HistoryDetailView(int historyId)
        {
            var res = await _client.GetAsync(BASE + "GetHistoryById?historyId=" + historyId);
            var json = await res.Content.ReadAsStringAsync();

            var h = JsonSerializer.Deserialize<LeaveStatusHistory>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("~/Views/LeaveStatusHistory/HistoryDetail.cshtml", h);
        }
    }
}

