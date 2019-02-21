using System.Security.Claims;
using System.Threading.Tasks;

namespace RedPet.Core.Auth
{
    public interface IJwtFactory
    {
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
        string GenerateEncodedToken(string userName, ClaimsIdentity identity);
    }
}