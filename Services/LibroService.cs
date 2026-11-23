public class LibroService
{
    private List<Libro> libros = new List<Libro>();
    private int siguienteId = 1;

    // Operaciones básicas
    public bool AgregarLibro(Libro libro)
    {
        if (BuscarPorIsbn(libro.Isbn) != null) return false; // ISBN repetido
        libro.Id = siguienteId++;
        libros.Add(libro);
        return true;
    }

    public bool EliminarLibro(string isbn)
    {
        var libro = BuscarPorIsbn(isbn);
        return libro != null && libros.Remove(libro);
    }

    public List<Libro> ObtenerTodos() => libros.ToList();
    public List<Libro> ObtenerDisponibles() => libros.Where(l => l.Disponible).ToList();
    public List<Libro> ObtenerPrestados() => libros.Where(l => !l.Disponible).ToList();

    // Búsquedas
    public Libro? BuscarPorIsbn(string isbn) => libros.FirstOrDefault(l => l.Isbn == isbn);
    public Libro? BuscarPorId(int id) => libros.FirstOrDefault(l => l.Id == id);

    public List<Libro> BuscarPorTitulo(string titulo) =>
        libros.Where(l => l.NombreLibro.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<Libro> BuscarPorAutor(string autor) =>
        libros.Where(l => l.NombreAutor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<Libro> BuscarPorCategoria(string categoria) =>
        libros.Where(l => l.Categoria.Contains(categoria, StringComparison.OrdinalIgnoreCase)).ToList();

    // Ordenación
    public List<Libro> OrdenarPorTitulo() => libros.OrderBy(l => l.NombreLibro).ToList();
    public List<Libro> OrdenarPorAnio() => libros.OrderBy(l => l.Anio).ToList();

    // KPIs
    public int TotalLibros() => libros.Count;
    public int LibrosDisponibles() => libros.Count(l => l.Disponible);
    public int LibrosPrestados() => libros.Count(l => !l.Disponible);

    public void Reiniciar()
    {
        libros.Clear();
        siguienteId = 1;
    }
}