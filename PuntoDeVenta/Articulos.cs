using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    //se crea la clase articulo para ir haciendo cambios y peticiones a la misma
    public class Articulo
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public TipoArticulo Tipo { get; set; }
    }
}
