using System;

class Program
{
    static void Main()
    {
        // Crea una instancia del repositorio de inventario
        var repositorio = new InventarioRepositorio();
        // Crea una instancia del servicio de inventario
        var servicio = new InventarioServicio(repositorio);

        // Bucle infinito para el menú de opciones
        while (true)
        {
            // Muestra las opciones del menú
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Buscar Producto");
            Console.WriteLine("4. Salir");

            // Solicita al usuario que seleccione una opción
            Console.Write("Selecciona una opción: ");
            var opcion = Console.ReadLine();

            // Verifica si la opción ingresada es válida
            if (!new[] { "1", "2", "3", "4" }.Contains(opcion))
            {
                Console.WriteLine("Opción no válida.");
                continue;
            }

            // Ejecuta la acción correspondiente a la opción seleccionada
            switch (opcion)
            {
                case "1":
                    // Solicita el nombre del producto
                    Console.Write("Nombre del producto: ");
                    var nombre = Console.ReadLine();

                    // Verifica si el nombre del producto no está vacío
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("El nombre del producto no puede estar vacío.");
                        break;
                    }

                    // Solicita el precio del producto
                    Console.Write("Precio del producto: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var precio))
                    {
                        Console.WriteLine("El precio ingresado no es válido.");
                        break;
                    }

                    // Solicita la cantidad del producto
                    Console.Write("Cantidad: ");
                    if (!int.TryParse(Console.ReadLine(), out var cantidad))
                    {
                        Console.WriteLine("La cantidad ingresada no es válida.");
                        break;
                    }

                    // Intenta agregar el producto al inventario
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
                    // Lista todos los productos del inventario
                    servicio.ListarProductos();
                    break;

                case "3":
                    // Solicita el nombre del producto a buscar
                    Console.Write("Nombre del producto a buscar: ");
                    var nombreBusqueda = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombreBusqueda))
                    {
                        Console.WriteLine("El nombre del producto no puede estar vacío.");
                        break;
                    }
                    // Busca el producto en el inventario
                    servicio.BuscarProducto(nombreBusqueda);
                    break;

                case "4":
                    // Sale del programa
                    return;
            }
        }
    }
}
