using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
        private IRegistroUserCU registroUserCU;
        public UsuarioApiController(IRegistroUserCU registroUserCU)
        {
            this.registroUserCU = registroUserCU;
        }



        /// <summary>
        /// Crea un usuario.
        /// </summary>
        /// <param name="user">Usuario parcialmente creado desde las vistas.</param>
        /// <returns>Devuelve el usuario creado.</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Post([FromBody] UsuarioAliasDTO user)
        {
            try
            {
                if (user != null)
                {
                    UsuarioDTO usuarioCreado = this.registroUserCU.RegistrarUsuario(user.obj, user.alias);
                    return Created("api/UsuarioApi", usuarioCreado);
                }
                else
                {
                    return BadRequest("El usuario es nulo.");
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



    }
}
