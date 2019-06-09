using System.Security.Claims;
using System.Threading.Tasks;
using RedPet.Common.Models.User;

namespace RedPet.Core.Auth
{
    public interface IJwtFactory
    {
        ClaimsIdentity GenerateClaimsIdentity(string userName, int id, string role);
        string GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(UserModel user);
    }
}