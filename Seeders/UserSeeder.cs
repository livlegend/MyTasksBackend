using Microsoft.EntityFrameworkCore;
using MyTasksBackend.Models;
using MyTasksBackend.Services;

namespace MyTasksBackend.Seeders
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "test@example.com", Name = "HYAME Lorry", Role = "Administrator", Status="Active", Password = PasswordService.HashPassword("password") }
                );
        }
    }
}
