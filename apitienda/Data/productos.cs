//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apitienda.Data
{
    using Newtonsoft.Json;
    
    public partial class productos
    {
        public int sku { get; set; }
        public string articulo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int departamento { get; set; }
        public int clase { get; set; }
        public int familia { get; set; }
        public System.DateTime fecha_alta { get; set; }
        public int stock { get; set; }
        public int cantidad { get; set; }
        public bool descontinuado { get; set; }
        public System.DateTime fecha_baja { get; set; }

        [JsonIgnore]
        public virtual clases clases { get; set; }

        
        public virtual departamentos departamentos { get; set; }

        [JsonIgnore]
        public virtual familias familias { get; set; }
    }
}
