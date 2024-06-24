using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

public class CentralRepository : ICentralRepository
{
    private readonly DatabaseContext _context;

    public CentralRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<CentralSegurancaModel> GetAll() => _context.Central.ToList();

    public CentralSegurancaModel GetById(int id) => _context.Central.Find(id);

    public void Add(CentralSegurancaModel Central)
    {
        _context.Central.Add(Central);
        _context.SaveChanges();
    }

    public void Update(CentralSegurancaModel Central)
    {
        _context.Update(Central);
        _context.SaveChanges();
    }

    public void Delete(CentralSegurancaModel Central)
    {
        _context.Central.Remove(Central);
        _context.SaveChanges();
    }

    
}