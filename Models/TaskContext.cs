
using Microsoft.EntityFrameworkCore;
using MyTasksBackend.Seeders;
using MyTasksBackend.Services;

namespace MyTasksBackend.Models
{
    public class TaskContext:DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Email = "test@example.com", Name = "HYAME Lorry", Role = "Administrator", Status = "Active", Password = PasswordService.HashPassword("password") }
               );
            modelBuilder.Entity<Category>().HasData(
                   new Category { Id = 1, Name = "Travail" },
                   new Category { Id = 2, Name = "Personnel" },
                   new Category { Id = 3, Name = "Etudes" }
               );
            modelBuilder.Entity<TheTask>().HasData(
               new TheTask { Id = 1, Title = "Ma tâche 1", Description = "Ma desc1", DateLimit = DateTime.Now, UserId = 1, CategoryId = 1 },
               new TheTask { Id = 2, Title = "Ma tâche 2", Description = "Ma desc2", DateLimit = DateTime.Now, UserId = 1, CategoryId = 2 },
               new TheTask { Id = 3, Title = "Ma tâche 2", Description = "Ma desc2", DateLimit = DateTime.Now, UserId = 1, CategoryId = 3 }
               );


            /*UserSeeder.Seed(modelBuilder);
            CategorySeeder.Seed(modelBuilder);
            TaskSeeder.Seed(modelBuilder);*/
        }

        public DbSet<User> UserItems { get; set; } = null!;
        public DbSet<Category> CategoryItems { get; set; } = null!;
        public DbSet<TheTask> TaskItems { get; set; } = null!;

    }
}
