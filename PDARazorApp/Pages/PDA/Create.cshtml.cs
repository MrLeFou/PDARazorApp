using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDARazorApp.Data;

namespace PDARazorApp.Pages.TaskPages
{
    public class CreateModel : PageModel
    {
        private readonly PDARazorApp.Data.ApplicationDbContext _context;

        public CreateModel(PDARazorApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerTask CustomerTask { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerTask.Add(CustomerTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}