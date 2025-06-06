using System.Security.Claims;

namespace PlataformaEducacaoOnline.Core.DomainObjects
{
    public interface IUser
    {
        string Name { get; }
        Guid GetId();
        string GetEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
