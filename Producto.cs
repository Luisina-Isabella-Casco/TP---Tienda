using System;
using TiendaApp;

namespace TiendaApp{

	public class Producto
	{
		public string Nombre { get; set; }
		public int Stock { get; set; }
		private float Costo { get; set; }
		public float PrecioVenta {get; private set; }

		public Producto(string nombre, int stock, float costo)
		{

			if (string.IsNullOrWhiteSpace(nombre))
			{
					Console.WriteLine("El nombre del producto no puede ser vacío. Ingrese un nombre válido.");
					return;
			}

			if (costo <= 0)
			{
					Console.WriteLine("El costo debe ser un valor positivo. Ingrese un costo válido.");
					return;
			}

				Nombre = nombre;
				Stock = stock;
				Costo = costo;
				PrecioVenta = (float) (costo * 1.3);

			}

			public override string ToString()
			{
					return $"{Nombre}: Costo {Costo}, Precio Venta {PrecioVenta}, Stock {Stock}";
			}

		}

		
}