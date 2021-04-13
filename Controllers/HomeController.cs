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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Controllers
{
    public class HomeController : Controller
    {
        // User, role, and sign in managers come from the services in startup (ASP.NET Core Identity)
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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("BurialRecords", "Burial");
            }
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

        // Check if the user is an admin

        [Authorize(Roles = "Admin")]
        public IActionResult ManageUsers()
        {
            // Generate list of users adn pass to the view
            IQueryable<ApplicationUser> users = _userManager.Users.ToList().AsQueryable();

            return View(users);
        }

        // Action to approve researcher - can only be used by admin
        public async Task<IActionResult> ApproveResearcher(string userId)
        {
            // Find the user and then remove their pending status and add researcher status
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Researcher");
            await _userManager.RemoveFromRoleAsync(user, "Pending");

            return RedirectToAction("ManageUsers");
        }

        // Revoke researcher permissions - only used by admin
        public async Task<IActionResult> RevokeResearcherPermissions(string userId)
        {
            // Find user and then add pending to role and remove researcher role
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Pending");
            await _userManager.RemoveFromRoleAsync(user, "Researcher");

            return RedirectToAction("ManageUsers");
        }

        public IActionResult ViewUser(string userID)
        {
            // Find the user with the id and pass it to the view
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
