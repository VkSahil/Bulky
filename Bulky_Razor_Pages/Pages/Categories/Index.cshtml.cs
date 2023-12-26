using Bulky_Razor_Pages.Data;
using Bulky_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor_Pages.Pages.Categories
{
    public class IndexModel(ApplicationDbContext db) : PageModel
    {

        private readonly ApplicationDbContext _db = db;

        public List<Category> CategoryList { get; set; }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
