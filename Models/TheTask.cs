namespace MyTasksBackend.Models
{
    public class TheTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateLimit { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.EnCours;
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }  
        public User User { get; set; }


    }

    public enum TaskStatus { EnCours, Complete }

    public enum Priority
    {
        Basse,
        Moyenne,
        Haute
    }

}
