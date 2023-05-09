using apitienda.Data;
using apitienda.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace apitienda.Controllers
{
    [Route("api/Departamentos")]
    public class DepartamentosController : ApiController
    {
        tiendaEntities tienda = new tiendaEntities();

        [HttpGet]
        public IHttpActionResult ObtenerDepartamentos()
        {
            Response<List<departamentos>> respuesta = new Response<List<departamentos>>();

            try
            {
                List<departamentos> listaDepartamentos = tienda.departamentos.ToList();

                if (listaDepartamentos != null)
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "";
                    string data = JsonConvert.SerializeObject(listaDepartamentos, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    respuesta.Data = JsonConvert.DeserializeObject<List<departamentos>>(data);
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Mensaje = "No existen departamentos registrados";
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
