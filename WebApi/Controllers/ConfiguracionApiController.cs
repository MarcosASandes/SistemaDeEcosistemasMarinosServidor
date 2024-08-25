using EcoMarino.Entidades;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionApiController : ControllerBase
    {

        private HttpClient cliente = new HttpClient();
        private string uriText = "http://localhost:1234/api/config";

        private IGetConfiguracionesCU getConfiguraciones;
        private IGetConfiguracionPorNombreCU getConfiguracionPorNombre;
        private IEditConfiguracionCU editConfiguracion;

        public ConfiguracionApiController(IGetConfiguracionesCU getConfiguraciones, IGetConfiguracionPorNombreCU getConfiguracionPorNombre, IEditConfiguracionCU editConfiguracion)
        {
            this.getConfiguraciones = getConfiguraciones;
            this.getConfiguracionPorNombre = getConfiguracionPorNombre;
            this.editConfiguracion = editConfiguracion;
        }


        /// <summary>
        /// Obtener todos los topes con sus respectivos máximos y mínimos.
        /// </summary>
        /// <returns>Lista de los topes que se pueden actualizar, incluyendo el nombre del elemento.</returns>
        [HttpGet(Name = "GetTopes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {

                List<ConfiguracionDTO> c = this.getConfiguraciones.ObtenerConfiguraciones();
                if (c != null)
                {
                    return Ok(c);
                }
                else
                {
                    return BadRequest("No se encontraron las configuraciones.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Editar los topes de los nombres y descripciones.
        /// </summary>
        /// <param name="config">Objeto con el nombre del atributo y los topes nuevos.</param>
        /// <returns>Configuración con nuevos topes.</returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult EditarTopesConfig([FromBody] ConfiguracionDTO config)
        {
            try
            {
                if (config != null)
                {
                    this.editConfiguracion.editarConfiguracion(config);
                    return Ok(config);
                }
                else
                {
                    return BadRequest("La configuración es nula.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener un objeto en concreto para configurar sus topes.
        /// </summary>
        /// <param name="nombre">Nombre del atributo.</param>
        /// <returns>Devuelve el objeto buscado.</returns>
        [HttpGet("{nombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetPorNombre(string nombre)
        {
            try
            {
                ConfiguracionDTO c = this.getConfiguracionPorNombre.obtenerConfigPorNombre(nombre);
                if (c != null)
                {
                    return Ok(c);
                }
                else
                {
                    return BadRequest("No se encontró la configuración.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
