using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tulet.Models.Components;
using Tulet.Models.Entities;

namespace Tulet.Models.Components
{
    public class AdminNavViewComponent : ViewComponent
    {
        private readonly tuletContext ddb;
        public AdminNavViewComponent()
        {            
            ddb =  new tuletContext();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemAsync();
            return View(items);
        }
        private async Task<List<Nav>> GetItemAsync()
        {
            var Nav = new List<Nav>();
            Nav.Add(new Nav{Name = "All Users", Count = await ddb.User.CountAsync(), Action = "Agent"});
            Nav.Add(new Nav{Name = "Verified Users", Count = await ddb.User.Where(x => x.Verified == true).CountAsync(), Action = "Agent"});
            Nav.Add(new Nav{Name = "Active Users", Count = await ddb.User.Where(x => x.Active == true).CountAsync(), Action = "Agent"});
            Nav.Add(new Nav{Name = "Non-Active Users", Count = await ddb.User.Where(x => x.Active == false).CountAsync(), Action = "Agent"});
            Nav.Add(new Nav{Name = "Posts", Count = await ddb.Post.CountAsync(), Action = "Post"});
            Nav.Add(new Nav{Name = "Categories", Count = await ddb.Category.CountAsync(), Action = "Category"});
            Nav.Add(new Nav{Name = "Types", Count = await ddb.Type.CountAsync(), Action = "Type"});
            return Nav;
        }
    }
}