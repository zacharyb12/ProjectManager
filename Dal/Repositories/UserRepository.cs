using Dal.Interfaces;
using Dal.Models;

namespace Dal.Repositories;

public class UserRepository : ICrudRepository<User, int>
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User? GetById(int id)
    {
        return _context.Users.Find(id);
    }

    public void Add(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Update(User entity)
    {
        User? u = GetById(entity.Id);
        if (u is not null)
        {
            u.Name = entity.Name;
            _context.Users.Update(u);
            _context.SaveChanges();

        }
    }

    public void Delete(int id)
    {
        User? u = GetById(id);
        if (u is not null)
        {
            _context.Users.Remove(u);
            _context.SaveChanges();
        }
    }

    public void Delete(User entity)
    {
        Delete(entity.Id);
    }
}