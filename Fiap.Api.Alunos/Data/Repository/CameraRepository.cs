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

    public void Add(CameraSegurancaModel camera)
    {
        _context.Camera.Add(camera);
        _context.SaveChanges();
    }

    public void Update(CameraSegurancaModel camera)
    {
        _context.Update(camera);
        _context.SaveChanges();
    }

    public void Delete(CameraSegurancaModel camera)
    {
        _context.Camera.Remove(camera);
        _context.SaveChanges();
    }

    
}