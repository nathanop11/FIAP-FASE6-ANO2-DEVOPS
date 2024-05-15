using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.ViewModel;

namespace Fiap.Api.Alunos.ViewModel
{
    public class ClientePaginacaoViewModel
    {

        public IEnumerable<ClienteViewModel> Clientes { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Clientes.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Cliente/Index?pageNumber={CurrentPage - 1}&pageSize={PageSize}" : null;
        public string NextPageUrl => HasNextPage ? $"/Cliente/Index?pageNumber={CurrentPage + 1}&pageSize={PageSize}" : null;



    }
}
