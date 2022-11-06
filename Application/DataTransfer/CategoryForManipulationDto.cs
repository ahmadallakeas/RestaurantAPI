using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public abstract record CategoryForManipulationDto
    {

        [Required(ErrorMessage = "CategoryName is required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "CategoryImage is required")]
        public string CategoryImage { get; set; }
        public virtual ICollection<MealForCategoryCreationDto>? Meals { get; set; }
    }
}
