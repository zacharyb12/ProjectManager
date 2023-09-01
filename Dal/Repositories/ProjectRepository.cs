using Dal.Interfaces;
using Dal.Models;

namespace Dal.Repositories;

public class ProjectRepository : ICrudRepository<Project, int>
{
    private readonly DataContext _context;

    public ProjectRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Project> GetAll()
    {
        return _context.Projects;
    }

    public Project? GetById(int id)
    {
        return _context.Projects.Find(id);
    }

    public void Add(Project entity)
    {
        _context.Projects.Add(entity);
        _context.SaveChanges(); 
    }

    public void Update(Project entity)
    {
        Project? project = GetById(entity.Id);
        if (project is null) return;
        project.Name = entity.Name;
        project.Description = entity.Description;
        project.CreatedAt = entity.CreatedAt;
        project.User = entity.User;
        _context.Projects.Update(project);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Project? project = GetById(id);
        if (project is null) return;
        _context.Projects.Remove(project);
        _context.SaveChanges();
    }

    public void Delete(Project entity)
    {
        Delete(entity.Id);
    }
}