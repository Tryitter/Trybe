using Tryitter.Models;
namespace Tryitter.Interfaces;
public interface ITokenService
{
    string GerarToken(string key, string issuer,string audience, User user);
}