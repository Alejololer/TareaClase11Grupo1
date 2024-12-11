using System.Collections.Generic;

public class InventarioRepositorio
{
    private readonly List<Producto> productos = new List<Producto>();

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        return productos;
    }

    public Producto BuscarPorNombre(string nombre)
    {
        return productos.Find(p => p.Nombre == nombre);
    }
}
