using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacaoOnline.Autenticacao.Interfaces;
using PlataformaEducacaoOnline.Autenticacao.Models;

namespace PlataformaEducacaoOnline.API.V1.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoServices _services;

        public AutenticacaoController(IAutenticacaoServices services)
        {
            _services = services;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserModel loginUser)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _services.LoginAsync(loginUser);

                //if (result.Succeeded)
                //{
                //    _logger.LogInformation("Usuario " + loginUser.Email + " logado com sucesso");
                //    return CustomResponse(await GerarJwt(loginUser.Email));
                //}
                //if (result.IsLockedOut)
                //{
                //    NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                //    return CustomResponse(loginUser);
                //}

                //NotificarErro("Usuário ou Senha incorretos");
            return Ok(result);
        }
    }
}
