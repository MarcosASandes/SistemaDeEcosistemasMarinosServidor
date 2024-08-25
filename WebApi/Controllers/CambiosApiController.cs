using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CambiosApiController : ControllerBase
    {

        private IGetTodosLosCambiosCU getTodosLosCambiosCU;

        public CambiosApiController(IGetTodosLosCambiosCU getTodosLosCambiosCU)
        {
            this.getTodosLosCambiosCU = getTodosLosCambiosCU;
        }

        /// <summary>
        /// Obtener todos los cambios hechos.
        /// </summary>
        /// <returns>Lista de los cambios que se realizaron.</returns>
        [HttpGet(Name = "GetCambios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                List<CambiosDTO> cambios = this.getTodosLosCambiosCU.getAllCambios();
                if (cambios != null)
                {
                    return Ok(cambios);
                }
                else
                {
                    return BadRequest("No se encontraron los cambios.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
