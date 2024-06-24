using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

public class ChamadasRepository : IChamadasRepository
{
    private readonly DatabaseContext _context;

    public ChamadasRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<ChamadasModel> GetAll() => _context.Chamadas.ToList();

    public ChamadasModel GetById(int id) => _context.Chamadas.Find(id);

    public void Add(ChamadasModel Chamadas)
    {
        _context.Chamadas.Add(Chamadas);
        _context.SaveChanges();
    }

    public void Update(ChamadasModel Chamadas)
    {
        _context.Update(Chamadas);
        _context.SaveChanges();
    }

    public void Delete(ChamadasModel Chamadas)
    {
        _context.Chamadas.Remove(Chamadas);
        _context.SaveChanges();
    }

    
}