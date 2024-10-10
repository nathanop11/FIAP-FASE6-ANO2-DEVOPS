using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetUser();    
        UserModel ObterUserPorId(int id);
        void CriarUser(UserModel User);
        void AtualizarUser(UserModel User);
        void DeletarUser(int id);
    }

}