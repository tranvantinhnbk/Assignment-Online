using Microsoft.AspNetCore.Mvc;
using Assignment_Online.Data;
using Assignment_Online.Models; // Replace this with the appropriate namespace for your application
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;


// Chat GPT helping =))

namespace Assignment_Online.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountManageController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountManageController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _dbContext.Users.ToList();
            ViewBag.UsersWithRoles = users.Select(u => new
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Roles = _userManager.GetRolesAsync(u).Result
            }).ToList();

            return View();
        }

    }
}
