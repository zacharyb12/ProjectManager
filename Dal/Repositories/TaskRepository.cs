using Dal.Interfaces;
using Dal.Models;

namespace Dal.Repositories;

public class TaskRepository : ICrudRepository<TaskItem, int>
{
    private readonly DataContext _dbContext;

    public TaskRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<TaskItem> GetAll()
    {
        return _dbContext.Tasks;
    }

    public TaskItem? GetById(int id)
    {
        return _dbContext.Tasks.Find(id);
    }

    public void Add(TaskItem entity)
    {
        _dbContext.Tasks.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(TaskItem entity)
    {
        TaskItem? task = GetById(entity.Id);
        if (task is null) return;
        task.Name = entity.Name;
        task.Description = entity.Description;
        task.IsDone = entity.IsDone;
        task.Project = entity.Project;
        _dbContext.Tasks.Update(task);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        TaskItem? task = GetById(id);
        if (task is null) return;
        _dbContext.Tasks.Remove(task);
        _dbContext.SaveChanges();
    }

    public void Delete(TaskItem entity)
    {
        Delete(entity.Id);
    }
}