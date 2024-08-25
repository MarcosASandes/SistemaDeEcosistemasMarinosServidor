using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenazaApiController : ControllerBase
    {
        private IGetAllAmenazasCU getAmenazas { get; set; }
        private IGetAmenazaPorIdCU getAmenazaPorid { get; set; }

        public AmenazaApiController(IGetAllAmenazasCU getAm, IGetAmenazaPorIdCU getAmenazaPorid)
        {
            this.getAmenazas = getAm;
            this.getAmenazaPorid = getAmenazaPorid;
        }

        /// <summary>
        /// Obtener todas las amenazas.
        /// </summary>
        /// <returns>Lista de todas las amenazas.</returns>
        [HttpGet(Name = "GetAmenazas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                List<AmenazaDTO> amenazas = this.getAmenazas.obtenerAmenazas();
                if (amenazas != null)
                {
                    return Ok(amenazas);
                }
                else
                {
                    return BadRequest("No se encontraron las amenazas.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener una amenaza según su id.
        /// </summary>
        /// <param name="id">Id de la amenaza.</param>
        /// <returns>Amenaza</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAmenaza(int id)
        {
            try
            {
                return Ok(this.getAmenazaPorid.obtenerAmenazaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
