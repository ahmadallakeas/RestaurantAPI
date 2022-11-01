using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This field CategoryName is required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "This field CategoryImage is required")]
        public string CategoryImage { get; set; }
        public virtual ICollection<Meal>? Meals { get; set; }
    }
}
