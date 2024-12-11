using System;
using System.Diagnostics;

// Definir la clase InventarioServicio
public class InventarioServicio
{
    // Declarar una variable privada de solo lectura para el repositorio
    private readonly InventarioRepositorio repositorio;

    // Constructor de la clase InventarioServicio
    public InventarioServicio(InventarioRepositorio repositorio)
    {
        // Validación defensiva para asegurar que el repositorio no sea nulo
        if (repositorio == null) throw new ArgumentNullException(nameof(repositorio));
        this.repositorio = repositorio;
    }

    // Método para agregar un producto al inventario
    public void AgregarProducto(string nombre, decimal precio, int cantidad)
    {
        // Validaciones defensivas
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
        if (precio <= 0) throw new ArgumentException("El precio debe ser mayor a cero.");
        if (cantidad < 0) throw new ArgumentException("La cantidad no puede ser negativa.");

        // Precondición: asegurar que el producto no exista ya en el repositorio
        Debug.Assert(repositorio.BuscarPorNombre(nombre) == null, "El producto ya existe.");

        // Agregar producto al repositorio
        repositorio.AgregarProducto(new Producto(nombre, precio, cantidad));

        // Postcondición: asegurar que el producto fue agregado correctamente
        Debug.Assert(repositorio.BuscarPorNombre(nombre) != null, "El producto no fue agregado correctamente.");
    }

    // Método para listar todos los productos del inventario
    public void ListarProductos()
    {
        // Validación defensiva para asegurar que el repositorio no sea nulo
        if (repositorio == null) throw new InvalidOperationException("El repositorio no está inicializado.");

        // Obtener todos los productos del repositorio
        var productos = repositorio.ObtenerTodos();
        if (productos.Count == 0)
        {
            // Si no hay productos, mostrar un mensaje indicando que el inventario está vacío
            Console.WriteLine("El inventario está vacío.");
        }
        else
        {
            // Si hay productos, listarlos en la consola
            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio:C}, Cantidad: {producto.Cantidad}");
            }
        }
    }

    // Método para buscar un producto por su nombre
    public void BuscarProducto(string nombre)
    {
        // Validación defensiva para asegurar que el nombre no sea nulo o vacío
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");

        // Buscar el producto en el repositorio por su nombre
        var producto = repositorio.BuscarPorNombre(nombre);
        if (producto == null)
        {
            // Si el producto no se encuentra, mostrar un mensaje indicando que no fue encontrado
            Console.WriteLine("Producto no encontrado.");
        }
        else
        {
            // Si el producto se encuentra, mostrar sus detalles en la consola
            Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio:C}, Cantidad: {producto.Cantidad}");
        }
    }
}
