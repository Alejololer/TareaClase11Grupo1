using System.Collections.Generic;

public class InventarioRepositorio
{
    private readonly List<Producto> productos = new List<Producto>();

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

        productos.Add(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        return productos;
    }

    public Producto BuscarPorNombre(string nombre)
    {
        // Verificar que el nombre no sea nulo o vacío
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
        }

        return productos.Find(p => p.Nombre == nombre);
    }
}
