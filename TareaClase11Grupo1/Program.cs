using System;

class Program
{
    static void Main()
    {
        var repositorio = new InventarioRepositorio();
        var servicio = new InventarioServicio(repositorio);

        while (true)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Buscar Producto");
            Console.WriteLine("4. Salir");

            Console.Write("Selecciona una opción: ");
            var opcion = Console.ReadLine();

            if (!new[] { "1", "2", "3", "4" }.Contains(opcion))
            {
                Console.WriteLine("Opción no válida.");
                continue;
            }

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del producto: ");
                    var nombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("El nombre del producto no puede estar vacío.");
                        break;
                    }

                    Console.Write("Precio del producto: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var precio))
                    {
                        Console.WriteLine("El precio ingresado no es válido.");
                        break;
                    }

                    Console.Write("Cantidad: ");
                    if (!int.TryParse(Console.ReadLine(), out var cantidad))
                    {
                        Console.WriteLine("La cantidad ingresada no es válida.");
                        break;
                    }

                    try
                    {
                        servicio.AgregarProducto(nombre, precio, cantidad);
                        Console.WriteLine("Producto agregado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "2":
                    servicio.ListarProductos();
                    break;

                case "3":
                    Console.Write("Nombre del producto a buscar: ");
                    var nombreBusqueda = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombreBusqueda))
                    {
                        Console.WriteLine("El nombre del producto no puede estar vacío.");
                        break;
                    }
                    servicio.BuscarProducto(nombreBusqueda);
                    break;

                case "4":
                    return;
            }
        }
    }
}
