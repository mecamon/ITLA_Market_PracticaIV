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
        }



        public static List<facturas> lsFacturas = new List<facturas>(); //Lista de facturas
        public static facturas fc = new facturas(); //Creando instancia para llenar lista de productos

        public static List<productos> lsProductos = new List<productos>(); //Lista de productos


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

        public static void funcionesClientes ()
        {
            Console.WriteLine("Seleccione la funcion de deseada: ");
            Console.WriteLine(" 1- Para agregar cliente\n 2- Para editar cliente\n 3- Para borrar cliente ");
            int entry = Convert.ToInt32(Console.ReadLine());

            switch (entry) 
            {
                case 1:
                    agregarCliente();
                    break;

                case 2:
                    editarCliente();
                    break;

                case 3:
                    borrarCliente();
                    break;

                default:
                    Console.WriteLine("Elija dentro de las opciones dadas");
                    break;
            }
        }
        public static void listarClientes() 
        {
            Console.WriteLine("Lista de clientes: ");
            foreach (string item in clientes) 
            {
                Console.Write("Posicion " + (clientes.IndexOf(item) + 1) + ": ");
                Console.WriteLine(item);
                Console.WriteLine("");
            }
        }
        public static void editarCliente() 
        {
            listarClientes();
            Console.WriteLine("Seleccione la posicion del cliente que desea editar: ");
            int entry = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Seleccione el nuevo nombre del cliente: ");
            string entryName = Console.ReadLine();
            clientes[entry - 1] = entryName;
        }

        public static void borrarCliente()
        {
            listarClientes();
            Console.WriteLine("Seleccione la posicion del cliente que desea borrar: ");
            int entry = Convert.ToInt32(Console.ReadLine());

            clientes.RemoveAt(entry - 1);

            Console.WriteLine("Cliente borrado exitosamente. Presione cualquier tecla para continuar.");
        }
        public static void agregarProd() 
        {
            productos pd = new productos();
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
                "\n 3- Funciones para clientes \n 4- Para vender productos\n 5- Para listar facturas \n 6- Borrar producto \n 7- Para salir");

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
                    funcionesClientes ();
                    break;

                case 4:
                    venderProductos();
                    break;

                case 5:
                    listarFacturas();
                    break;

                case 6:
                    borraProducto();
                    break;

                case 7:
                    salir();
                    break;

                default:
                    Console.WriteLine("Seleccione solo entre las opciones dadas");
                    break;
            }
        }

        public static void listarFacturas() 
        {
            Console.WriteLine("Ingrese el nombre de cliente para buscar facturas: ");
            string entry = Console.ReadLine();
            string rt = "";

            foreach (facturas item in lsFacturas)
            {
                if (entry == item.cliente)
                {
                    Console.WriteLine("Cliente :" + item.cliente);
                    Console.Write("Productos: ");
                    foreach (string p in item.prodComprados)
                    {
                        Console.Write(p + " ");
                    }
                    Console.Write("\nCantidades: ");
                    foreach (int p in item.cantComprado)
                    {
                        Console.Write("   " + p + "   ");
                    }
                    Console.Write("\nSubtotales: ");
                    foreach (double p in item.subTotal)
                    {
                        Console.Write("   " + p + "   ");
                    }
                    Console.WriteLine("\nTotal :" + item.total);
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Quiere buscar otra factura: 'S' o 'N'");
            rt = Console.ReadLine();

            if (rt == "S") 
            {
                listarFacturas();
            }

        } //Elista la cantidad de facturas hechas con su cliente y montos

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
            Console.WriteLine("Producto desea editar. Inserte posicion:");
            listar();
            op = Convert.ToInt32(Console.ReadLine()) - 1;

            lsProductos.RemoveAt(op);
            Console.WriteLine("Producto borrado exitosamente");

        }

        public static void listar() 
        {
            foreach (productos item in lsProductos)
            {
                Console.WriteLine("Posicion " + (lsProductos.IndexOf(item) + 1));
                Console.WriteLine("Nombre: " + item.prodNombre);
                Console.WriteLine("Cantidad: " + item.cantProducto);
                Console.WriteLine("Precio: " + item.precioProducto);
                Console.WriteLine("");
            }
        } //Elista los productos disponibles.
        public static void venderProductos() 
        {
            int cantidadExtraida = 0;
            int index = 0;
            double total = 0;
            List<string> prodVendido = new List<string>();
            List<int> cantVendida = new List<int>();
            List<double> subTo = new List<double>();
            buscarCliente();
            do
            {
                Console.WriteLine("Que producto desea vender");
                string ventaP = Console.ReadLine();

                foreach (productos instancias in lsProductos)
                {
                    if (ventaP == instancias.prodNombre)
                    {
                        Console.WriteLine("Producto disponible");
                        prodVendido.Add(ventaP);

                        Console.WriteLine("Que cantidad desea vender");
                        int cant = Convert.ToInt32(Console.ReadLine());
                        cantidadExtraida = cant;

                        if (cant <= instancias.cantProducto)
                        {
                            index = lsProductos.IndexOf(instancias);
                            Console.WriteLine("Producto agregado a carrito");
                            cantVendida.Add(cant);
                            subTo.Add(cant * instancias.precioProducto);

                        }
                        else
                        {
                            Console.WriteLine("No hay esa cantidad de ese producto. Hay disponible " + instancias.cantProducto);
                        }

                    }

                }
                productos pd = new productos();

                pd.cantProducto = lsProductos[index].cantProducto - cantidadExtraida;
                pd.prodNombre = lsProductos[index].prodNombre;
                pd.precioProducto = lsProductos[index].precioProducto;

                lsProductos[index] = pd;
                Console.WriteLine("Quiere realizar otra venta 'S' o 'N'");
                resp = Console.ReadLine();
            } while (resp == "S");

            fc.prodComprados = prodVendido;
            fc.cantComprado = cantVendida;
            fc.subTotal = subTo;
            foreach (double item in fc.subTotal)
            {
                total += item;
            }
            fc.total = total;

            lsFacturas.Add(fc);

            Console.WriteLine("\nVenta a cliente " + fc.cliente);
            Console.Write("Productos: ");
            foreach (string item in fc.prodComprados)
            {
                Console.Write(item + "  ");
            }
            Console.Write("\nCantidades: ");
            foreach (int item in fc.cantComprado)
            {
                Console.Write("   " + item + "   ");
            }
            Console.Write("\nSubtotales: ");
            foreach (double item in fc.subTotal)
            {
                Console.Write("   "+ item + "   ");
            }
            Console.WriteLine("\nTotal: " + fc.total);


        }

        public static void buscarCliente() //Verifica si esta el cliente y lo agrega a la factura de la instancia
        {
            Console.WriteLine("A que cliente le desea vender");
            string nombre = Console.ReadLine();

            if (clientes.Contains(nombre))
            {
                fc.cliente = nombre;
            }
            else 
            {
                Console.WriteLine("Cliente no esta en lista");
            }
        }

        public static void editarNombre(int pos) 
        {
            productos pd = new productos();

            Console.WriteLine("Introduzca el nuevo nombre del producto");
            pd.prodNombre = Console.ReadLine();

            pd.precioProducto = lsProductos[pos].precioProducto;
            pd.cantProducto = lsProductos[pos].cantProducto;

            lsProductos[pos] = pd;
        } //Funcion de apoyo para editar nombre en la funcion EditarProducto

        public static void editarCantidad(int pos)
        {
            productos pd = new productos();

            Console.WriteLine("Introduzca la nueva cantidad del producto");
            pd.cantProducto = Convert.ToInt32(Console.ReadLine());

            pd.prodNombre = lsProductos[pos].prodNombre;
            pd.precioProducto = lsProductos[pos].precioProducto;

            lsProductos[pos] = pd;
        }//Funcion de apoyo para editar cantidad en la funcion EditarProducto

        public static void editarPrecio(int pos)
        {
            productos pd = new productos();

            Console.WriteLine("Introduzca el nuevo precio del producto");
            pd.precioProducto = Convert.ToDouble(Console.ReadLine());

            pd.cantProducto = lsProductos[pos].cantProducto;
            pd.prodNombre = lsProductos[pos].prodNombre;

            lsProductos[pos] = pd;
        }//Funcion de apoyo para editar precio en la funcion EditarProducto

        public static void salir() 
        {
            select = false;
            Console.WriteLine("Gracias por usar ITLA Market. Presione cualquier tecla.");
        }
    }
}
