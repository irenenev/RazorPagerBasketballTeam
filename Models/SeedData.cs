using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorBasketballUdemy.Data;
using System;
using System.Linq;

namespace RazorBasketballUdemy.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new RazorBasketballContext (
                serviceProvider.GetRequiredService<DbContextOptions<RazorBasketballContext>>()))
            {
                //Look for any player info
                if (context.Raptor.Any())
                {
                    return; //DB has been seeded
                }
                context.Raptor.AddRange(
                    new Raptor
                    {
                        PlayerNum = 9,
                        PlayerName = "Serge Ibaka",
                        PlayerPosition = "Forward",
                        PlayerHeight = "7-0",
                        PlayerSalary = 22271600
                    },
                    new Raptor
                    {
                        PlayerNum = 33,
                        PlayerName = "Mark Gasol",
                        PlayerPosition = "Centre",
                        PlayerHeight = "6-11",
                        PlayerSalary = 25595700
                    }
                    );
                context.SaveChanges();
                //initialise this data in Program.cs -> Main()
            }
        }
    }
}
