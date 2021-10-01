using System;
using System.ComponentModel.DataAnnotations;

namespace RazorBasketballUdemy.Models
{
    public class Raptor
    {
        public int Id { get; set; }
        
        [Range(1,100)]
        [Required]
        [Display(Name = "Number")]
        public int PlayerNum { get; set; }

        [StringLength(60,MinimumLength =3)]
        [Required]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        [Display(Name = "Position")]
        public string PlayerPosition { get; set; }

        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Height")]
        public string PlayerHeight { get; set; }

        [Range(1,1000000000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Salary")]
        public double PlayerSalary { get; set; }
    }
}
