using EcoMarino.Entidades;
using EcoMarino.Exceptions;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.CasosDeUso;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using EcoMarino.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace IUWeb.Controllers
{
    public class EspecieController : Controller
    {
        private HttpClient cliente = new HttpClient();
        private string uriText = "http://localhost:1234/api/especies";

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
        private IRepositorioConfiguracion configRepo;

        #region Inicialización
        public EspecieController(IAsociarEspecieCU asociarEspecie,
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

        // GET: EspecieController
        public ActionResult Index()
        {
            return View(getAllEspecies.obtenerTodasLasEspecies());
        }

        [HttpPost]
        public ActionResult Index(string NombreCientifico, double PesoMinimo, double PesoMaximo, bool UnirFiltros)
        {

            try
            {
                if (!string.IsNullOrEmpty(NombreCientifico) && PesoMinimo == 0 && PesoMinimo == 0 && UnirFiltros == false)
                {
                    return View(obtenerEspeciePorNombre.getEspeciesPorNombre(NombreCientifico));
                }
                else if (PesoMinimo > 0 && PesoMaximo > 0 && string.IsNullOrEmpty(NombreCientifico) && UnirFiltros == false)
                {
                    if (PesoMinimo > PesoMaximo)
                    {
                        double aux = PesoMinimo;
                        PesoMinimo = PesoMaximo;
                        PesoMaximo = aux;
                    }

                    return View(obtenerEspeciesPorPeso.getEspeciesPorRangoPeso(PesoMinimo, PesoMaximo));
                }
                else if (UnirFiltros == true && !string.IsNullOrEmpty(NombreCientifico) && PesoMinimo > 0 && PesoMaximo > 0)
                {
                    if (PesoMinimo > PesoMaximo)
                    {
                        double aux = PesoMinimo;
                        PesoMinimo = PesoMaximo;
                        PesoMaximo = aux;
                    }

                    return View(getEspeciesPorFiltro.getEspeciesPorPesoYNombre(NombreCientifico, PesoMinimo, PesoMaximo));
                }
                else
                {
                    TempData["tempMsg"] = "Ha habido un error, reintente.";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["tempMsg"] = e.Message;
                return View();
            }


        }

        // GET: EspecieController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.primerImagen = getPrimerImagen.obtenerPrimerImagenEsp(id);
            return View(getEspeciePorId.obtenerEspeciePorId(id));
        }

        // GET: EspecieController/Create
        public ActionResult Create()
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
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

        // POST: EspecieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieDTO unaEsp, double peso, double longitud, IFormFile imagen)
        {
            try
            {
                unaEsp.peso = peso;
                unaEsp.longitud = longitud;

                EstadoDTO estado = getEstado.obtenerEstado(unaEsp.nivelConservacion);
                unaEsp.idEstado = estado.id;
                agregarEspecie.AltaEspecie(unaEsp);

                if (GuardarImagen(imagen, unaEsp))
                {
                    string extension = imagen.FileName.Split(".").Last();
                    foreach (EspecieImagenDTO e in unaEsp._imagenes)
                    {                       
                        e.ruta = SetNombreDeImagen(unaEsp.id) + "." + extension;
                        cambiarNombreImagen.CambiarNombreImagenEspecie(unaEsp, HttpContext.Session.GetString("LogueadoAlias"));
                    }
                    unaEsp.estado = estado;
                    ViewBag.msj = "Agregado Correctamente";                    

                    return View();
                }
                else
                {
                    ViewBag.msj = "El ecosistema no pudo ser cargado debido a un problema con la imagen.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.msj = ex.Message;
                return View();
            }
        }


        private string SetNombreDeImagen(int idEsp)
        {
            List<string> rutasEsp = getTodasLasImagenesEsp.obtenerTodasLasRutasEspecie(idEsp);

            // Determina el siguiente número en la serie
            int siguienteNumero = 1;
            if (rutasEsp.Count > 0)
            {
                // Si existen rutas, obtén el número más alto y agrega uno
                int numeroMasAlto = rutasEsp.Select(ruta => int.Parse(ruta.Substring(ruta.IndexOf('_') + 1))).Max();
                siguienteNumero = numeroMasAlto + 1;
            }

            // Formatea el nuevo nombre con el id y el número
            string nuevoNombre = $"{idEsp}_{siguienteNumero:D3}";

            return nuevoNombre;
        }


       
        private bool GuardarImagen(IFormFile imagen, EspecieDTO e)
        {
            if (imagen == null || e == null) return false;
            // SUBIR LA IMAGEN
            //ruta física de wwwroot
            string rutaFisicaWwwRoot = _environment.WebRootPath;

            //Asignacion del nombre que corresponde a la imagen
            string extension = imagen.FileName.Split(".").Last();
            if (extension == "png" || extension == "jpg" || extension == "jpge")
            {
                string nombreImagen = SetNombreDeImagen(e.id) + "." + extension;
                //ruta donde se guardan las fotos de las personas
                string rutaFisicaFoto = Path.Combine
                (rutaFisicaWwwRoot, "img", "especies", nombreImagen);
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

                    EspecieImagenDTO ecoImg = new EspecieImagenDTO();
                    ecoImg.ruta = nombreImagen;
                    ecoImg.idEspecie = e.id;
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


        // GET: EspecieController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.IdEsp = id;
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

        // POST: EspecieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int idEspecie, string? nameCientifico, string? nameCasual, string? nameDesc)
        {
            try
            {
                EspecieDTO espEncontrada = getEspeciePorId.obtenerEspeciePorId(idEspecie);
                if (espEncontrada != null)
                {
                    if (!string.IsNullOrEmpty(nameCientifico))
                    {
                        espEncontrada.nombreCientifico = nameCientifico;
                    }

                    if (!string.IsNullOrEmpty(nameCasual))
                    {
                        espEncontrada.nombre = nameCasual;
                    }

                    if (!string.IsNullOrEmpty(nameDesc))
                    {
                        espEncontrada.descripcion = nameDesc;
                    }

                    editEspecie.editarEspecie(espEncontrada, HttpContext.Session.GetString("LogueadoAlias"));
                    TempData["tempMsg"] = "Se ha editado correctamente.";                    

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("La especie no se encontró.");
                }
            }
            catch(Exception e)
            {
                TempData["tempMsg"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        #region DELETE NO UTILIZADO (No pedido en la letra).
        // GET: EspecieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EspecieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion


        public ActionResult AsociarAmenazas(int idEspecie)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.especieId = idEspecie;
                    return View(getAllAmenazas.obtenerAmenazas());
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
        public ActionResult AsociarAmenazas(int idEspecie, int idAmenaza)
        {
            try
            {
                AmenazaDTO amenaza = getAmenazaPorId.obtenerAmenazaPorId(idAmenaza);
                EspecieDTO especie = getEspeciePorId.obtenerEspeciePorId(idEspecie);
                especie.AgregarAmenaza(amenaza);
                asociarAmenaza.asociarAmenazaEspecie(especie, HttpContext.Session.GetString("LogueadoAlias"));
                TempData["tempMsg"] = "La amenaza se agregó correctamente a " + especie.nombre;                

                return RedirectToAction("Index", "Especie");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return View();
            }

        }

        public ActionResult MostrarAmenazas(int idEspecie)
        {
            return View(getAmenazasDeEspecie.obtenerAmenazasSegunIdEspecie(idEspecie));
        }

        public ActionResult MostrarEcosistemas(int idEspecie)
        {
            return View(getEcosistemasDeLaEspecie.getEcosSegunEspecie(idEspecie));
        }

        public ActionResult AgregarEcosistemaHabitable(int idEspecie)
        {
            try
            {
                if (HttpContext.Session.GetInt32("LogueadoId") != null)
                {
                    ViewBag.idEspecie = idEspecie;
                    return View(getTodosLosEcos.GetEcosistemas());
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
        public ActionResult AgregarEcosistemaHabitable(int idEspecie, int idEcosistema)
        {
            try
            {
                EcosistemaDTO ecoEncontrado = getEcoPorId.GetEcoPorId(idEcosistema);
                EspecieDTO espEncontrada = getEspeciePorId.obtenerEspeciePorId(idEspecie);
                if (ecoEncontrado != null && espEncontrada != null)
                {
                    espEncontrada.AgregarEcosistemaNoHabita(ecoEncontrado);
                    addEcoHabitable.agregarEcosistemaHabitable(espEncontrada, HttpContext.Session.GetString("LogueadoAlias"));
                    TempData["tempMsg"] = "Ecosistema agregado correctamente.";                    

                    return RedirectToAction("Index", "Especie");
                }
                else
                {
                    throw new Exception("Algo salio mal...");
                }
            }
            catch(DbUpdateException ex)
            {
                ViewBag.idEspecie = idEspecie;
                ViewBag.Msg = ex.Message;
                return View(getTodosLosEcos.GetEcosistemas());
            }
            catch (Exception e)
            {
                ViewBag.idEspecie = idEspecie;
                ViewBag.Msg = e.Message;
                return View(getTodosLosEcos.GetEcosistemas());
            }
        }


        public ActionResult MostrarEcosistemasHabitables(int idEspecie)
        {
            return View(getEcosHabitables.getEcosHabitables(idEspecie));
        }


        public ActionResult MostrarEcosistemasInadecuados(int idEspecie)
        {
            EspecieDTO unaEsp = getEspeciePorId.obtenerEspeciePorId(idEspecie);
            return View(getInadecuados.ObtenerEcosInhabitables(unaEsp));
        }


        public ActionResult MostrarEspeciesEnPeligro()
        {
            try
            {
                return View(getEspeciesEnPeligro.ObtenerEspeciesEnPeligro());
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
                return View();
            }
        }

        public ActionResult ListarEspeciesDeUnEco()
        {
            ViewBag.ecosistemas = getTodosLosEcos.GetEcosistemas();
            return View(getAllEspecies.obtenerTodasLasEspecies());
        }

        [HttpPost]
        public ActionResult ListarEspeciesDeUnEco(int ecosistemaId)
        {
            ViewBag.ecosistemas = getTodosLosEcos.GetEcosistemas();
            return View(obtenerEspeciesDeEcosistema.GetEspeciesDeEco(ecosistemaId));
        }
    }
}
