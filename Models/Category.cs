namespace MyTasksBackend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TheTask> Tasks { get; set; } = new List<TheTask>(); 
    }
}