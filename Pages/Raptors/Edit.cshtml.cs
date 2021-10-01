using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorBasketballUdemy.Data;
using RazorBasketballUdemy.Models;

namespace RazorBasketballUdemy.Pages.Raptors
{
    public class EditModel : PageModel
    {
        private readonly RazorBasketballUdemy.Data.RazorBasketballContext _context;

        public EditModel(RazorBasketballUdemy.Data.RazorBasketballContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Raptor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaptorExists(Raptor.Id))
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

        private bool RaptorExists(int id)
        {
            return _context.Raptor.Any(e => e.Id == id);
        }
    }
}
