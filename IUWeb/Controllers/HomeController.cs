//using EcoMarino.Entidades;
//using EcoMarino.Exceptions;
//using EcoMarino.LogicaAplicacion.DTOs;
//using EcoMarino.LogicaAplicacion.InterfacesCU;
//using IUWeb.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;

//namespace IUWeb.Controllers
//{
//    public class HomeController : Controller
//    {
//        private HttpClient cliente = new HttpClient();
//        private string uriText = "http://localhost:1234/api/home";

//        private ILoginUserCU loginUsuarioCU;

//        public HomeController(ILoginUserCU loginUsuario)
//        {
//            this.loginUsuarioCU = loginUsuario;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }


//        public IActionResult Login()
//        {
//            return View();
//        }


//        [HttpPost]
//        public IActionResult Login(string Alias, string PassNormal)
//        {
//            try
//            {
//                UsuarioDTO usBuscado = loginUsuarioCU.Login(Alias, PassNormal);
//                if (usBuscado != null)
//                {
//                    HttpContext.Session.SetInt32("LogueadoId", usBuscado.id);
//                    HttpContext.Session.SetString("LogueadoAlias", usBuscado.alias);
//                    if (usBuscado.esAdmin)
//                    {
//                        HttpContext.Session.SetString("LogueadoEsAdmin", "true");
//                    }
//                    else
//                    {
//                        HttpContext.Session.SetString("LogueadoEsAdmin", "false");
//                    }
//                    ViewBag.msg = "Ingreso correcto. Bienvenido " + usBuscado.alias;
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    throw new UsuarioException("Datos incorrectos");
//                }
//            }
//            catch (UsuarioException usEx)
//            {
//                ViewBag.msg = usEx.Message;
//                return View();
//            }
//            catch (Exception e)
//            {
//                ViewBag.msg = "Ocurrió un error inesperado: " + e.Message;
//                return View();
//            }

//        }

//public IActionResult Logout()
//{
//    if (HttpContext.Session.GetInt32("LogueadoId") != null)
//    {
//        HttpContext.Session.Clear();
//    }
//    return RedirectToAction("Index");
//}
//    }
//}