using EcoMarino.Entidades;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IUWeb.Controllers
{
    public class ConfiguracionController : Controller
    {
        private HttpClient cliente = new HttpClient();
        private string uriText = "http://localhost:1234/api/config";

        private IGetConfiguracionesCU getConfiguraciones;
        private IGetConfiguracionPorNombreCU getConfiguracionPorNombre;
        private IEditConfiguracionCU editConfiguracion;

        public ConfiguracionController(IGetConfiguracionesCU getConfiguraciones, IGetConfiguracionPorNombreCU getConfiguracionPorNombre, IEditConfiguracionCU editConfiguracion)
        {
            this.getConfiguraciones = getConfiguraciones;
            this.getConfiguracionPorNombre = getConfiguracionPorNombre;
            this.editConfiguracion = editConfiguracion;
        }



        // GET: ConfiguracionController
        public ActionResult Index()
        {
            return View(getConfiguraciones.ObtenerConfiguraciones());
        }

        // GET: ConfiguracionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConfiguracionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ConfiguracionController/Edit/5
        public ActionResult Edit(string nombreAtributo)
        {
            ViewBag.id = nombreAtributo;
            return View();
        }

        // POST: ConfiguracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Configuracion c, string nombreAtributo)
        {
            try
            {
                

                ConfiguracionDTO configuracion = getConfiguracionPorNombre.obtenerConfigPorNombre(nombreAtributo);
                configuracion.nombreAtributo = nombreAtributo;
                configuracion.topeSuperior = c.TopeSuperior;
                configuracion.topeInferior = c.TopeInferior;

                editConfiguracion.editarConfiguracion(configuracion);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConfiguracionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConfiguracionController/Delete/5
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
    }
}

