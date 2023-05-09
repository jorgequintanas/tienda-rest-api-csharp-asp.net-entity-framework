using apitienda.Data;
using apitienda.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Http;

namespace apitienda.Controllers
{
    [Route("api/Productos")]
    public class ProductosController : ApiController
    {
        tiendaEntities tienda = new tiendaEntities();

        [HttpGet]
        public IHttpActionResult ObtenerProducto(int sku)
        {
            Response<productos> respuesta = new Response<productos>();

            try
            {
                productos producto = tienda.productos.Where(p => p.sku == sku).FirstOrDefault();

                if (producto != null)
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "";
                    string data = JsonConvert.SerializeObject(producto, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    respuesta.Data = JsonConvert.DeserializeObject<productos>(data);

                }
                else
                {
                    respuesta.Codigo = -1;
                    respuesta.Mensaje = "No existe el producto con el código sku " + sku.ToString();
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

        [HttpPost]
        public IHttpActionResult GuardarProducto(productos prod)
        {
            Response<productos> respuesta = new Response<productos>();

            try
            {
                using (var dbContextTransaction = tienda.Database.BeginTransaction())
                {
                    productos producto = new productos()
                    {
                        sku = prod.sku,
                        articulo = prod.articulo,
                        marca = prod.marca,
                        modelo = prod.modelo,
                        departamento = prod.departamento,
                        clase = prod.clase,
                        familia = prod.familia,
                        fecha_alta = prod.fecha_alta.Date,
                        stock = prod.stock,
                        cantidad = prod.cantidad,
                        descontinuado = prod.descontinuado,
                        fecha_baja = prod.fecha_baja.Date,
                    };

                    tienda.productos.Add(producto);
                    tienda.SaveChanges();
                    dbContextTransaction.Commit();

                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "";
                    string data = JsonConvert.SerializeObject(prod, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    respuesta.Data = JsonConvert.DeserializeObject<productos>(data);
                }
            }
            catch
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Ocurrió un error al guardar la información";
                respuesta.Data = null;
            }
            return Ok(respuesta);
        }

        [HttpPut]
        public IHttpActionResult ActualizarProducto(productos prod)
        {
            Response<productos> respuesta = new Response<productos>();

            try
            {
                using (var dbContextTransaction = tienda.Database.BeginTransaction())
                {
                    productos producto = tienda.productos.Where(p => p.sku == prod.sku).FirstOrDefault();

                    if (producto != null)
                    {
                        producto.articulo = prod.articulo;
                        producto.marca = prod.marca;
                        producto.modelo = prod.modelo;
                        producto.departamento = prod.departamento;
                        producto.clase = prod.clase;
                        producto.familia = prod.familia;
                        producto.fecha_alta = prod.fecha_alta.Date;
                        producto.stock = prod.stock;
                        producto.cantidad = prod.cantidad;
                        producto.descontinuado = prod.descontinuado;
                        producto.fecha_baja = prod.fecha_baja.Date;
                                                
                        tienda.SaveChanges();
                        dbContextTransaction.Commit();

                        respuesta.Codigo = 0;
                        respuesta.Mensaje = "";
                        string data = JsonConvert.SerializeObject(prod, Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                        respuesta.Data = JsonConvert.DeserializeObject<productos>(data);
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Mensaje = "Ocurrió un error al guardar la información; no se pudo obtener el producto con código sku " + prod.sku.ToString();
                        respuesta.Data = null;
                    }
                }
            }
            catch
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Ocurrió un error al guardar la información";
                respuesta.Data = null;
            }
            return Ok(respuesta);
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int sku)
        {
            Response<productos> respuesta = new Response<productos>();

            try
            {
                using (var dbContextTransaction = tienda.Database.BeginTransaction())
                {
                    productos producto = tienda.productos.Where(p => p.sku == sku).FirstOrDefault();

                    if (producto != null)
                    {
                        tienda.productos.Remove(producto);
                        tienda.SaveChanges();
                        dbContextTransaction.Commit();

                        respuesta.Codigo = 0;
                        respuesta.Mensaje = "";
                        string data = JsonConvert.SerializeObject(producto, Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                        respuesta.Data = JsonConvert.DeserializeObject<productos>(data);
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Mensaje = "Ocurrió un error al eliminar el registro; no se pudo obtener el producto con código sku " + sku.ToString();
                        respuesta.Data = null;
                    }
                }
            }
            catch
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Ocurrió un error al eliminar el registro";
                respuesta.Data = null;
            }
            return Ok(respuesta);
        }
    }
}
