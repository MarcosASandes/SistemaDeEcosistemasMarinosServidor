using EcoMarino.Entidades;
using EcoMarino.Exceptions;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using EcoMarino.ValueObjects;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;

namespace IUWeb.Controllers
{
    public class EcosistemaController : Controller
    {
        private HttpClient cliente = new HttpClient();
        private string uriText = "http://localhost:1234/api/ecosistemas";

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
        private IRepositorioConfiguracion configRepo;

        #region Inicialización
        public EcosistemaController(IAddEcosistemaCU agregarEco,
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

        // GET: EcosistemaController
        public ActionResult Index()
        {
            return View(obtenerEcosistemaCU.GetEcosistemas());
        }

        // GET: EcosistemaController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.primerImagen = getPrimerImagenEcoId.obtenerPrimerImagenDeEco(id);
            return View(obtenerEcosistemaPorId.GetEcoPorId(id));
        }

        // GET: EcosistemaController/Create
        public ActionResult Create()
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.Paises = getPaisesCU.ObtenerPaises();
                    return View();
                }
                else
                {
                    throw new UsuarioException("Funcionalidad restringida para logueados.");
                }
            }
            catch (UsuarioException usEx)
            {
                TempData["redirectToLogin"] = usEx.Message;
                return RedirectToAction("Login", "Home");
            }
            catch (Exception e)
            {
                TempData["redirectToLogin"] = e.Message;
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: EcosistemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EcosistemaDTO unEco, double lat, double lon, string paisSeleccionado, IFormFile imagen)
        {
            try
            {
                ViewBag.Paises = getPaisesCU.ObtenerPaises();
                EstadoDTO nuevoEstado = getEstado.obtenerEstado(unEco.nivelConservacion);
                PaisDTO unPais = getPaisPorIdCU.ObtenerPaisPorId(paisSeleccionado);
                unEco.latitud = lat;
                unEco.longitud = lon;
                unEco.idEstado = nuevoEstado.id;
                unEco.codigoAlpha = paisSeleccionado;
                agregarEcosistemaCU.AltaEcosistema(unEco); 
                unEco.paisResponsable = unPais;
                unEco.estado = nuevoEstado;
                if (GuardarImagen(imagen, unEco))
                {
                    string extension = imagen.FileName.Split(".").Last();
                    foreach (EcosistemaImagenDTO e in unEco._imagenes)
                    {
                        e.ruta = SetNombreDeImagen(unEco.id) + "." + extension;
                        cambiarNombreImagen.CambiarNombreImagenEco(unEco, HttpContext.Session.GetString("LogueadoAlias"));
                    }
                    unEco.estado = nuevoEstado;
                    unEco.paisResponsable = unPais;
                    ViewBag.msg = "Agregado correctamente.";

                    return View();
                }
                else
                {
                    ViewBag.msg = "El ecosistema no pudo ser cargado debido a un problema con la imagen.";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }

        private string SetNombreDeImagen(int idEco)
        {
            List<string> rutasEco = getImagenesEcoId.obtenerTodasLasRutasPorEco(idEco);

            // Determina el siguiente número en la serie
            int siguienteNumero = 1;
            if (rutasEco.Count > 0)
            {
                // Si existen rutas, obtén el número más alto y agrega uno
                int numeroMasAlto = rutasEco.Select(ruta => int.Parse(ruta.Substring(ruta.IndexOf('_') + 1))).Max();
                siguienteNumero = numeroMasAlto + 1;
            }

            // Formatea el nuevo nombre con el id y el número
            string nuevoNombre = $"{idEco}_{siguienteNumero:D3}";

            return nuevoNombre;
        }



        private bool GuardarImagen(IFormFile imagen, EcosistemaDTO e)
        {
            if (imagen == null || e == null)
            {
                return false;
            }
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            //Asignacion del nombre que corresponde a la imagen
            string extension = imagen.FileName.Split(".").Last();
            if (extension == "png" || extension == "jpg" || extension == "jpeg")
            {
                //string nombreImagen = imagen.FileName;
                string nombreImagen = SetNombreDeImagen(e.id) + "." + extension;
                //ruta donde se guardan las fotos de las personas
                string rutaFisicaFoto = Path.Combine
                (rutaFisicaWwwRoot, "img", "ecosistemas", nombreImagen);
                //FileStream permite manejar archivos
                try
                {
                    //el método using libera los recursos del objeto FileStream al finalizar
                    using (FileStream f = new FileStream(rutaFisicaFoto, FileMode.Create))
                    {
                        //Para archivos grandes o varios archivos usar la versión
                        //asincrónica de CopyTo. Sería: await imagen.CopyToAsync (f);
                        imagen.CopyTo(f);
                    }
                    //GUARDAR EL NOMBRE DE LA IMAGEN SUBIDA EN EL OBJETO
                    //tengo que crear el VO de la imagen debería validar todo esto RECORDAR MAS TARDE
                    EcosistemaImagenDTO ecoImg = new EcosistemaImagenDTO();
                    ecoImg.ruta = nombreImagen;
                    ecoImg.idEcosistema = e.id;
                    e.AgregarImagen(ecoImg);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


        // GET: EcosistemaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.IdEco = id;
                    return View();
                }
                else
                {
                    throw new UsuarioException("Funcionalidad restringida para logueados.");
                }
            }
            catch(UsuarioException usEx)
            {
                TempData["redirectToLogin"] = usEx.Message;
                return RedirectToAction("Login", "Home");
            }
            catch (Exception e)
            {
                TempData["redirectToLogin"] = e.Message;
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: EcosistemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string nameEco, string descEco, int IdEco)
        {
            try
            {
                EcosistemaDTO ecoBuscado = obtenerEcosistemaPorId.GetEcoPorId(IdEco);
                if (nameEco != null)
                {
                    ecoBuscado.nombre = nameEco;
                }
                if (descEco != null)
                {
                    ecoBuscado.descripcion = descEco;
                }
                editarEco.editarEcosistema(ecoBuscado, HttpContext.Session.GetString("LogueadoAlias"));
                TempData["tempMsg"] = "Editado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.IdEco = IdEco;
                ViewBag.Msg = e.Message;
                return View();
            }
        }

        // GET: EcosistemaController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.IdEco = id;
                    return View(obtenerEcosistemaPorId.GetEcoPorId(id));
                }
                else
                {
                    throw new UsuarioException("Funcionalidad restringida para logueados.");
                }
            }
            catch (UsuarioException usEx)
            {
                TempData["redirectToLogin"] = usEx.Message;
                return RedirectToAction("Login", "Home");
            }
            catch (Exception e)
            {
                TempData["redirectToLogin"] = e.Message;
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: EcosistemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool confirmacion)
        {
            try
            {
                if (confirmacion)
                {
                    EcosistemaDTO aBorrar = obtenerEcosistemaPorId.GetEcoPorId(id);
                    if (getEspeciesDeEcosistema.obtenerEspeciesDeEcosistema(id).Count == 0)
                    {
                        borrarEco.RemoveEcosistema(aBorrar, HttpContext.Session.GetString("LogueadoAlias"));
                        TempData["tempMsg"] = "Ecosistema borrado correctamente.";                        

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["tempMsg"] = "El ecosistema posee especies.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ViewBag.errorMsg = "Debe confirmar la eliminación.";
                    ViewBag.IdEco = id;
                    return View(obtenerEcosistemaPorId.GetEcoPorId(id));
                }
            }
            catch (Exception e)
            {
                TempData["tempMsg"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public ActionResult AsociarAmenazas(int idEco)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.idEcosistema = idEco;
                    return View(obtenerTodasAmenazas.obtenerAmenazas());
                }
                else
                {
                    throw new UsuarioException("Funcionalidad restringida para logueados.");
                }
            }
            catch (UsuarioException usEx)
            {
                TempData["redirectToLogin"] = usEx.Message;
                return RedirectToAction("Login", "Home");
            }
            catch (Exception e)
            {
                TempData["redirectToLogin"] = e.Message;
                return RedirectToAction("Login", "Home");
            }            
        }


        [HttpPost]
        public ActionResult AsociarAmenazas(int idEco, int idAmenaza)
        {
            try
            {
                EcosistemaDTO EcoEncontrado = obtenerEcosistemaPorId.GetEcoPorId(idEco);
                AmenazaDTO AmenazaParaAsociar = getAmenazaPorId.obtenerAmenazaPorId(idAmenaza);
                EcoEncontrado.AgregarAmenaza(AmenazaParaAsociar);
                asociarAmenazaEcosistema.asociarAmenaza(EcoEncontrado, HttpContext.Session.GetString("LogueadoAlias"));
                TempData["tempMsg"] = "La amenaza se agregó correctamente a " + EcoEncontrado.nombre;

                return RedirectToAction("Index", "Ecosistema");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return View();
            }
        }


        public ActionResult MostrarAmenazas(int idEco)
        {
            return View(obtenerAmenazasSegunEcosistema.obtenerAmenazasDeEcosistema(idEco));
        }



        public ActionResult AsociarEspecie(int idEco)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.idEcosistema = idEco;
                    return View(getAllEspecies.obtenerTodasLasEspecies());
                }
                else
                {
                    throw new UsuarioException("Funcionalidad restringida para logueados.");
                }
            }
            catch (UsuarioException usEx)
            {
                TempData["redirectToLogin"] = usEx.Message;
                return RedirectToAction("Login", "Home");
            }
            catch (Exception e)
            {
                TempData["redirectToLogin"] = e.Message;
                return RedirectToAction("Login", "Home");
            }            
        }


        [HttpPost]
        public ActionResult AsociarEspecie(int idEco, int idEsp)
        {
            try
            {
                EcosistemaDTO EcoEncontrado = obtenerEcosistemaPorId.GetEcoPorId(idEco);
                EspecieDTO EspEncontrada = getEspeciePorId.obtenerEspeciePorId(idEsp);

                //Verifico que la especie no este agregada al ecosistema.
                foreach (EspecieDTO e in getEspeciesDeEcosistema.obtenerEspeciesDeEcosistema(idEco))
                {
                    if (e.id == idEsp)
                    {
                        throw new EcosistemaException("La especie ya está agregada al ecosistema " + EcoEncontrado.nombre);
                    }
                }

                //Verifico que el nivel de conservacion del ecosistema no sea peor que el de la especie
                if (EcoEncontrado.nivelConservacion < EspEncontrada.nivelConservacion)
                {
                    throw new EcosistemaException($"La especie {EspEncontrada.nombre} no puede agregarse a un ecosistema con peor nivel de conservacion {EcoEncontrado.nombre} (Nivel: {EcoEncontrado.nivelConservacion})");
                }

                //Verifico que el ecosistema y la especie no comparten amenazas
                List<AmenazaDTO> amenazasDeEcosistema = obtenerAmenazasSegunEcosistema.obtenerAmenazasDeEcosistema(EcoEncontrado.id);
                List<AmenazaDTO> amenazasDeEspecie = getAmenazasDeEspecie.obtenerAmenazasSegunIdEspecie(EspEncontrada.id);
                foreach (AmenazaDTO aEco in amenazasDeEcosistema)
                {
                    foreach (AmenazaDTO aEsp in amenazasDeEspecie)
                    {
                        if (aEco.id == aEsp.id)
                        {
                            throw new EcosistemaException($"El ecosistema {EcoEncontrado.nombre} comparte amenazas con {EspEncontrada.nombre}");
                        }
                    }
                }

                EcoEncontrado.AgregarEspecieHabita(EspEncontrada);
                asociarUnaEspecie.asociarUnaEspecie(EcoEncontrado, HttpContext.Session.GetString("LogueadoAlias"));
                TempData["tempMsg"] = "La especie se agregó correctamente a " + EcoEncontrado.nombre;                

                return RedirectToAction("Index", "Ecosistema");
            }
            catch (EcosistemaException e)
            {
                ViewBag.msg = e.Message;
                ViewBag.idEcosistema = idEco;
                return View(getAllEspecies.obtenerTodasLasEspecies());
            }
            catch (Exception e)
            {
                ViewBag.idEcosistema = idEco;
                ViewBag.msg = e.Message;
                return View(getAllEspecies.obtenerTodasLasEspecies());
            }
        }


        public ActionResult MostrarEspecies(int idEco)
        {
            return View(getEspeciesDeEcosistema.obtenerEspeciesDeEcosistema(idEco));
        }

    }
}
