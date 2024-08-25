using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestCountriesServicesController : ControllerBase
    {
        private HttpClient cliente = new HttpClient();
        private string RestCountriesUri = "https://restcountries.com/v3.1/all";

        //CU Agregar pais.
        private IGetPaisesCU getPaises { get; set; }
        private IAddPaisCU agregarPais { get; set; }

        public RestCountriesServicesController(IGetPaisesCU getP, IAddPaisCU addP)
        {
            this.getPaises = getP;
            this.agregarPais = addP;
        }


        /// <summary>
        /// PRECARGAR LOS PAISES. (Ya vienen en el script)
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult ObtenerPaisesApi()
        {
            Uri uri = new Uri(RestCountriesUri);
            HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);
            Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
            respuesta.Wait();

            if (respuesta.Result.IsSuccessStatusCode)
            {
                Task<string> response = respuesta.Result.Content.ReadAsStringAsync();
                response.Wait();
                List<PaisModel> esp = JsonConvert.DeserializeObject<List<PaisModel>>(response.Result);
                PaisDTO aux = new PaisDTO();
                if (getPaises.ObtenerPaises().Count == 0)
                {
                    foreach (PaisModel pm in esp)
                    {
                        PaisDTO nuevoP = new PaisDTO();
                        nuevoP.codigoAlpha = pm.cca3;
                        nuevoP.nombre = pm.name.common;

                        PaisDTO paiss = agregarPais.addPais(nuevoP);
                    }
                }
                return Created("api/RestCountriesServices", aux);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}

