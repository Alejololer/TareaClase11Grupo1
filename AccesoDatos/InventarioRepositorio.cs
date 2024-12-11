using System.Collections.Generic;
using System.Diagnostics;

// Definir la clase InventarioRepositorio
public class InventarioRepositorio
{
    // Declarar una lista privada de productos
    private readonly List<Producto> productos = new List<Producto>();

    // Método para agregar un producto a la lista
    public void AgregarProducto(Producto producto)
    {
        // Programación defensiva: Verificar que el producto no sea nulo
        if (producto == null)
        {
            throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
        }

        // Programación defensiva: Verificar que el nombre del producto no esté vacío
        if (string.IsNullOrWhiteSpace(producto.Nombre))
        {
            throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(producto));
        }

        // Agregar el producto a la lista
        productos.Add(producto);

        // Aserción: Verificar que el producto fue agregado
        Debug.Assert(productos.Contains(producto), "El producto debería haber sido agregado a la lista.");
    }

    // Método para obtener todos los productos de la lista
    public List<Producto> ObtenerTodos()
    {
        // Diseño por contrato: Garantizar que se devuelve una lista (nunca nula)
        Debug.Assert(productos != null, "La lista de productos no debería ser nula.");
        return productos;
    }

    // Método para buscar un producto por su nombre
    public Producto BuscarPorNombre(string nombre)
    {
        // Programación defensiva: Verificar que el nombre no sea nulo o vacío
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
        }

        // Buscar y devolver el producto que coincida con el nombre
        Producto producto = productos.Find(p => p.Nombre == nombre);

        // Diseño por contrato: Garantizar que se devuelve un producto o nulo si no se encuentra
        Debug.Assert(producto == null || producto.Nombre == nombre, "El producto devuelto debería coincidir con el nombre buscado.");
        return producto;
    }
}
