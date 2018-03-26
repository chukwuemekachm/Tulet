using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tulet.Models.Entities;
using Tulet.Models.HomeViewModels;

namespace Tulet.Models.Components
{
    public class SearchViewComponent : ViewComponent
    {
        private tuletContext db = new tuletContext();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await GetItemsAsync();
            return View(model);
        }

        public async Task<SearchViewModel> GetItemsAsync()
        {
            var model = new SearchViewModel();
            
            model.Categories = await db.Category.Select(x => new SelectListItem {Value = x.Name, Text = x.Name}).ToListAsync();
            model.Types =  await db.Type.Select(x => new SelectListItem {Value = x.Name, Text = x.Name}).ToListAsync();
            model.Locations = await db.Post.Select(x => new SelectListItem {Value = x.Location, Text = x.Location}).ToListAsync();
            return model;
        }
    }
}