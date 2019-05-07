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
    public class DetailsModel : PageModel
    {
        private readonly PDARazorApp.Data.ApplicationDbContext _context;

        public DetailsModel(PDARazorApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
