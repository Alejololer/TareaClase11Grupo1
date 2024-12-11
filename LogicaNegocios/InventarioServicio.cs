using System;
using System.Diagnostics;

public class InventarioServicio
{
    private readonly InventarioRepositorio repositorio;

    public InventarioServicio(InventarioRepositorio repositorio)
    {
        // Validación defensiva para asegurar que el repositorio no sea nulo
        if (repositorio == null) throw new ArgumentNullException(nameof(repositorio));
        this.repositorio = repositorio;
    }

    public void AgregarProducto(string nombre, decimal precio, int cantidad)
    {
        // Validaciones defensivas
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
        if (precio <= 0) throw new ArgumentException("El precio debe ser mayor a cero.");
        if (cantidad < 0) throw new ArgumentException("La cantidad no puede ser negativa.");

        // Precondición
        Debug.Assert(repositorio.BuscarPorNombre(nombre) == null, "El producto ya existe.");

        // Agregar producto
        repositorio.AgregarProducto(new Producto(nombre, precio, cantidad));

        // Postcondición
        Debug.Assert(repositorio.BuscarPorNombre(nombre) != null, "El producto no fue agregado correctamente.");
    }

    public void ListarProductos()
    {
        // Validación defensiva para asegurar que el repositorio no sea nulo
        if (repositorio == null) throw new InvalidOperationException("El repositorio no está inicializado.");

        var productos = repositorio.ObtenerTodos();
        if (productos.Count == 0)
        {
            Console.WriteLine("El inventario está vacío.");
        }
        else
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio:C}, Cantidad: {producto.Cantidad}");
            }
        }
    }

    public void BuscarProducto(string nombre)
    {
        // Validación defensiva para asegurar que el nombre no sea nulo o vacío
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");

        var producto = repositorio.BuscarPorNombre(nombre);
        if (producto == null)
        {
            Console.WriteLine("Producto no encontrado.");
        }
        else
        {
            Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio:C}, Cantidad: {producto.Cantidad}");
        }
    }
}
