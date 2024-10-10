using Fiap.Web.Alunos.Models;

namespace Fiap.Api.Alunos.Services
{
    public interface ICentralSegurancaService
    {

        IEnumerable<CentralSegurancaModel> GetCentralSeguranca();
        CentralSegurancaModel AddCentralSeguranca(CentralSegurancaModel centralSeguranca);
        CentralSegurancaModel ObterCentralPorId(int id);
        void AtualizarCentral(CentralSegurancaModel centralSeguranca);
        void DeletarCentral(int id);


    }
}
