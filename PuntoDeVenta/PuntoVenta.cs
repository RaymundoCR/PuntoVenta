using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PuntoDeVenta
{
    public class PuntoVenta
    {
        //se inicializa la lista de articulos donde se van a almacenar los datos del json Articulos
        public static List<Articulo> _ListaArticulo = new List<Articulo>();
        //se creo otra lista donde se iran guardando las ventas realizadas, en este caso el carrito para alfinalizar mostrar el total vendido
        public static List<ItemBase> _Tiket = new List<ItemBase>();

        public static Articulo Cargar(int id)
        {
            Articulo objArticulo = new Articulo();
            string rutajsonArticulos = @"C:\GitHub\PuntoDeVentaGrupal\PuntoDeVenta\Articulos.json";
            string jsonArticulos = File.ReadAllText(rutajsonArticulos);
            _ListaArticulo = JsonConvert.DeserializeObject<List<Articulo>>(jsonArticulos);

            //var buscarId =
            //    from articulo in _ListaArticulo
            //    where id == articulo.id
            //    select articulo;
            //string serializar = JsonConvert.SerializeObject(buscarId);
            //Articulo articuloSer = JsonConvert.DeserializeObject<Articulo>(serializar);
            //conversion a tipo articulo
            objArticulo = _ListaArticulo.Find(x => x.id == id);

            return objArticulo;
        }

        //muestra y agrega un articulo de tipo Normal 1
        public static void agregarNormal(Articulo articulo, decimal cantidad)
        {
            Item itemNormal = new Item(articulo, cantidad);
            _Tiket.Add(itemNormal);
            itemNormal.imprimir();
        }

        //muestra y agrega un articulo de tipo Descuento 2
        public static void agregarItemDescuento(Articulo articulo, decimal cantidad, decimal descuento)
        {
            ItemDescuento itemDescuento = new ItemDescuento(articulo, cantidad);
            itemDescuento.Descuento = descuento;
            itemDescuento.imprimir();
            _Tiket.Add(itemDescuento);

        }
        //muestra y agrega un articulo de tipo ItemTiempoAire 3
        public static void agregarItemTA(Articulo articulo,decimal cantidad ,string numTel, string compañia, decimal comision)
        {
            ItemTA itemTA = new ItemTA(articulo, cantidad);
            itemTA.telefono = numTel;
            itemTA.compañia = compañia;
            itemTA.comision = comision;
            itemTA.imprimir();
            _Tiket.Add(itemTA);
        }
        //muestra el tiket final
        public static void cerrarCaja()
        {
            decimal total = 0m;
            Console.WriteLine($"Empresa TICH");
            foreach (var line in _Tiket)
            {
                line.imprimir();
                //no imprimi el +=, tambien funciona pero es mejor hacerlo con la operacion landa
                total += line.Total();
            }
            Console.WriteLine($"\nTotal a pagar: {_Tiket.Sum(x => x.Total())}");
            Console.WriteLine("=================================");
        }
        //Aqui esta todo lo que se muestra en consola al inicio del programa, enviando los datos a los metedos
        //asi mismo como mandarlos a traer
        public static void Presentacion()
        {
            string opc;
            do
            {
                Console.WriteLine("Por favor seleccione una opción: \nV.- Iniciar una nueva venta \nT.- Terminar");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc.ToUpper())
                {
                    case "V":
                        try
                        {
                            Articulo obJArticulo = new Articulo();
                            Console.WriteLine("Bienvenido(a)");
                            Console.WriteLine("Ingrese el Id del articulo");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese la cantidad");
                            int cantidad = Convert.ToInt32(Console.ReadLine());
                            Articulo result = Cargar(id);
                            TipoArticulo tipo = result.Tipo;
                            switch (tipo)
                            {
                                case TipoArticulo.normal:
                                    agregarNormal(result, cantidad);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case TipoArticulo.descuento:
                                    Console.WriteLine("Ingrese el descuento");
                                    decimal descuento = Convert.ToDecimal(Console.ReadLine());
                                    agregarItemDescuento(result, cantidad, descuento);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case TipoArticulo.tiempoAire:
                                    Console.WriteLine("Ingrese el numero de telefono");
                                    string numTel = Console.ReadLine();
                                    Console.WriteLine("Compañia");
                                    string compañia = Console.ReadLine();
                                    Console.WriteLine("Comisión");
                                    decimal comision = Convert.ToDecimal(Console.ReadLine());
                                    agregarItemTA(result, cantidad, numTel, compañia, comision);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                default:
                                    break;
                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "T":
                        Console.WriteLine("Usted ha salido de la aplicaión...");
                        cerrarCaja();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, por favor selecciona una opcion del menú");
                        break;
                }

            } while (opc != "T");
        }
    }
}
