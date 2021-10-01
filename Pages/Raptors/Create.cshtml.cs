﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorBasketballUdemy.Data;
using RazorBasketballUdemy.Models;

namespace RazorBasketballUdemy.Pages.Raptors
{
    public class CreateModel : PageModel
    {
        private readonly RazorBasketballUdemy.Data.RazorBasketballContext _context;

        public CreateModel(RazorBasketballUdemy.Data.RazorBasketballContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Raptor Raptor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Raptor.Add(Raptor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
