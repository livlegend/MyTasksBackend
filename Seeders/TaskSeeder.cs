using Microsoft.EntityFrameworkCore;
using MyTasksBackend.Models;

namespace MyTasksBackend.Seeders
{
    public class TaskSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TheTask>().HasData(
                new TheTask { Id = 1, Title = "Ma tâche 1", Description = "Ma desc1", DateLimit = DateTime.Now, UserId=1, CategoryId = 1 },
                new TheTask { Id = 2, Title = "Ma tâche 2", Description = "Ma desc2", DateLimit = DateTime.Now, UserId = 1, CategoryId = 2 },
                new TheTask { Id = 3, Title = "Ma tâche 2", Description = "Ma desc2", DateLimit = DateTime.Now, UserId = 1, CategoryId = 3 }
                );
        }
    }
}
