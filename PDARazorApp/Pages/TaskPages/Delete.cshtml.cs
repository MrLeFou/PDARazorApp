using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDARazorApp.Data;

namespace PDARazorApp.Pages.TaskPages
{
    public class DeleteModel : PageModel
    {
        private readonly PDARazorApp.Data.ApplicationDbContext _context;

        public DeleteModel(PDARazorApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerTask CustomerTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerTask = await _context.CustomerTasks.FirstOrDefaultAsync(m => m.TaskId == id);

            if (CustomerTask == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerTask = await _context.CustomerTasks.FindAsync(id);

            if (CustomerTask != null)
            {
                _context.CustomerTasks.Remove(CustomerTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
