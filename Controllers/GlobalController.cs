using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Tulet.Models;
using System;
using Tulet.Models.Entities;
using System.Linq;
using System.Collections.Generic;
using Tulet.Models.AdminViewModels;
using Tulet.Models.GlobalViewModels;
using Tulet.Data;

namespace Tulet.Controllers
{
    [Authorize]
    public class GlobalController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public string StatusMessage { get; set; }
        public GlobalController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _roleManager = roleManager;
            }
        
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Admin() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");

            var admin = await _userManager.GetUsersInRoleAsync("Admin");
            var admins = new List<Admin>();  
            foreach (var item in admin)
            {
                admins.Add(new Admin 
                            {
                                Id = item.Id, 
                                Email = item.Email, 
                                Username = item.UserName, 
                                Phone = item.PhoneNumber
                            });
            }      
            return View(admins);
        }

        [HttpGet]
        public async Task<IActionResult> MakeAdmin(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");

            if (!string.IsNullOrEmpty(id))
            {
                await _userManager.AddToRoleAsync(
                    _userManager.Users.SingleOrDefault(x => x.Id == id),
                    "Admin"
                );
            }

            return RedirectToAction("Admin");
        }

        [HttpGet]
        public async Task<IActionResult> UnAdmin(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");

            if (!string.IsNullOrEmpty(id))
            {
                await _userManager.RemoveFromRoleAsync(
                    _userManager.Users.SingleOrDefault(x => x.Id == id),
                    "Admin"
                );
            }

            return RedirectToAction("Admin");
        }

        [HttpGet]
        public async Task<IActionResult> Users() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");

            var users = _userManager.Users.Select(x => new Admin{Id = x.Id, Email = x.Email, Username = x.UserName, Phone = x.PhoneNumber}).ToList();           
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");
            
            await _userManager.DeleteAsync(
                 _userManager.Users.SingleOrDefault(x => x.Id == id)
            );

            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> Role() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");

            var roles = _roleManager.Roles.Select(x => new Role {Id = x.Id, Name = x.Name}).ToList();

            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Role(string Name) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.Email != "chukwuemekachm@gmail.com")
                return RedirectToAction("Index","Home");

            if (!string.IsNullOrEmpty(Name))
            {
                await _roleManager.CreateAsync(new IdentityRole {Name = Name});
            }

            return RedirectToAction("Role");
        }

    }

}