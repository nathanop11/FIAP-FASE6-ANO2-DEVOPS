using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
     public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();

        UserModel GetById(int id);
        void Add(UserModel user);
        void Update(UserModel user);
        void Delete(UserModel user);
    }

}