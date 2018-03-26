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
using System.Security.Claims;

namespace Tulet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public string StatusMessage { get; set; }
        public AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
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
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Category() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            var model = cmd.Category.ToList().OrderBy(x => x.Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Category(String Name) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            var vm = new Category{
                Name = Name
            };

            if (!String.IsNullOrEmpty(Name)) 
            {
                cmd.Category.Add(vm);
                cmd.SaveChanges();

                var model = cmd.Category.ToList().OrderBy(x => x.Id);

                return View(model);
            }
            return RedirectToAction("Category");
        }

        [HttpGet]
        public async Task<IActionResult> Type() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            var model = cmd.Type.ToList().OrderBy(x => x.Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Type(String Name) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            var vm = new Tulet.Models.Entities.Type(){
                Name = Name
            };

            if (!String.IsNullOrEmpty(Name)) 
            {
                cmd.Type.Add(vm);
                cmd.SaveChanges();

                var model = cmd.Type.ToList().OrderBy(x => x.Id);

                return View(model);
            }

            return RedirectToAction("Type");
        }

        [HttpGet]
        public async Task<IActionResult> Agent() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            List<User> agents = cmd.User.OrderBy(x => x.FirstName).ToList();
            return View(agents);
        }

        [HttpPost]
        public async Task<IActionResult> Agent(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            List<User> agents = cmd.User.Where(x => x.FirstName.Contains(id) || x.LastName.Contains(id) || x.Email.Contains(id)).OrderBy(x => x.FirstName).ToList();
            return View(agents);
        }

        [HttpGet]
        public async Task<IActionResult> AgentInfo(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            User agent = cmd.User.SingleOrDefault(x => x.Email == id);
            agent.Post = cmd.Post.Where(x => x.UserId == agent.Email).Take(4).OrderByDescending(x => x.PostDate).ThenByDescending(x => x.Id).ToList();
            return View("AgentInfo",agent);
        }

        [HttpGet]
        public async Task<IActionResult> ActivateAgent(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            var agent = cmd.User.SingleOrDefault(x => x.Email == id);
            agent.Active = true;
            cmd.SaveChanges();

            return RedirectToAction("Agent");
        }

        [HttpGet]
        public async Task<IActionResult> DeActivateAgent(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            var agent = cmd.User.SingleOrDefault(x => x.Email == id);
            agent.Active = false;
            cmd.SaveChanges();

            return RedirectToAction("Agent");
        }

        [HttpGet]
        public async Task<IActionResult> Post() 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            List<Post> posts = cmd.Post.OrderBy(x => x.Id).ToList();
            return View(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            List<Post> posts = cmd.Post.Where(x => x.Title.Contains(id) || x.Description.Contains(id) || x.Category.Contains(id) || x.Type.Contains(id)).OrderBy(x => x.Id).ToList();
            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> PostInfo(int id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            Post post = cmd.Post.SingleOrDefault(x => x.Id == id);
            post.User = cmd.User.SingleOrDefault(x => x.Email == post.UserId);
            if (cmd.Post.Count(x => x.Id != id) > 0) {
                post.User.Post = cmd.Post.Where(x => x.UserId == post.UserId && x.Id != id).Take(4).ToList();
            }
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePost(int id) 
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var cmd = new tuletContext();
            Post post = cmd.Post.SingleOrDefault(x => x.Id == id);
            cmd.Post.Remove(post);
            cmd.SaveChanges();
            
            return RedirectToAction("Post");
        }
    }
}