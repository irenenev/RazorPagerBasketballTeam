using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorBasketballUdemy.Data;
using RazorBasketballUdemy.Models;

namespace RazorBasketballUdemy.Pages.Raptors
{
    public class DeleteModel : PageModel
    {
        private readonly RazorBasketballUdemy.Data.RazorBasketballContext _context;

        public DeleteModel(RazorBasketballUdemy.Data.RazorBasketballContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Raptor Raptor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Raptor = await _context.Raptor.FirstOrDefaultAsync(m => m.Id == id);

            if (Raptor == null)
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

            Raptor = await _context.Raptor.FindAsync(id);

            if (Raptor != null)
            {
                _context.Raptor.Remove(Raptor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
