using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
     public interface ISensorIncendioRepository
    {
        IEnumerable<SensorIncendioModel> GetAll();

        SensorIncendioModel GetById(int id);
        void Add(SensorIncendioModel user);
        void Update(SensorIncendioModel user);
        void Delete(SensorIncendioModel user);
    }

}