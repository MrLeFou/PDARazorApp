﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDARazorApp.Data;

namespace PDARazorApp.Pages.TaskPages
{
    public class EditModel : PageModel
    {
        private readonly PDARazorApp.Data.ApplicationDbContext _context;

        public EditModel(PDARazorApp.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTaskExists(CustomerTask.TaskId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerTaskExists(int id)
        {
            return _context.CustomerTasks.Any(e => e.TaskId == id);
        }
    }
}
