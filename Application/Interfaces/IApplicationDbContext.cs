using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Meal> Meals { get; set; }
        Task<int> SaveChangesAysnc();

    }
}
