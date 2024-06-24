using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
     public interface ICameraRepository
    {
        IEnumerable<CameraSegurancaModel> GetAll();

        CameraSegurancaModel GetById(int id);
        void Add(CameraSegurancaModel user);
        void Update(CameraSegurancaModel user);
        void Delete(CameraSegurancaModel user);
    }

}