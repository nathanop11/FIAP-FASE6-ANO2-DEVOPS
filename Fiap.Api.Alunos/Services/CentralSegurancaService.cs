using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Api.Alunos.Services
{
    public class CentralSegurancaService : ICentralSegurancaService
    {
        private readonly List<CentralSegurancaModel> _centralSeguranca = new List<CentralSegurancaModel>();
        private readonly ICentralRepository _repository;


        public IEnumerable<CentralSegurancaModel> GetCentralSeguranca()

        {
            return _centralSeguranca;
        }

        public CentralSegurancaModel AddCentralSeguranca(CentralSegurancaModel centralSeguranca)
        {
            _centralSeguranca.Add(centralSeguranca);
            return centralSeguranca;
        }


        public CentralSegurancaModel ObterCentralPorId(int id) => _repository.GetById(id);


        public void AtualizarCentral(CentralSegurancaModel centralSeguranca) => _repository.Update(centralSeguranca);

        public void DeletarCentral(int id)
        {
            var central = _repository.GetById(id);
            if (central != null)
            {
                _repository.Delete(central);
            }
        }

    }
}
