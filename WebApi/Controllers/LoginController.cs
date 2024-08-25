using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IObtenerUserPorAliasCU getUserPorAlias { get; set; }
        private ILoginUserCU loginUser;
        private IConfiguration _configuration { get; set; }

        public LoginController(IConfiguration configuration, IObtenerUserPorAliasCU getus, ILoginUserCU loginUser)
        {
            this._configuration = configuration;
            this.getUserPorAlias = getus;
            this.loginUser = loginUser;
        }





        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioDTO user)
        {

            try
            {
                TokenHandler tok = new TokenHandler(getUserPorAlias);
                var usuario = loginUser.Login(user.alias, user.passNormal);
                if (user == null)
                {
                    return Unauthorized("Usuario nulo.");
                }

                if (usuario != null)
                {
                    var tokenHandler = TokenHandler.GenerarToken(user, _configuration);
                    user.token = tokenHandler;
                    user.id = usuario.id;
                    user.esAdmin = usuario.esAdmin;
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return Unauthorized("Datos incorrectos.");
            }
        }


        [HttpGet("{alias}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetUser(string alias)
        {
            try
            {
                UsuarioDTO us = this.getUserPorAlias.getUserPorAlias(alias);
                if (us != null)
                {
                    return Ok(us);
                }
                else
                {
                    return BadRequest("No se encontró el usuario.");
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }



    }
}
