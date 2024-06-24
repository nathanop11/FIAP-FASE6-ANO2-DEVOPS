using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class AuthService : IAuthService
{
    private readonly DatabaseContext _context;

    public AuthService(DatabaseContext context)
    {
        _context = context;
    }

    public UserModel? Authenticate(string username, string password)
    {
        // Aqui você pode implementar a lógica de autenticação com segurança adequada, por exemplo, hashing de senha
        return _context.User.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}

}
