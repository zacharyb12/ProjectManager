namespace Dal.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
    
    public IEnumerable<TaskItem> Tasks { get; set; }
    
}