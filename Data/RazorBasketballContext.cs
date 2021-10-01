using Microsoft.EntityFrameworkCore;

namespace RazorBasketballUdemy.Data
{
    public class RazorBasketballContext : DbContext
    {
        public RazorBasketballContext (DbContextOptions<RazorBasketballContext> options)
            : base(options)
        {
        }

        public DbSet<RazorBasketballUdemy.Models.Raptor> Raptor { get; set; }
    }
}
