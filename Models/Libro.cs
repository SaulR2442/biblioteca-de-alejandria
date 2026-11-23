public class Libro
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string NombreAutor { get; set; }
    public string NombreLibro { get; set; }
    public string Categoria { get; set; }
    public int Anio { get; set; }
    public bool Disponible { get; set; }

    public Libro()
    {
        Disponible = true ;
    }

    // El Id lo asigna LibroService al agregar
    public Libro(string isbn, string nombreAutor, string nombreLibro, string categoria, int anio)
    {
        Isbn = isbn;
        NombreAutor = nombreAutor;
        NombreLibro = nombreLibro;
        Categoria = categoria;
        Anio = anio;
        Disponible = true;
    }

    public string ResumenCorto() =>
        $"Libro: {NombreLibro} | Autor: {NombreAutor}";

    public string DetalleCompleto() => string.Join(Environment.NewLine,
        $"Id           -> {Id}",
        $"ISBN         -> {Isbn}",
        $"Nombre       -> {NombreLibro}",
        $"Autor        -> {NombreAutor}",
        $"Categoria    -> {Categoria}",
        $"Año          -> {Anio}",
        $"Disponible   -> {(Disponible ? "Sí" : "No")}");

    // Una línea, para listados
    public string Linea() =>
        $"[{Id}] {NombreLibro} – {NombreAutor} ({Anio}) | ISBN {Isbn} | {(Disponible ? "Disponible" : "Prestado")}";

    public override string ToString() => ResumenCorto();
}