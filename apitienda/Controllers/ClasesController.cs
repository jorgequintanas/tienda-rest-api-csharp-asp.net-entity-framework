using apitienda.Data;
using apitienda.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace apitienda.Controllers
{
    [Route("api/Clases")]
    public class ClasesController : ApiController
    {
        tiendaEntities tienda = new tiendaEntities();

        [HttpGet]
        public IHttpActionResult ObtenerClasesPorIdDepartamento(int idDepartamento)
        {
            Response<List<clases>> respuesta = new Response<List<clases>>();

            try
            {
                List<clases> listaClases = tienda.clases.Where(c => c.id_departamento == idDepartamento).ToList();
                
                if (listaClases != null)
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "";
                    string data = JsonConvert.SerializeObject(listaClases, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    respuesta.Data = JsonConvert.DeserializeObject<List<clases>>(data);
                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Mensaje = "No existen clases registradas para el departamento seleccionado";
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
