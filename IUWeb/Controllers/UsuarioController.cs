//using EcoMarino.Entidades;
//using EcoMarino.InterfacesRepositorio;
//using EcoMarino.LogicaAplicacion.DTOs;
//using EcoMarino.LogicaAplicacion.InterfacesCU;
//using EcoMarino.ValueObjects;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace IUWeb.Controllers
//{
//    public class UsuarioController : Controller
//    {
//        private HttpClient cliente = new HttpClient();
//        private string uriText = "http://localhost:1234/api/usuarios";

//        private IRegistroUserCU registroUserCU;
//        private IGetTodosLosCambiosCU getTodosLosCambiosCU;
//        private IRepositorioConfiguracion config;

//        public UsuarioController(IRegistroUserCU registroUser, IGetTodosLosCambiosCU getTodosLosCambiosCU,
//            IRepositorioConfiguracion config)
//        {
//            this.registroUserCU = registroUser;
//            this.getTodosLosCambiosCU = getTodosLosCambiosCU;
//            this.config = config;
//        }



//        // GET: UsuarioController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: UsuarioController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: UsuarioController/Create
//        public ActionResult Create()
//        {
//            if (HttpContext.Session.GetString("LogueadoEsAdmin") == "true")
//            {
//                return View();
//            }
//            else
//            {
//                return RedirectToAction("Index", "Home");
//            }
//        }

//        // POST: UsuarioController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(UsuarioDTO unUser)
//        {
//            try
//            {
//                if(unUser != null)
//                {
//                    unUser.passEncriptada = Seguridad.Encriptar(unUser.passNormal);
//                    //unUser.ValidarUsuario();
//                    unUser.fechaIngreso = DateTime.Now;
//                    registroUserCU.RegistrarUsuario(unUser, HttpContext.Session.GetString("LogueadoAlias"));
//                    ViewBag.SuccessMsg = "Usuario creado correctamente.";
//                    return View();
//                }
//                else
//                {
//                    throw new Exception("No se pudo crear el usuario.");
//                }
//            }
//            catch(Exception ex)
//            {
//                ViewBag.ErrorMsg = ex.Message;
//                return View();
//            }
//        }

//        // GET: UsuarioController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: UsuarioController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: UsuarioController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: UsuarioController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        public ActionResult MostrarCambios()
//        {
//            return View(getTodosLosCambiosCU.getAllCambios());
//        }
//    }
//}
