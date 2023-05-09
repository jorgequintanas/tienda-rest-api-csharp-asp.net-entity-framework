using apitienda.Data;
using apitienda.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace apitienda.Controllers
{
    [Route("api/Familias")]
    public class FamiliasController : ApiController
    {
        tiendaEntities tienda = new tiendaEntities();

        [HttpGet]
        public IHttpActionResult ObtenerFamiliasPorIdClase(int idClase)
        {
            Response<List<familias>> respuesta = new Response<List<familias>>();

            try
            {
                List<familias> listaFamilias = tienda.familias.Where(f => f.id_clase == idClase).ToList();

                if (listaFamilias != null)
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "";
                    string data = JsonConvert.SerializeObject(listaFamilias, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    respuesta.Data = JsonConvert.DeserializeObject<List<familias>>(data);
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Mensaje = "No existen familias registradas para la clase seleccionada";
                    respuesta.Data = null;
                }
            }
            catch
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Ocurrió un error al obtener la información";
                respuesta.Data = null;
            }
            return Ok(respuesta);
        }
    }
}
