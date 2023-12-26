using Bulky_Razor_Pages.Data;
using Bulky_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor_Pages.Pages.Categories
{
    [BindProperties]
    public class DeleteModel(ApplicationDbContext db) : PageModel
    {
        private readonly ApplicationDbContext _db = db;


        public Category? Category { get; set; }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }

        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if(obj != null)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();                
           
        }
    }
}
