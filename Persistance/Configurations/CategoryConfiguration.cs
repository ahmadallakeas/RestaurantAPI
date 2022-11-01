using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
              new Category
              {
                  CategoryId = 1,
                  CategoryName = "Burgers and Sandwiches",
                  CategoryImage = "https://i.imgur.com/YMNU1TY.jpg"
              },
              new Category
              {
                  CategoryId = 2,
                  CategoryName = "Pizza",
                  CategoryImage = "https://i.imgur.com/lYO0Ol8.jpeg"
              }
                );
        }
    }
}
