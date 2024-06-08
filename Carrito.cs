using System;
using System.Collections.Generic;
using TiendaApp;

namespace TiendaApp{
		
	public class Carrito
	{
			private List<(Producto, int)> productos = new List<(Producto, int)>();

			public void AgregarProducto(Producto producto, int cantidad)
			{
					if (cantidad <= 0)
					{
							Console.WriteLine("La cantidad debe ser mayor que 0. Ingrese una cantidad válida.");
							return;
					}

					if (producto.Stock < cantidad)
					{
							Console.WriteLine($"No se puede agregar {cantidad} unidades de {producto.Nombre}. Stock insuficiente.");
							return;
					}

					var productoEnCarrito = productos.Find(p => p.Item1 == producto);
					if (productoEnCarrito.Item1 != null)
					{
							if (productoEnCarrito.Item2 + cantidad > producto.Stock)
							{
									Console.WriteLine($"No se puede agregar {cantidad} unidades de {producto.Nombre}. Stock insuficiente.");
									return;
							}
							productoEnCarrito.Item2 += cantidad;
					}
					else
					{
							productos.Add((producto, cantidad));
					}

					producto.Stock -= cantidad;
			}

			public void EliminarProducto(Producto producto)
			{
					var productoEnCarrito = productos.Find(p => p.Item1 == producto);
					if (productoEnCarrito.Item1 != null)
					{
							producto.Stock += productoEnCarrito.Item2; 

							productos.Remove(productoEnCarrito);
					}
			}

			public decimal CalcularSubtotal()
			{
					decimal subtotal = 0;
					foreach (var (producto, cantidad) in productos)
					{
							subtotal += cantidad * (decimal) producto.PrecioVenta;
					}
					return subtotal;
			}

			public void MostrarCarrito()
			{
					foreach (var (producto, cantidad) in productos)
					{
							Console.WriteLine($"{producto.Nombre}: Cantidad {cantidad}");
					}
					Console.WriteLine($"Subtotal: {CalcularSubtotal()}");
			}

			public void VaciarCarrito()
			{
					productos.Clear();
			}

			public List<(Producto, int)> GetProductos()
			{
					return new List<(Producto, int)>(productos);
			}
	}
}