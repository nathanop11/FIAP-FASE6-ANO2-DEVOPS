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
        return _context.User.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}

}
