using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

public class SensorIncendioRepository : ISensorIncendioRepository
{
    private readonly DatabaseContext _context;

    public SensorIncendioRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<SensorIncendioModel> GetAll() => _context.Sensor.ToList();

    public SensorIncendioModel GetById(int id) => _context.Sensor.Find(id);

    public void Add(SensorIncendioModel Sensor)
    {
        _context.Sensor.Add(Sensor);
        _context.SaveChanges();
    }

    public void Update(SensorIncendioModel Sensor)
    {
        _context.Update(Sensor);
        _context.SaveChanges();
    }

    public void Delete(SensorIncendioModel Sensor)
    {
        _context.Sensor.Remove(Sensor);
        _context.SaveChanges();
    }

    
}