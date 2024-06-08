using System;

namespace TiendaApp
{
    public class Program
    {
        public static void Main()
        {
            Tienda tienda = new Tienda();
            Carrito carrito = new Carrito();

            while (true)
            {
                Console.WriteLine("\n1. Agregar producto a la tienda");
                Console.WriteLine("2. Eliminar producto de la tienda");
                Console.WriteLine("3. Mostrar productos de la tienda");
                Console.WriteLine("4. Agregar producto al carrito");
                Console.WriteLine("5. Eliminar producto del carrito");
                Console.WriteLine("6. Mostrar carrito");
                Console.WriteLine("7. Cobrar");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del producto: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Costo del producto: ");
                        decimal costo = decimal.Parse(Console.ReadLine());
                        Console.Write("Stock del producto: ");
                        int stock = int.Parse(Console.ReadLine());
                        Producto producto = new Producto(nombre, (int)costo, stock);
                        tienda.AgregarProducto(producto);
                        break;
                    case "2":
                        Console.Write("Nombre del producto a eliminar: ");
                        nombre = Console.ReadLine();
                        producto = tienda.SeleccionarProducto(nombre);
                        if (producto != null)
                        {
                            tienda.EliminarProducto(producto);
                        }
                        break;
                    case "3":
                        tienda.MostrarProductos();
                        break;
                    case "4":
                        Console.Write("Nombre del producto a agregar al carrito: ");
                        nombre = Console.ReadLine();
                        producto = tienda.SeleccionarProducto(nombre);
                        if (producto != null)
                        {
                            Console.Write("Cantidad: ");
                            int cantidad = int.Parse(Console.ReadLine());
                            carrito.AgregarProducto(producto, cantidad);
                        }
                        break;
                    case "5":
                        Console.Write("Nombre del producto a eliminar del carrito: ");
                        nombre = Console.ReadLine();
                        producto = tienda.SeleccionarProducto(nombre);
                        if (producto != null)
                        {
                            carrito.EliminarProducto(producto);
                        }
                        break;
                    case "6":
                        carrito.MostrarCarrito();
                        break;
                    case "7":
                        Console.Write("Ingrese el dinero con el que paga el cliente: ");
                        decimal dineroPagado = decimal.Parse(Console.ReadLine());
                        tienda.Cobrar(carrito, dineroPagado);
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
