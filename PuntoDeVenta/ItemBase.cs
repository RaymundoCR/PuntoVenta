using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PuntoDeVenta
{
    //la clase padre, es abstracta, no se puede inicializar, los metodos virtuales se sobreescriben en las clase hijas
    public abstract class ItemBase
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }

        public ItemBase()
        {
        }
        
        // las propiedades que tendra la clase padre, las cuales heredaran todas las clase hijas
        public ItemBase(Articulo articulo, decimal cantidad)
        {
            this.id = articulo.id;
            this.Nombre = articulo.Nombre;
            this.Precio = articulo.Precio;
            this.Cantidad = cantidad;
        }

        public virtual decimal Subtotal() => Precio * Cantidad;

        public virtual decimal Total() => Precio * Cantidad;

        public abstract void imprimir();

    }

}
