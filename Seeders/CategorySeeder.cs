using Microsoft.EntityFrameworkCore;
using MyTasksBackend.Models;

namespace MyTasksBackend.Seeders
{
    public class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<TheTask>()
                      .HasOne(t => t.Category)
                      .WithMany(c => c.Tasks)
                      .HasForeignKey(t => t.CategoryId)
                      .IsRequired();*/

            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Travail" },
                    new Category { Id = 2, Name = "Personnel" },
                    new Category { Id = 3, Name = "Etudes" }
                );

        }
    }
}
