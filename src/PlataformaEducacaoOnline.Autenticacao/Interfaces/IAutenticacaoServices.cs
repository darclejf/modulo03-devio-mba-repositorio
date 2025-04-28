using PlataformaEducacaoOnline.Autenticacao.Models;

namespace PlataformaEducacaoOnline.Autenticacao.Interfaces
{
    public interface IAutenticacaoServices
    {
        Task<string> RegisterAsync(RegisterUserModel model);        
        Task<LoginResponseModel> LoginAsync(LoginUserModel model);
        Task<bool> RemoveAsync(string id);
    }
}
