using System.Collections.Generic;

// Definir la clase InventarioRepositorio
public class InventarioRepositorio
{
    // Declarar una lista privada de productos
    private readonly List<Producto> productos = new List<Producto>();

    // Método para agregar un producto a la lista
    public void AgregarProducto(Producto producto)
    {
        // Verificar que el producto no sea nulo
        if (producto == null)
        {
            throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
        }

        // Verificar que el nombre del producto no esté vacío
        if (string.IsNullOrWhiteSpace(producto.Nombre))
        {
            throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(producto));
        }

        // Agregar el producto a la lista
        productos.Add(producto);
    }

    // Método para obtener todos los productos de la lista
    public List<Producto> ObtenerTodos()
    {
        return productos;
    }

    // Método para buscar un producto por su nombre
    public Producto BuscarPorNombre(string nombre)
    {
        // Verificar que el nombre no sea nulo o vacío
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
        }

        // Buscar y devolver el producto que coincida con el nombre
        return productos.Find(p => p.Nombre == nombre);
    }
}
