﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Domain.Entities
{
    public class Meal
    {
        public int MealId { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "This field MealName is required")]
        public string MealName { get; set; }
        [Required(ErrorMessage = "This field MealDescription is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "This field MealImage is required")]
        public string MealImage { get; set; }
    }
}
