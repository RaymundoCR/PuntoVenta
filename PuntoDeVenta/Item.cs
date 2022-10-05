using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    //esta clase solo devuelve el subtotal y la cantidad de articulos, heredando las propiedades de la clase padre
    public class Item : ItemBase
    {

        public Item()
        {

        }
        public Item(Articulo articulo, decimal Cantidad) : base(articulo, Cantidad)
        {
        }

        public override void imprimir()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"{id} {Nombre} {Precio} {Cantidad} " + Subtotal());
            Console.WriteLine($"Total: " + Total());
        }
    }
}
