using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserModel> ListarUsers() => _repository.GetAll();




        public UserModel ObterUserPorId(int id) => _repository.GetById(id);

        public void CriarUser(UserModel user) => _repository.Add(user);        

        public void AtualizarUser(UserModel user) => _repository.Update(user);

        public void DeletarUser(int id)
        {
            var User = _repository.GetById(id);
            if (User != null)
            {
                _repository.Delete(User);
            }
        }

    }
}