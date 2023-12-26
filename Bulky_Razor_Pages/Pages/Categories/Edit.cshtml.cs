using Bulky_Razor_Pages.Data;
using Bulky_Razor_Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_Razor_Pages.Pages.Categories
{

    [BindProperties]
    public class EditModel(ApplicationDbContext db) : PageModel
    {
        private readonly ApplicationDbContext _db = db;

       
        public Category? Category { get; set; }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
           
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
