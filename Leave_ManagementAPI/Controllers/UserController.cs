using Microsoft.AspNetCore.Mvc;
using Leave_ManagementAPI.Models;
using System.Linq;

namespace Leave_ManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LeaveManagementDbContext _db;

        public UserController(LeaveManagementDbContext db)
        {
            _db = db;
        }

        // 1. Login API
        [HttpPost]
        public IActionResult Login([FromBody] User u)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == u.Email && x.Password == u.Password);
            if (user == null)
                return Ok("Login Failed ❌");

            return Ok($"Login Success ✅ | Role: {user.Role}");
        }

        // 2. Add new user
        [HttpPost]
        public IActionResult AddUser([FromBody] User u)
        {
            _db.Users.Add(u);
            _db.SaveChanges();
            return Ok("User Added Successfully ➕");
        }

        // 3. Get all users
        [HttpGet]
        public IActionResult GetUserList()
        {
            var list = _db.Users.ToList();
            return Ok(list);
        }

        // 4. Delete user by ID
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var u = _db.Users.Find(id);
            if (u == null)
                return Ok("User Not Found ❗");

            _db.Users.Remove(u);
            _db.SaveChanges();
            return Ok("User Deleted Successfully 🗑");
        }

        // 5. Update user
        [HttpPost]
        public IActionResult UpdateUser([FromBody] User u)
        {
            var user = _db.Users.Find(u.UserId);
            if (user == null)
                return Ok("User Not Found ❗");

            user.Name = u.Name;
            user.Email = u.Email;
            user.Password = u.Password;
            user.Role = u.Role;

            _db.Users.Update(user);
            _db.SaveChanges();
            return Ok("User Updated Successfully ✏");
        }

        // 6. Get user by ID
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var u = _db.Users.Find(id);
            if (u == null)
                return Ok("User Not Found ❗");

            return Ok(u);
        }
    }
}
