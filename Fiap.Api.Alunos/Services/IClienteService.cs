using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IClienteService
    {
        IEnumerable<ClienteModel> ListarClientes();
        IEnumerable<ClienteModel> ListarClientes(int pagina = 0, int tamanho = 10);
        IEnumerable<ClienteModel> ListarClientesUltimaReferencia(int ultimoId = 0, int tamanho = 10);
        ClienteModel ObterClientePorId(int id);
        void CriarCliente(ClienteModel cliente);
        void AtualizarCliente(ClienteModel cliente);
        void DeletarCliente(int id);
    }

}
