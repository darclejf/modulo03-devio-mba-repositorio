using Microsoft.AspNetCore.Identity;

namespace PlataformaEducacaoOnline.Autenticacao.Models
{
    public class LoginResponseModel
    {
        public bool IsSuccess { get; set; }
        public Guid? Id { get; set; }
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }        
        public string Email { get; set; }
        public IEnumerable<ClaimModel> Claims { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }

    public class ClaimModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
