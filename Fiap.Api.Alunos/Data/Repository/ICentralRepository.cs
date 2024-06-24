using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
     public interface ICentralRepository
    {
        IEnumerable<CentralSegurancaModel> GetAll();

        CentralSegurancaModel GetById(int id);
        void Add(CentralSegurancaModel user);
        void Update(CentralSegurancaModel user);
        void Delete(CentralSegurancaModel user);
    }

}