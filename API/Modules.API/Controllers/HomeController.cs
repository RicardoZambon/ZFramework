using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZFramework.Modules.API.Models;
using ZFramework.Modules.API.Repositories;
using ZFramework.Modules.API.Services;

namespace ZFramework.Modules.API.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserModel model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet, Route("authenticated"), Authorize]
        public string Authenticated() => string.Format("Autenticado - {0}", User.Identity.Name);
    }
}