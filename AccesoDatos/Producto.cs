// Definición de la clase Producto
public class Producto
{
    // Propiedad para el nombre del producto
    public string Nombre { get; set; }

    // Propiedad para el precio del producto
    public decimal Precio { get; set; }

    // Propiedad para la cantidad del producto
    public int Cantidad { get; set; }

    // Constructor de la clase Producto
    public Producto(string nombre, decimal precio, int cantidad)
    {
        // Programación defensiva: Validar los parámetros de entrada

        // Validar que el nombre no sea nulo, vacío o solo espacios en blanco
        if (string.IsNullOrWhiteSpace(nombre))
        {
            // Diseño por contrato: Lanzar una excepción si el nombre no cumple con el contrato
            throw new ArgumentException("El nombre no puede estar vacío o ser solo espacios en blanco.", nameof(nombre));
        }

        // Validar que el precio no sea negativo
        if (precio < 0)
        {
            // Diseño por contrato: Lanzar una excepción si el precio no cumple con el contrato
            throw new ArgumentOutOfRangeException(nameof(precio), "El precio no puede ser negativo.");
        }

        // Validar que la cantidad no sea negativa
        if (cantidad < 0)
        {
            // Diseño por contrato: Lanzar una excepción si la cantidad no cumple con el contrato
            throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad no puede ser negativa.");
        }

        // Asignar los valores a las propiedades
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;

        // Aserciones: Verificar que las propiedades se han asignado correctamente
        System.Diagnostics.Debug.Assert(!string.IsNullOrWhiteSpace(Nombre), "El nombre no se ha asignado correctamente.");
        System.Diagnostics.Debug.Assert(Precio >= 0, "El precio no se ha asignado correctamente.");
        System.Diagnostics.Debug.Assert(Cantidad >= 0, "La cantidad no se ha asignado correctamente.");
    }
}
