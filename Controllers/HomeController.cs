using EgyptExcavationProject.Areas.Identity.Data;
using EgyptExcavationProject.Data;
using EgyptExcavationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var user = User;
            var hasRole = user.IsInRole("Admin");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult ManageUsers()
        {
            IQueryable<ApplicationUser> users = _userManager.Users.ToList().AsQueryable();

            return View(users);
        }

        public async Task<IActionResult> ApproveResearcher(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Researcher");
            await _userManager.RemoveFromRoleAsync(user, "Pending");

            return RedirectToAction("ManageUsers");
        }

        public async Task<IActionResult> RevokeResearcherPermissions(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Pending");
            await _userManager.RemoveFromRoleAsync(user, "Researcher");

            return RedirectToAction("ManageUsers");
        }

        public IActionResult ViewUser(string userID)
        {
            return View(_userManager.Users.Where(u => u.Id == userID).FirstOrDefault());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
