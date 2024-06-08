using System;
using System.Collections.Generic;
using TiendaApp;

namespace TiendaApp
{
		public class Tienda
		{
				private List<Producto> productos = new List<Producto>();
				public decimal DineroCaja { get; private set; }

				public void AgregarProducto(Producto producto)
				{
						productos.Add(producto);
				}

				public void EliminarProducto(Producto producto)
				{
						productos.Remove(producto);
				}

				public void MostrarProductos()
				{
						foreach (var producto in productos)
						{
								Console.WriteLine(producto);
						}
				}

				public Producto SeleccionarProducto(string nombre)
				{
						return productos.Find(p => p.Nombre == nombre);
				}

				public void Cobrar(Carrito carrito, decimal dineroPagado)
				{
						decimal total = carrito.CalcularSubtotal();
						if (dineroPagado < total)
						{
								Console.WriteLine("Dinero insuficiente.");
								return;
						}

						decimal vuelto = dineroPagado - total;
						DineroCaja += total;
						Console.WriteLine($"Vuelto: {vuelto}");
						carrito.VaciarCarrito(); 
				}
		}

}