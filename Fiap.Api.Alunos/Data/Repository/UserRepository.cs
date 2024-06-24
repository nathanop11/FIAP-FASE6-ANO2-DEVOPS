using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<UserModel> GetAll() => _context.User.ToList();

    public UserModel GetById(int id) => _context.User.Find(id);

    public void Add(UserModel user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
    }

    public void Update(UserModel user)
    {
        _context.Update(user);
        _context.SaveChanges();
    }

    public void Delete(UserModel user)
    {
        _context.User.Remove(user);
        _context.SaveChanges();
    }

    
}