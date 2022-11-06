using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public abstract record MealForManpulationDto
    {
        public string MealName { get; set; }
        [Required(ErrorMessage = "This field MealDescription is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "This field MealImage is required")]
        public string MealImage { get; set; }
    }
}
