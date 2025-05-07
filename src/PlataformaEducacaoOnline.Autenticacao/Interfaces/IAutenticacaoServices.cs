using Microsoft.AspNetCore.Identity;
using PlataformaEducacaoOnline.Autenticacao.Models;

namespace PlataformaEducacaoOnline.Autenticacao.Interfaces
{
    public interface IAutenticacaoServices
    {
        Task<IdentityResult> RegisterAsync(RegisterUserModel model);        
        Task<LoginResponseModel> LoginAsync(LoginUserModel model);
        Task<bool> RemoveAsync(string id);
    }
}
