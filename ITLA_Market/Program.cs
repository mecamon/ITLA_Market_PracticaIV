using System;
using System.Collections.Generic;

namespace ITLA_Market
{
    class Program
    {
        public struct productos
        {
            public string prodNombre;
            public int cantProducto;
            public double precioProducto;
        }

        public struct facturas 
        {
            public List<string> prodComprados;
            public List<int> cantComprado;
            public List<double> subTotal;
            public string cliente;
            public double total;

            facturas(List<string> listp, List<int> cant, List<double> sub, string client, double tot ) 
            {
                prodComprados = listp;
                cantComprado = cant;
                subTotal = sub;
                cliente = client;
                total = tot;
            }
        }
        
        

        public static List<facturas> lsFacturas = new List<facturas>(); //Lista de facturas
        public static facturas fc = new facturas(); //Creando instancia para llenar lista de productos

        public static List<productos> lsProductos = new List<productos>(); //Lista de productos
        public static productos pd = new productos(); //Creando instancia para llenar lista de productos

        public static List<string> clientes = new List<string>(); //Listado de clientes



        public static bool select = true;
        public static int op;
        public static string resp;

        static void Main(string[] args)
        {
            while (select)
            {
                menu();
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void agregarProd() 
        {
            Console.WriteLine("Elija el nombre del producto que desea agregar");
            pd.prodNombre = Console.ReadLine();

            Console.WriteLine("Elija la cantidad de productos que desea agregar");
            pd.cantProducto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Elija el precio del producto");
            pd.precioProducto = Convert.ToDouble(Console.ReadLine());

            lsProductos.Add(pd);
        }

        public static void menu() 
        {
            Console.WriteLine("Bienvenido a ITLA Market. Seleccione la opcion deseada:");
            Console.WriteLine(" \n 1- Para agregar productos nuevos\n 2- Para editar producto existente" +
                "\n 3- Para agregar cliente\n 4- Para vender productos\n 5- Para mostrar ventas realizadas\n 6- Para salir");

            op = Convert.ToInt32(Console.ReadLine());

            switch (op) 
            {
                case 1:
                    agregarProd();
                    break;

                case 2:
                    editarProducto();
                    break;

                case 3:
                    agregarCliente();
                    break;

                case 4:
                    venderProductos();
                    break;

                case 6:
                    salir();
                    break;

                default:
                    Console.WriteLine("Seleccione solo entre las opciones dadas");
                    break;
            }
        }

        public static void agregarCliente() 
        {
            Console.WriteLine("Digite el nombre del cliente a agregar");
            clientes.Add(Console.ReadLine());
        }

        public static void editarProducto() 
        {
            Console.WriteLine("Que posicion desea editar:\n ");
            listar();
            op = Convert.ToInt32(Console.ReadLine()) -1;

            Console.WriteLine("Que desea editar");
            Console.WriteLine(" 1- Para editar nombre\n 2- Para editar cantidad\n 3- Para editar precio");
            int op2;
            op2 = Convert.ToInt32(Console.ReadLine());

            switch (op2) 
            {
                case 1:
                    editarNombre(op);
                    break;

                case 2:
                    editarCantidad(op);
                    break;

                case 3:
                    editarPrecio(op);
                    break;

                default:
                    Console.WriteLine("Seleccion solo entre las opciones dadas");
                    break;
            }
        }

        public static void borraProducto() 
        {
            Console.WriteLine("Producto desea editar");
            listar();
            op = Convert.ToInt32(Console.ReadLine()) - 1;

            lsProductos.RemoveAt(op);
            Console.WriteLine("Producto borrado exitosamente");

        }

        public static void listar() 
        {
            foreach (productos item in lsProductos)
            {
                int counter = 1;
                Console.WriteLine("Posicion " + counter);
                Console.WriteLine("Nombre: " + item.prodNombre);
                Console.WriteLine("Cantidad: " + item.cantProducto);
                Console.WriteLine("Precio: " + item.precioProducto);
                counter++;
                Console.WriteLine("");
            }
        }

        public static void venderProductos() 
        {
            double total = 0;
            List<string> productos = new List<string>();
            List<int> cantidades = new List<int>();
            List<double> subtotales = new List<double>();
            Console.WriteLine("Introduzca el nombre del cliente al que desea vender");
            string nombre = Console.ReadLine();
            buscarCliente(nombre);
            Console.WriteLine("Lista de productos disponibles.");
            listar();
            Console.WriteLine("");
            buscandoProductos(productos, cantidades, subtotales);
            fc.cliente = nombre;
            fc.cantComprado = cantidades;
            fc.prodComprados = productos;
            fc.subTotal = subtotales;
            foreach (double item in subtotales) 
            {
                total += item;
            }
            fc.total = total;

            lsFacturas.Add(fc);
        }

        public static void listarVenta() 
        {

        }


        public static void agregarClienteAFactura() 
        {

        }

        //public static void agregandoAFactura(List<string> compra, List<double> sub, string client, List<int> cant ) 
        //{
        //    double total = 0;
        //    foreach (double item in sub)
        //    {
        //        total += item;
        //    }

        //    facturas fc = new facturas();
        //    fc.prodComprados = compra;
        //    fc.subTotal = sub;
        //    fc.cliente = client;
        //    fc.cantComprado = cant;
        //    fc.total = total;
        //}
        public static void buscandoProductos(List<string> products, List<int> cant, List<double> subT)
        {
            do {
                Console.WriteLine("Ingrese el nombre del producto que desea vender");
                string producto = Console.ReadLine();
                foreach (productos item in lsProductos)
                {
                    if (item.prodNombre == producto)
                    {

                        Console.WriteLine("Que cantidad del producto desea vender");
                        int cantidad = Convert.ToInt32(Console.ReadLine());

                        if (cantidad > item.cantProducto)
                        {
                            Console.WriteLine("No hay esa cantidad de ese producto.\n" +
                                "La cantidad disponibles es {0}", item.cantProducto);
                        }
                        else
                        {
                            pd.cantProducto -= cantidad;
                            lsProductos[lsProductos.IndexOf(item)] = pd;
                            products.Add(item.prodNombre);
                            cant.Add(cantidad);
                            subT.Add(cantidad * item.precioProducto);
                            break;
                        }
                    }
                    
                }
                Console.WriteLine("Quieres seleccionar otro producto Y/N");
                resp = Console.ReadLine();
            } while (resp == "Y");
        }

        public static void buscarCliente(string nombre) //Verifica si esta el cliente y lo agrega a la factura
        {
            foreach (string item in clientes) 
            {
                if (item == nombre) 
                {
                    Console.WriteLine("Cliente disponible.\nSeleccione productos que sea vender y la cantidad.\n");
                    fc.cliente = nombre;
                    lsFacturas.Add(fc);
                }
            }
        }

        public static void editarNombre(int pos) 
        {
            Console.WriteLine("Introduzca el nuevo nombre del producto");
            pd.prodNombre = Console.ReadLine();

            lsProductos[pos] = pd;
        }

        public static void editarCantidad(int pos)
        {
            Console.WriteLine("Introduzca el nuevo nombre del producto");
            pd.cantProducto = Convert.ToInt32(Console.ReadLine());

            lsProductos[pos] = pd;
        }

        public static void editarPrecio(int pos)
        {
            Console.WriteLine("Introduzca el nuevo precio del producto");
            pd.precioProducto = Convert.ToDouble(Console.ReadLine());

            lsProductos[pos] = pd;
        }

        public static void salir() 
        {
            select = false;
            Console.WriteLine("Gracias por usar ITLA Market. Presione cualquier tecla.");
        }
    }
}
