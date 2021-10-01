using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorBasketballUdemy.Models;

namespace RazorBasketballUdemy.Pages.Raptors
{
    public class IndexModel : PageModel
    {
        private readonly RazorBasketballUdemy.Data.RazorBasketballContext _context;

        public IndexModel(RazorBasketballUdemy.Data.RazorBasketballContext context)
        {
            _context = context;
        }

        public IList<Raptor> Raptor { get;set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var pos = from m in _context.Raptor select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                pos = pos.Where(s => s.PlayerPosition.Contains(SearchString));
            }
            Raptor = await pos.ToListAsync();
        }
    }
}
