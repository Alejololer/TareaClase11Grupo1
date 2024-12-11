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

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del producto: ");
                    var nombre = Console.ReadLine();

                    Console.Write("Precio del producto: ");
                    var precio = decimal.Parse(Console.ReadLine());

                    Console.Write("Cantidad: ");
                    var cantidad = int.Parse(Console.ReadLine());

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
                    servicio.BuscarProducto(nombreBusqueda);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
