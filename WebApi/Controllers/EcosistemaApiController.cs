using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcosistemaApiController : ControllerBase
    {
        #region CU
        private IAddEcosistemaCU agregarEcosistemaCU;
        private IGetEcosistemasCU obtenerEcosistemaCU;
        private IGetEcosistemaPorIdCU obtenerEcosistemaPorId;
        private IGetEcosistemasInadecuadosCU obtenerEcosInadecuadosCU;
        private IGetPaisesCU getPaisesCU;
        private IGetPaisPorIdCU getPaisPorIdCU;
        private IGetEstadoConservacionPorNivelCU getEstado;
        private IGetAllAmenazasCU obtenerTodasAmenazas;
        private IGetAmenazaPorIdCU getAmenazaPorId;
        private IAsociarAmenazaEcosistemaCU asociarAmenazaEcosistema;
        private IGetAmenazasSegunEcosistemaCU obtenerAmenazasSegunEcosistema;
        private IAsociarEspecieCU asociarUnaEspecie;
        private IGetTodasLasEspeciesCU getAllEspecies;
        private IGetEspeciePorIdCU getEspeciePorId;
        private IGetEspeciesSegunEcosistemaCU getEspeciesDeEcosistema;
        private IGetEstadoPorIdCU getEstadoPorId;
        private IEditEcosistemaCU editarEco;
        private IRemoveEcosistemaCU borrarEco;
        private IGetAmenazasSegunEspecieCU getAmenazasDeEspecie;
        private ICambiarNombreImagenEcoCU cambiarNombreImagen;
        private IWebHostEnvironment _environment;
        private IGetTodasLasImagenesPorEcoCU getImagenesEcoId;
        private IGetPrimerImagenEcoCU getPrimerImagenEcoId;
        #endregion

        #region Repo config
        private IRepositorioConfiguracion configRepo;
        #endregion

        #region Inicialización
        public EcosistemaApiController(IAddEcosistemaCU agregarEco,
            IGetEcosistemasCU obtenerEcos,
            IGetEcosistemasInadecuadosCU obtenerEcosInadecuados,
            IGetPaisesCU getPaises,
            IGetPaisPorIdCU getPaisPorIdCU,
            IGetEcosistemaPorIdCU obtenerEcosistemaPorId,
            IGetEstadoConservacionPorNivelCU getEstado,
            IGetAllAmenazasCU obtenerTodasAmenazas,
            IGetAmenazaPorIdCU getAmenazaPorId,
            IAsociarAmenazaEcosistemaCU asociarAmenazaEcosistema,
            IGetAmenazasSegunEcosistemaCU obtenerAmenazasSegunEcosistema,
            IAsociarEspecieCU asociarUnaEspecie,
            IGetTodasLasEspeciesCU getAllEspecies,
            IGetEspeciePorIdCU getEspeciePorId,
            IGetEspeciesSegunEcosistemaCU getEspeciesDeEcosistema,
            IGetEstadoPorIdCU getEstadoPorId,
            IEditEcosistemaCU editarEco,
            IRemoveEcosistemaCU borrarEco,
            IGetAmenazasSegunEspecieCU getAmenazasDeEspecie,
            ICambiarNombreImagenEcoCU cambiarNombreImagen,
            IWebHostEnvironment environment,
            IGetTodasLasImagenesPorEcoCU getImagenesEcoId,
            IGetPrimerImagenEcoCU getPrimerImagenEcoId,
            IRepositorioConfiguracion config)
        {
            this.agregarEcosistemaCU = agregarEco;
            this.obtenerEcosistemaCU = obtenerEcos;
            this.obtenerEcosInadecuadosCU = obtenerEcosInadecuados;
            this.getPaisesCU = getPaises;
            this.getPaisPorIdCU = getPaisPorIdCU;
            this.obtenerEcosistemaPorId = obtenerEcosistemaPorId;
            this.getEstado = getEstado;
            this.obtenerTodasAmenazas = obtenerTodasAmenazas;
            this.getAmenazaPorId = getAmenazaPorId;
            this.asociarAmenazaEcosistema = asociarAmenazaEcosistema;
            this.obtenerAmenazasSegunEcosistema = obtenerAmenazasSegunEcosistema;
            this.asociarUnaEspecie = asociarUnaEspecie;
            this.getAllEspecies = getAllEspecies;
            this.getEspeciePorId = getEspeciePorId;
            this.getEspeciesDeEcosistema = getEspeciesDeEcosistema;
            this.getEstadoPorId = getEstadoPorId;
            this.editarEco = editarEco;
            this.borrarEco = borrarEco;
            this.getAmenazasDeEspecie = getAmenazasDeEspecie;
            this.cambiarNombreImagen = cambiarNombreImagen;
            _environment = environment;
            this.getImagenesEcoId = getImagenesEcoId;
            this.getPrimerImagenEcoId = getPrimerImagenEcoId;
            this.configRepo = config;
        }
        #endregion


        /// <summary>
        /// Obtener todos los ecosistemas.
        /// </summary>
        /// <returns>Lista con todos los ecosistemas.</returns>
        [HttpGet(Name = "GetEcosistemas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                List<EcosistemaDTO> ecosistemas = this.obtenerEcosistemaCU.GetEcosistemas();
                if (ecosistemas != null)
                {
                    return Ok(ecosistemas);
                }
                else
                {
                    return BadRequest("No se encontraron los ecosistemas.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener un ecosistema según su id.
        /// </summary>
        /// <param name="id">Id del ecosistema</param>
        /// <returns>Ecosistema</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPorId(int id)
        {
            try
            {
                EcosistemaDTO eco = this.obtenerEcosistemaPorId.GetEcoPorId(id);
                if (eco != null)
                {
                    return Ok(eco);
                }
                else
                {
                    return BadRequest("No se encontró el ecosistema.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener todas las especies que habiten en un ecosistema según su id.
        /// </summary>
        /// <param name="id">Id del ecosistema</param>
        /// <returns>Lista de especies.</returns>
        [HttpGet("GetEspDeEco/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEspSegunId(int id)
        {
            try
            {
                List<EspecieDTO> espDeEco = this.getEspeciesDeEcosistema.obtenerEspeciesDeEcosistema(id);
                if (espDeEco != null)
                {
                    return Ok(espDeEco);
                }
                else
                {
                    return BadRequest("No se encontraron las especies del ecosistema.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener la primer imagen del ecosistema según su id (Imagen que contenga 001 en su nombre).
        /// </summary>
        /// <param name="id">Id de ecosistema.</param>
        /// <returns>Objeto que contiene la ruta de la imagen.</returns>
        [HttpGet("GetPrimerImagen/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetPrimerImagenDeEco(int id)
        {
            try
            {
                string ruta = this.getPrimerImagenEcoId.obtenerPrimerImagenDeEco(id);
                EcosistemaImagenDTO ecoImg = new EcosistemaImagenDTO();
                ecoImg.ruta = ruta;
                ecoImg.id = id;
                return Ok(ecoImg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener las amenazas del ecosistema según su id.
        /// </summary>
        /// <param name="id">Id del ecosistema</param>
        /// <returns>Lista de amenazas.</returns>
        [HttpGet("GetAmenazasDeEcosistema/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAmenazasEcosistema(int id)
        {
            try
            {

                List<AmenazaDTO> AmenazasEsp = this.obtenerAmenazasSegunEcosistema.obtenerAmenazasDeEcosistema(id);
                if (AmenazasEsp != null)
                {
                    return Ok(AmenazasEsp);
                }
                else
                {
                    return BadRequest("No se encontraron las amenazas del ecosistema.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Crear un nuevo ecosistema.
        /// </summary>
        /// <param name="Eco">Ecosistema</param>
        /// <returns>Devuelve el ecosistema creado.</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Post(EcosistemaAliasDTO Eco)
        {
            try
            {
                if (Eco != null)
                {
                    EcosistemaDTO ecoDTO = this.agregarEcosistemaCU.AltaEcosistema(Eco.obj);
                    return Created("api/EcosistemaApi", ecoDTO);
                }
                else
                {
                    return BadRequest("El ecosistema es nulo.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener todas las imagenes de un ecosistema según su id.
        /// </summary>
        /// <param name="id">Id del ecosistema.</param>
        /// <returns>Devuelve una lista con todas las imágenes de ese ecosistema.</returns>
        [HttpGet("GetImagenesEcosistema/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetImagenesDeEcosistema(int id)
        {
            try
            {
                List<string> rutas = getImagenesEcoId.obtenerTodasLasRutasPorEco(id);
                List<EcosistemaImagenDTO> imagenesDeEcosistema = new List<EcosistemaImagenDTO>();
                for (int i = 0; i < rutas.Count; i++)
                {
                    var elemento = rutas[i];
                    EcosistemaImagenDTO eco = new EcosistemaImagenDTO();
                    eco.idEcosistema = id;
                    eco.ruta = elemento;
                    imagenesDeEcosistema.Add(eco);
                }

                return Ok(imagenesDeEcosistema);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetEstadoPorNivel/{nivel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetIdEstadoPorNivel(int nivel)
        {
            try
            {
                EstadoDTO ecoDTO = this.getEstado.obtenerEstado(nivel);
                if (ecoDTO != null)
                {
                    return Ok(ecoDTO.id);
                }
                else
                {
                    return BadRequest("No se encontró el estado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita el ecosistema para que se guarde la imagen que contiene.
        /// </summary>
        /// <param name="eco">Ecosistema con su imagen</param>
        /// <returns>Devuelve el ecosistema editado.</returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GuardarImagen([FromBody] EcosistemaAliasDTO eco)
        {
            try
            {
                if (eco != null)
                {
                    this.cambiarNombreImagen.CambiarNombreImagenEco(eco.obj, eco.alias);
                    return Ok(eco);
                }
                else
                {
                    return BadRequest("El ecosistema es nulo.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Elimina el ecosistema según la id dada.
        /// </summary>
        /// <param name="id">Id del ecosistema.</param>
        /// <param name="alias">Alias user.</param>
        /// <returns>No devuelve nada.</returns>
        [HttpDelete("{id}/{alias}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult BorrarEcosistemaPorId(int id, string alias)
        {
            try
            {
                if (getEspeciesDeEcosistema.obtenerEspeciesDeEcosistema(id).Count == 0)
                {
                    EcosistemaDTO ecoEncontrado = this.obtenerEcosistemaPorId.GetEcoPorId(id);
                    this.borrarEco.RemoveEcosistema(ecoEncontrado, alias);
                    return NoContent();
                }
                else
                {
                    return BadRequest("El ecosistema tiene especies.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Edita el ecosistema para que se guarden los nuevos datos.
        /// </summary>
        /// <param name="eco">Ecosistema con datos parcial o totalmente editados.</param>
        /// <returns>Devuelve el ecosistema editado.</returns>
        [HttpPut("EditarEcosistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult EditarEcosistemaPut([FromBody] EcosistemaAliasDTO eco)
        {
            try
            {
                if (eco != null)
                {
                    this.editarEco.editarEcosistema(eco.obj, eco.alias);
                    return Ok(eco);
                }
                else
                {
                    return BadRequest("El ecosistema es nulo.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Agrega una amenaza al ecosistema y lo guarda en la BD.
        /// </summary>
        /// <param name="eco">Ecosistema con una amenaza agregada.</param>
        /// <returns>Devuelve el ecosistema editado.</returns>
        [HttpPut("AgregarAmenazaEcosistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AgregarAmenazaPut([FromBody] EcosistemaAliasDTO eco)
        {
            try
            {
                if (eco != null)
                {
                    this.asociarAmenazaEcosistema.asociarAmenaza(eco.obj, eco.alias);
                    return Ok(eco);
                }
                else
                {
                    return BadRequest("No se ha encontrado el ecosistema.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Agrega una especie al ecosistema y lo guarda en la BD.
        /// </summary>
        /// <param name="eco">Ecosistema con una especie agregada.</param>
        /// <returns>Devuelve el ecosistema editado.</returns>
        [HttpPut("AgregarEspecieEcosistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult AgregarEspeciePut([FromBody] EcosistemaAliasDTO eco)
        {
            try
            {
                EcosistemaDTO ecoDto = eco.obj;
                EspecieDTO espDto = null;
                foreach (EcosistemaEspecieDTO ecoEsp in ecoDto._especies)
                {
                    espDto = getEspeciePorId.obtenerEspeciePorId(ecoEsp.idEspecie);
                }

                if (!ContieneEspecie(ecoDto.id, espDto.id))
                {

                    if (ecoDto.nivelConservacion < espDto.nivelConservacion)
                    {
                        return BadRequest("El ecosistema tiene un nivel de conservación menor.");
                    }

                    if (CompartenAmenazas(ecoDto.id, espDto.id))
                    {
                        return BadRequest("El ecosistema y la especie comparten amenazas.");
                    }

                    this.asociarUnaEspecie.asociarUnaEspecie(eco.obj, eco.alias);
                    return Ok(eco);
                }
                else
                {
                    return BadRequest("La especie ya está agregada al ecosistema.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        #region Metodos auxiliares.
        private bool ContieneEspecie(int idEco, int idEsp)
        {
            try
            {
                bool ret = false;
                List<EspecieDTO> especiesDelEco = getEspeciesDeEcosistema.obtenerEspeciesDeEcosistema(idEco);
                foreach (EspecieDTO e in especiesDelEco)
                {
                    if (e.id == idEsp)
                    {
                        ret = true;
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }


        
        private bool CompartenAmenazas(int idEco, int idEsp)
        {
            bool ret = false;
            List<AmenazaDTO> amenazasEco = obtenerAmenazasSegunEcosistema.obtenerAmenazasDeEcosistema(idEco);
            List<AmenazaDTO> amenazasEsp = getAmenazasDeEspecie.obtenerAmenazasSegunIdEspecie(idEsp);
            foreach (AmenazaDTO aEco in amenazasEco)
            {
                foreach (AmenazaDTO aEsp in amenazasEsp)
                {
                    if (aEco.id == aEsp.id)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }
        #endregion
    }
}
