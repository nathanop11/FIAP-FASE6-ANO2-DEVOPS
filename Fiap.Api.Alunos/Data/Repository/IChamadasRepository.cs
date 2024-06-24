using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
     public interface IChamadasRepository
    {
        IEnumerable<ChamadasModel> GetAll();

        ChamadasModel GetById(int id);
        void Add(ChamadasModel user);
        void Update(ChamadasModel user);
        void Delete(ChamadasModel user);
    }

}