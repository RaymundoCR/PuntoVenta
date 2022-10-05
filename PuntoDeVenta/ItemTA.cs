using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    public class ItemTA : ItemBase
    {
        //de igual forma heredamos las propiedades de la clase padre ItemBase, agregado sus propiedades, 3 más las que se encuentran
        //en las siguientes lineas
        public string telefono { get; set; }
        public string compañia { get; set; }
        public decimal comision { get; set; }

        //Se requiere un constructor vacio
        public ItemTA()
        {
        }
        //Este constructor nos sirve para heredar las propidades de la clase padre y ademas poder recibir los datos que
        //se le piden al usuario
        public ItemTA(Articulo articulo, decimal cantidad) : base(articulo, cantidad)
        {
            this.telefono = telefono;
            this.compañia = compañia;
            this.comision = comision;
        }

        public override decimal Total()
        {

            return Subtotal() + this.comision;
        }

        public override void imprimir()
        {
            //en este metodo que esta de forma abstracta en la clase base, solo es de impresion, las operaciones ya se hicieron anteriormente
            Console.WriteLine("=================================");
            Console.WriteLine($"{id} {Nombre} {Precio} {Cantidad} " + Subtotal());
            Console.WriteLine($"Numero telefónico: {telefono} \nCompañia: {compañia} \nComision: {comision}");
            Console.WriteLine($"Total: " + Total());
        }

    }
}
