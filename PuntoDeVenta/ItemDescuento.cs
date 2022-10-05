using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    //En esta case se procesaran los articulos con tipo 2, en donde recibimos el descuento y ImpDescuento
    //adiccional a las de la clase padre llamada ItemBase, ya no se agregan las propiedades que ya contiene la clase padre
    //aqui se hacen las operaciones he incluso los calculos desde el get el metodo total y imprimir se sobreescribe de la clase
    //padre entonces ahi estamos aplicando el polimorfismo
    public class ItemDescuento : ItemBase
    {
        public decimal Descuento { get; set; }
        public decimal ImpDescuento { get { return Subtotal() * Descuento / 100; } }
        public ItemDescuento()
        {
        }

        public ItemDescuento(Articulo articulo, decimal cantidad) : base(articulo, cantidad)
        {
            this.Descuento = Descuento;
        }

        public override decimal Total()
        {

            return Subtotal() - ImpDescuento;
        }

        public override void imprimir()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"{id} {Nombre} {Precio} {Cantidad} " + Subtotal());
            Console.WriteLine($"Descuento: {ImpDescuento} {Descuento}%");
            Console.WriteLine($"Total: " + Total());
        }

    }
}
