using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PlataformaEducacaoOnline.Autenticacao.Interfaces;
using PlataformaEducacaoOnline.Autenticacao.Models;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Messages.IntegrationEvents;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlataformaEducacaoOnline.Autenticacao.Services
{
    public class AutenticacaoServices : IAutenticacaoServices
    {
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly JwtSettingsModel _jwtSettings;
        private readonly IMediatorHandler _mediatorHandler;

        public AutenticacaoServices(
            SignInManager<IdentityUser<Guid>> signInManager,
            UserManager<IdentityUser<Guid>> userManager,
            JwtSettingsModel jwtSettings,
            IMediatorHandler mediatorHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;            
            _jwtSettings = jwtSettings;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginUserModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (result.Succeeded)
            {
                return await GerarJwt(model.Email);
            }
            return null; //TODO lançar notificaoa
        }

        public async Task<IdentityResult> RegisterAsync(RegisterUserModel model)
        {
            var user = Activator.CreateInstance<IdentityUser<Guid>>();
            user.UserName = model.Email;
            user.Email = model.Email;
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                //await _signInManager.SignInAsync(user, false);
                await _mediatorHandler.PublicarEvento(new UsuarioCriadoIntegrationEvent(model.EntityId, user.Id));
            }
            return result;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                await _userManager.DeleteAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<LoginResponseModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseModel
            {
                IsSuccess = true,
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_jwtSettings.Expires).TotalSeconds,
                Id = user.Id,
                Email = user.Email,
                Claims = claims.Select(c => new ClaimModel { Type = c.Type, Value = c.Value })
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
