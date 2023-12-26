using Bulky_Razor_Pages.Data;
using Bulky_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor_Pages.Pages.Categories
{
    public class CreateModel(ApplicationDbContext db) : PageModel
    {
        private readonly ApplicationDbContext _db = db;

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet()
        {
          
        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToPage("Index");
        }
    }
}
