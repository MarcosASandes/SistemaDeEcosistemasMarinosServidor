using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieApiController : ControllerBase
    {

        #region CU
        private IAsociarEspecieCU asociarEspecie;
        private IAddEspecieCU agregarEspecie;
        private IGetEspeciePorNomCU obtenerEspeciePorNombre;
        private IGetEspeciesDeEcosistemasCU obtenerEspeciesDeEcosistema;
        private IGetEspeciesEnPeligroCU obtenerEspeciesEnPeligro;
        private IGetEspeciesPorPesoCU obtenerEspeciesPorPeso;
        private IGetEstadoConservacionPorNivelCU getEstado;
        private IGetTodasLasEspeciesCU getAllEspecies;
        private IGetEspeciePorIdCU getEspeciePorId;
        private IGetAllAmenazasCU getAllAmenazas;
        private IGetAmenazaPorIdCU getAmenazaPorId;
        private IAsociarAmenazaEspecieCU asociarAmenaza;
        private IGetAmenazasSegunEspecieCU getAmenazasDeEspecie;
        private IGetEspeciesPorPesoYNombreCU getEspeciesPorFiltro;
        private IGetEcosistemasSegunEspecieCU getEcosistemasDeLaEspecie;
        private IGetEcosistemasCU getTodosLosEcos;
        private IGetEcosistemaPorIdCU getEcoPorId;
        private IAddEcoHabitableCU addEcoHabitable;
        private IGetEcosistemasHabitablesCU getEcosHabitables;
        private ICambiarNombreImagenEspecieCU cambiarNombreImagen;
        private IWebHostEnvironment _environment;
        private IGetTodasLasImagenesPorEspCU getTodasLasImagenesEsp;
        private IGetPrimerImagenEspCU getPrimerImagen;
        private IEditEspecieCU editEspecie;
        private IGetAmenazasSegunEcosistemaCU getAmenazasEco;
        private IGetEspeciesEnPeligroCU getEspeciesEnPeligro;
        private IGetEcosistemasInadecuadosCU getInadecuados;
        #endregion

        #region Config
        private IRepositorioConfiguracion configRepo;
        #endregion

        #region Inicialización
        public EspecieApiController(IAsociarEspecieCU asociarEspecie,
            IAddEspecieCU agregarEspecie,
            IGetEspeciePorNomCU obtenerEspeciePorNombre,
            IGetEspeciesDeEcosistemasCU obtenerEspeciesDeEcosistema,
            IGetEspeciesEnPeligroCU obtenerEspeciesEnPeligro,
            IGetEspeciesPorPesoCU obtenerEspeciesPorPeso,
            IGetEstadoConservacionPorNivelCU getEstado,
            IGetTodasLasEspeciesCU getAllEspecies,
            IGetEspeciePorIdCU getEspeciePorId,
            IGetAllAmenazasCU getAllAmenazas,
            IGetAmenazaPorIdCU getAmenazaId,
            IAsociarAmenazaEspecieCU asociarAmenazaEspecie,
            IGetAmenazasSegunEspecieCU getAmenazasDeEspecie,
            IGetEspeciesPorPesoYNombreCU getEspeciesPorNombreYPeso,
            IGetEcosistemasSegunEspecieCU getEcosistemasDeLaEspecie,
            IGetEcosistemasCU getTodosLosEcos,
            IGetEcosistemaPorIdCU getecoporid,
            IAddEcoHabitableCU addEcoHabitable,
            IGetEcosistemasHabitablesCU getEcosHabitables,
            ICambiarNombreImagenEspecieCU cambiarNombreImagenEspecie,
            IWebHostEnvironment environment,
            IGetTodasLasImagenesPorEspCU getImagenesEspecie,
            IGetPrimerImagenEspCU getPrimerImagenEsp,
            IEditEspecieCU editarEspecie,
            IGetAmenazasSegunEcosistemaCU getAmenazasDeEco,
            IRepositorioConfiguracion config,
            IGetEspeciesEnPeligroCU getEspeciesEnPeligro,
            IGetEcosistemasInadecuadosCU getInadecuados)
        {
            this.asociarEspecie = asociarEspecie;
            this.agregarEspecie = agregarEspecie;
            this.obtenerEspeciePorNombre = obtenerEspeciePorNombre;
            this.obtenerEspeciesDeEcosistema = obtenerEspeciesDeEcosistema;
            this.obtenerEspeciesEnPeligro = obtenerEspeciesEnPeligro;
            this.obtenerEspeciesPorPeso = obtenerEspeciesPorPeso;
            this.getEstado = getEstado;
            this.getAllEspecies = getAllEspecies;
            this.getEspeciePorId = getEspeciePorId;
            this.getAllAmenazas = getAllAmenazas;
            this.getAmenazaPorId = getAmenazaId;
            this.asociarAmenaza = asociarAmenazaEspecie;
            this.getAmenazasDeEspecie = getAmenazasDeEspecie;
            this.getEspeciesPorFiltro = getEspeciesPorNombreYPeso;
            this.getEcosistemasDeLaEspecie = getEcosistemasDeLaEspecie;
            this.getTodosLosEcos = getTodosLosEcos;
            this.getEcoPorId = getecoporid;
            this.addEcoHabitable = addEcoHabitable;
            this.getEcosHabitables = getEcosHabitables;
            this.cambiarNombreImagen = cambiarNombreImagenEspecie;
            this._environment = environment;
            this.getTodasLasImagenesEsp = getImagenesEspecie;
            this.getPrimerImagen = getPrimerImagenEsp;
            this.editEspecie = editarEspecie;
            this.getAmenazasEco = getAmenazasDeEco;
            this.configRepo = config;
            this.getEspeciesEnPeligro = getEspeciesEnPeligro;
            this.getInadecuados = getInadecuados;
        }
        #endregion


        /// <summary>
        /// Obtener todas las especies.
        /// </summary>
        /// <returns>Lista con todas las especies.</returns>
        [HttpGet(Name = "GetEspecies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                List<EspecieDTO> especies = this.getAllEspecies.obtenerTodasLasEspecies();

                if (especies != null)
                {
                    return Ok(especies);
                }
                else
                {
                    return BadRequest("No se encontraron las especies.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener una especie por su id.
        /// </summary>
        /// <param name="id">Id de la especie.</param>
        /// <returns>Especie.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetPorId(int id)
        {
            try
            {
                EspecieDTO esp = this.getEspeciePorId.obtenerEspeciePorId(id);
                if (esp != null)
                {
                    return Ok(esp);
                }
                else
                {
                    return BadRequest("La especie no s eencontró.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener los ecosistemas habitables de una especie según su id.
        /// </summary>
        /// <param name="id">Id de la especie.</param>
        /// <returns>Lista de ecosistemas.</returns>
        [HttpGet("GetEcosistemasHabitables/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetHabitables(int id)
        {
            try
            {
                List<EcosistemaDTO> ecosistemasHabitables = this.getEcosHabitables.getEcosHabitables(id);
                if (ecosistemasHabitables != null)
                {
                    return Ok(ecosistemasHabitables);
                }
                else
                {
                    return BadRequest("Los ecosistemas habitables no se encontraron.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener los ecosistemas inhabitables de una especie según su id.
        /// </summary>
        /// <param name="id">Id de la especie.</param>
        /// <returns>Lista de ecosistemas.</returns>
        [HttpGet("GetEcosistemasInadecuados/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetInadecuados(int id)
        {
            try
            {
                EspecieDTO unaEsp = getEspeciePorId.obtenerEspeciePorId(id);
                if (unaEsp != null)
                {
                    List<EcosistemaDTO> ecosistemasInadecuados = this.getInadecuados.ObtenerEcosInhabitables(unaEsp);
                    if (ecosistemasInadecuados != null)
                    {
                        return Ok(ecosistemasInadecuados);
                    }
                    else
                    {
                        return BadRequest("No se encontraron los ecosistemas inhabitables.");
                    }
                }
                else
                {
                    return BadRequest("No se encontró la especie.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener los ecosistemas en los que la especie habita, según su id.
        /// </summary>
        /// <param name="id">Id de la especie.</param>
        /// <returns>Lista de ecosistemas.</returns>
        [HttpGet("GetEcosistemasDeEspecie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEcosSegunId(int id)
        {
            try
            {
                List<EcosistemaDTO> ecosistemasDeEsp = this.getEcosistemasDeLaEspecie.getEcosSegunEspecie(id);
                if (ecosistemasDeEsp != null)
                {
                    return Ok(ecosistemasDeEsp);
                }
                else
                {
                    return BadRequest("No se encontraron los ecosistemas de la especie.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener las especies que coincidan con el nombre dado (NombreCientifico).
        /// </summary>
        /// <param name="nombreEspecie">Nombre científico de la especie.</param>
        /// <returns>Lista de especies.</returns>
        [HttpGet("GetByName/{nombreEspecie}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPorNombre(string nombreEspecie)
        {
            try
            {
                List<EspecieDTO> especiesPorNombre = this.obtenerEspeciePorNombre.getEspeciesPorNombre(nombreEspecie);
                if (especiesPorNombre != null)
                {
                    return Ok(especiesPorNombre);
                }
                else
                {
                    return BadRequest("No se encontraron las especies por nombre.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener las especies que estén en peligro de extinción.
        /// </summary>
        /// <returns>Lista de especies.</returns>
        [HttpGet("GetEspeciesEnPeligro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEnPeligro()
        {
            try
            {
                List<EspecieDTO> especiesPeligro = this.getEspeciesEnPeligro.ObtenerEspeciesEnPeligro();
                if (especiesPeligro != null)
                {
                    return Ok(especiesPeligro);
                }
                else
                {
                    return BadRequest("No se encontraron las especies en peligro.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener las especies que su peso oscile en un rango dado.
        /// </summary>
        /// <param name="min">Peso mínimo.</param>
        /// <param name="max">Peso máximo.</param>
        /// <returns>Lista de especies.</returns>
        [HttpGet("minimo={min}/maximo={max}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPorPeso(double min, double max)
        {
            try
            {
                List<EspecieDTO> especiesPeso = this.obtenerEspeciesPorPeso.getEspeciesPorRangoPeso(min, max);
                if (especiesPeso != null)
                {
                    return Ok(especiesPeso);
                }
                else
                {
                    return BadRequest("No se encontraron las especies por nombre y peso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener las especies que coincidan por un nombre dado y a su vez oscilen en peso por unos valores dados.
        /// </summary>
        /// <param name="nombre">Nombre científico.</param>
        /// <param name="min">Peso mínimo.</param>
        /// <param name="max">Peso máximo.</param>
        /// <returns>Lista de especies.</returns>
        [HttpGet("nombre={nombre}/minimo={min}/maximo={max}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPorNombreyPeso(string nombre, double min, double max)
        {
            try
            {
                List<EspecieDTO> especiesPesoNombre = this.getEspeciesPorFiltro.getEspeciesPorPesoYNombre(nombre, min, max);
                if (especiesPesoNombre != null)
                {
                    return Ok(especiesPesoNombre);
                }
                else
                {
                    return BadRequest("No se encontraron las especies por nombre y peso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener la primer imagen de la especie dado su id (La primer imagen es la que contiene "001" en su ruta).
        /// </summary>
        /// <param name="id">Id de especie.</param>
        /// <returns>Lista de objetos que contienen la ruta.</returns>
        [HttpGet("GetPrimerImagen/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetPrimerImagenDeEsp(int id)
        {
            try
            {
                string ruta = this.getPrimerImagen.obtenerPrimerImagenEsp(id);
                EspecieImagenDTO ecoImg = new EspecieImagenDTO();
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
        /// Obtener todas las amenazas de una especie dado su id.
        /// </summary>
        /// <param name="id">Id de especie.</param>
        /// <returns>Lista de especies.</returns>
        [HttpGet("GetAmenazasDeEspecie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAmenazasEspecie(int id)
        {
            try
            {
                List<AmenazaDTO> AmenazasEsp = this.getAmenazasDeEspecie.obtenerAmenazasSegunIdEspecie(id);
                if (AmenazasEsp != null)
                {
                    return Ok(AmenazasEsp);
                }
                else
                {
                    return BadRequest("No se encontraron las amenazas de la especie.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Crear una nueva especie.
        /// </summary>
        /// <param name="Esp">Especie</param>
        /// <returns>Devuelve la especie creada.</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Post(EspecieAliasDTO Esp)
        {
            try
            {
                if (Esp != null)
                {
                    EspecieDTO especie = Esp.obj as EspecieDTO;
                    EspecieDTO espDTO = this.agregarEspecie.AltaEspecie(especie);
                    return Created("api/EspecieApi", espDTO);
                }
                else
                {
                    return BadRequest("No se pudo crear la especie.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener todas las imagenes de una especie según su id.
        /// </summary>
        /// <param name="id">Id de la especie.</param>
        /// <returns>Devuelve una lista con todas las imágenes de esa especie.</returns>
        [HttpGet("GetImagenesEspecie/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetImagenesDeEspecie(int id)
        {
            try
            {
                List<string> rutas = getTodasLasImagenesEsp.obtenerTodasLasRutasEspecie(id);
                List<EspecieImagenDTO> imagenesDeEspecie = new List<EspecieImagenDTO>();
                for (int i = 0; i < rutas.Count; i++)
                {
                    var elemento = rutas[i];
                    EspecieImagenDTO esp = new EspecieImagenDTO();
                    esp.idEspecie = id;
                    esp.ruta = elemento;
                    imagenesDeEspecie.Add(esp);
                }

                return Ok(imagenesDeEspecie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetEstadoPorNivel/{nivel}")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetIdEstadoPorNivel(int nivel)
        {
            try
            {
                EstadoDTO espDTO = this.getEstado.obtenerEstado(nivel);
                if (espDTO != null)
                {
                    return Ok(espDTO.id);
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
        /// Edita la especie para que se guarde la imagen que contiene.
        /// </summary>
        /// <param name="esp">Especie con su imagen</param>
        /// <returns>Devuelve la especie editada.</returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GuardarImagen([FromBody] EspecieAliasDTO esp)
        {
            try
            {
                if (esp != null)
                {
                    EspecieDTO especie = esp.obj as EspecieDTO;
                    this.cambiarNombreImagen.CambiarNombreImagenEspecie(especie, esp.alias);
                    return Ok(esp);
                }
                else
                {
                    return BadRequest("La especie es nula.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Edita la especie para que se guarden los nuevos datos.
        /// </summary>
        /// <param name="esp">Especie con datos parcial o totalmente editados.</param>
        /// <returns>Devuelve la especie editada.</returns>
        [HttpPut("EditarEspecie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult EditarEspeciePut([FromBody] EspecieAliasDTO esp)
        {
            try
            {
                if (esp != null)
                {
                    EspecieDTO especie = esp.obj;
                    this.editEspecie.editarEspecie(especie, esp.alias);
                    return Ok(esp.obj);
                }
                else
                {
                    return BadRequest("La especie es nula.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //VER DESPUES
        /// <summary>
        /// Agrega una amenaza a la especie y lo guarda en la BD.
        /// </summary>
        /// <param name="esp">Especie con una amenaza agregada.</param>
        /// <returns>Devuelve la especie editada.</returns>
        [HttpPut("AgregarAmenazaEspecie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AgregarAmenazaPut([FromBody] EspecieAliasDTO esp)
        {
            try
            {
                if (esp != null)
                {
                    EspecieDTO especie = esp.obj as EspecieDTO;
                    this.asociarAmenaza.asociarAmenazaEspecie(especie, esp.alias);
                    return Ok(esp);
                }
                else
                {
                    return BadRequest("No se ha encontrado la especie.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Agrega un ecosistema habitable a la especie y lo guarda en la BD.
        /// </summary>
        /// <param name="esp">Especie con un ecosistema agregado.</param>
        /// <returns>Devuelve la especie editada.</returns>
        [HttpPut("AgregarHabitableEspecie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AgregarEcoHabitablePut([FromBody] EspecieAliasDTO esp)
        {
            try
            {
                if (esp != null)
                {
                    EspecieDTO especie = esp.obj as EspecieDTO;
                    EcosistemaDTO EcosistemaHabitable = null;
                    foreach (EcosistemaEspecieDTO ecoEsp in especie._ecosistemas)
                    {
                        EcosistemaHabitable = getEcoPorId.GetEcoPorId(ecoEsp.idEcosistema);
                    }

                    if (!getEcosHabitables.getEcosHabitables(especie.id).Contains(EcosistemaHabitable))
                    {
                        this.addEcoHabitable.agregarEcosistemaHabitable(especie, esp.alias);
                        return Ok(esp);
                    }
                    else
                    {
                        return BadRequest("Ese ecosistema ya esta agregado.");
                    }
                }
                else
                {
                    return BadRequest("La especie es null.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
