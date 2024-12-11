public class Producto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, decimal precio, int cantidad)
    {
        // Programación defensiva: Validar los parámetros de entrada
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío o ser solo espacios en blanco.", nameof(nombre));
        }

        if (precio < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(precio), "El precio no puede ser negativo.");
        }

        if (cantidad < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad no puede ser negativa.");
        }

        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
}
