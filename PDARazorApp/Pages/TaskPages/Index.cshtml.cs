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
    public class IndexModel : PageModel
    {
        private readonly PDARazorApp.Data.ApplicationDbContext _context;

        public IndexModel(PDARazorApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CustomerTask> CustomerTask { get;set; }

        public async Task OnGetAsync()
        {
            CustomerTask = await _context.CustomerTasks.ToListAsync();
        }
    }
}
