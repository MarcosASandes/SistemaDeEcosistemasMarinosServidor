using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisApiController : ControllerBase
    {

        private IGetPaisesCU getPaisesCU;
        private IGetPaisPorIdCU getPaisPorIdCU;

        public PaisApiController(IGetPaisesCU getPaisesCU, IGetPaisPorIdCU getPaisPorIdCU)
        {
            this.getPaisesCU = getPaisesCU;
            this.getPaisPorIdCU = getPaisPorIdCU;
        }

        /// <summary>
        /// Obtener todos los paises.
        /// </summary>
        /// <returns>Lista de paises.</returns>
        [HttpGet(Name = "GetPaises")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                List<PaisDTO> paises = this.getPaisesCU.ObtenerPaises();
                if (paises != null)
                {
                    return Ok(paises);
                }
                else
                {
                    return BadRequest("No se encontraron los paises.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
