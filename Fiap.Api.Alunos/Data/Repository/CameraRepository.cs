using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

public class CameraRepository : ICameraRepository
{
    private readonly DatabaseContext _context;

    public CameraRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<CameraSegurancaModel> GetAll() => _context.Camera.ToList();

    public CameraSegurancaModel GetById(int id) => _context.Camera.Find(id);

    public void Add(CameraSegurancaModel Camera)
    {
        _context.Camera.Add(Camera);
        _context.SaveChanges();
    }

    public void Update(CameraSegurancaModel Camera)
    {
        _context.Update(Camera);
        _context.SaveChanges();
    }

    public void Delete(CameraSegurancaModel Camera)
    {
        _context.Camera.Remove(Camera);
        _context.SaveChanges();
    }

    
}