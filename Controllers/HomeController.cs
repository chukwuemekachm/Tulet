using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tulet.Models;
using Tulet.Models.Entities;
using Tulet.Models.HomeViewModels;

namespace Tulet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            var cmd = new tuletContext();
            var lease = cmd.Post.Where(x => x.Category == "Lease").OrderByDescending(o => o.Id).Take(4).ToList();
            var rent = cmd.Post.Where(x => x.Category == "Rent").OrderByDescending(o => o.Id).Take(4).ToList();
            var sale = cmd.Post.Where(x => x.Category == "Sale").OrderByDescending(o => o.Id).Take(4).ToList();
            foreach (var item in lease)
            {
                item.User = cmd.User.SingleOrDefault(x => x.Email == item.UserId);
            }
            foreach (var item in rent)
            {
                item.User = cmd.User.SingleOrDefault(x => x.Email == item.UserId);
            }
            foreach (var item in sale)
            {
                item.User = cmd.User.SingleOrDefault(x => x.Email == item.UserId);
            }

            model.Sale = sale;
            model.Rent = rent;
            model.Lease = lease;
            return View(model);
        }

        public IActionResult Post(int id) 
        {
            var cmd = new tuletContext();
            var model = cmd.Post.SingleOrDefault(x => x.Id == id);
            model.User = cmd.User.SingleOrDefault(x => x.Email == model.UserId);
            //model.CategoryNavigation.Post = cmd.Post.Where(x => x.Category == model.Category).ToList();

            return View(model);
        }

        public IActionResult Rent()
        {
            int PageIndex = 1;
            var cmd = new tuletContext();
            var result = cmd.Post.Where(x => x.Category == "Rent").ToList();
            var model = PaginatedList<Post>.Create(result,PageIndex,12).ToList();
            foreach (var item in model)
            {
                item.User = cmd.User.SingleOrDefault(x => x.Email == item.UserId);
            }
            
            ViewData["Title"] = "Search results for Tulet9ja Rent";
            var page = new PaginatedList<Post>(model,model.Count(),PageIndex,12);
            
            ViewBag.Next = page.hasNext ? "" : "disabled";
            ViewBag.Previous = page.hasPrevious ? "" : "disabled";
            
            return View("Search",model);
        }

        public IActionResult Sale()
        {
            int PageIndex = 1;
            var cmd = new tuletContext();
            var result = cmd.Post.Where(x => x.Category == "Sale").ToList();
            var model = PaginatedList<Post>.Create(result,PageIndex,12).ToList();
            foreach (var item in model)
            {
                item.User = cmd.User.SingleOrDefault(x => x.Email == item.UserId);
            }
            ViewData["Title"] = "Search results for Tulet9ja Sale";
            var page = new PaginatedList<Post>(model,model.Count(),PageIndex,12);
            
            ViewBag.Next = page.hasNext ? "" : "disabled";
            ViewBag.Previous = page.hasPrevious ? "" : "disabled";
            
            return View("Search",model);
        }

        public IActionResult Lease()
        {
            int PageIndex = 1;
            var cmd = new tuletContext();
            var result = cmd.Post.Where(x => x.Category == "Lease").ToList();
            var model = PaginatedList<Post>.Create(result,PageIndex,12).ToList();
            foreach (var item in model)
            {
                item.User = cmd.User.SingleOrDefault(x => x.Email == item.UserId);
            }
            ViewData["Title"] = "Search results for Tulet9ja Lease";
            var page = new PaginatedList<Post>(model,model.Count(),PageIndex,12);
            
            ViewBag.Next = page.hasNext ? "" : "disabled";
            ViewBag.Previous = page.hasPrevious ? "" : "disabled";
            
            return View("Search",model);
        }

        public IActionResult Agent(string id,int pageIndex = 1)
        {
            int PageIndex = pageIndex;
            var cmd = new tuletContext();
            var model = cmd.User.SingleOrDefault(x => x.Email == id);
            var post = cmd.Post.Where(x => x.UserId == id).ToList();
            model.Post = PaginatedList<Post>.Create(post,PageIndex,12);
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
