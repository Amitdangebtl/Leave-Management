using Microsoft.AspNetCore.Mvc;
using UILeave_Management.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LeaveUI.Controllers
{
    public class UserMVCController : Controller
    {
        private readonly HttpClient _client;

        private const string BASE = "https://localhost:7002/api/User/";

        public UserMVCController()
        {
            _client = new HttpClient();
        }

        // 1. Login View
        [HttpGet]
        public IActionResult LoginView()
        {
            return View("~/Views/User/Login.cshtml");
        }

        // 1. Login API Call
        [HttpPost]
        public async Task<IActionResult> Login(User u)
        {
            var json = JsonSerializer.Serialize(u);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(BASE + "Login", content);
            var result = await res.Content.ReadAsStringAsync();

            if (result.Contains("Failed"))
            {
                ViewBag.Msg = "Login Failed ❌";
                return View("~/Views/User/Login.cshtml");
            }

            // Login Success → Dashboard open
            return RedirectToAction("Dashboard", "UserMVC");
        }

        // 2. Dashboard View
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View("~/Views/User/Dashboard.cshtml");
        }

        // 3. User List View
        [HttpGet]
        public async Task<IActionResult> UserListView()
        {
            var res = await _client.GetAsync(BASE + "GetUserList");
            var json = await res.Content.ReadAsStringAsync();

            var users = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View("~/Views/User/UserList.cshtml", users);
        }

        // 4. Add User View
        [HttpGet]
        public IActionResult AddUserView()
        {
            return View("~/Views/User/AddUser.cshtml");
        }

        // 4. Add User API Call
        [HttpPost]
        public async Task<IActionResult> AddUser(User u)
        {
            var json = JsonSerializer.Serialize(u);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(BASE + "AddUser", content);
            ViewBag.Msg = await res.Content.ReadAsStringAsync();

            return View("~/Views/User/AddUser.cshtml");
        }

        // 5. Update User View
        [HttpGet]
        public IActionResult UpdateUserView(int id)
        {
            ViewBag.UserId = id;
            return View("~/Views/User/UpdateUser.cshtml");
        }

        // 5. Update User API Call
        [HttpPost]
        public async Task<IActionResult> UpdateUser(User u)
        {
            var json = JsonSerializer.Serialize(u);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(BASE + "UpdateUser", content);
            ViewBag.Msg = await res.Content.ReadAsStringAsync();

            return View("~/Views/User/UpdateUser.cshtml");
        }

        // 6. Delete User API Call
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = await _client.GetAsync(BASE + "DeleteUser?id=" + id);
            TempData["Msg"] = await res.Content.ReadAsStringAsync();

            return RedirectToAction("UserListView", "UserMVC");
        }
    }
}
