public class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaLimite { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    public Prestamo()
    {
        Libro = new Libro();
        Usuario = new Usuario();
        FechaPrestamo = DateTime.Now;
        FechaLimite = DateTime.Now.AddDays(7);
        Estado = EstadoPrestamo.Activo;
    }

    public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo, int diasPrestamo = 7)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaLimite = fechaPrestamo.AddDays(diasPrestamo);
        Estado = EstadoPrestamo.Activo;
    }

    public bool EstaVencido() => !FechaDevolucion.HasValue && DateTime.Now > FechaLimite;

    public int DiasTranscurridos() => (int)((FechaDevolucion ?? DateTime.Now) - FechaPrestamo).TotalDays;

    public void ActualizarEstado()
    {
        if (FechaDevolucion.HasValue) Estado = EstadoPrestamo.Devuelto;
        else if (EstaVencido()) Estado = EstadoPrestamo.Vencido;
        else Estado = EstadoPrestamo.Activo;
    }

    public string ResumenCorto() => $"Préstamo {Id}: {Libro.NombreLibro} -> {Usuario.NombreCompleto}";

    public string DetalleCompleto() => string.Join(Environment.NewLine,
        $"Id               -> {Id}",
        $"Libro            -> {Libro.NombreLibro}",
        $"Usuario          -> {Usuario.NombreCompleto}",
        $"Fecha préstamo   -> {FechaPrestamo:dd/MM/yyyy}",
        $"Fecha límite     -> {FechaLimite:dd/MM/yyyy}",
        $"Fecha devolución -> {(FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "pendiente")}",
        $"Estado           -> {Estado}",
        $"Días             -> {DiasTranscurridos()}");

    public string Linea() =>
        $"[{Id}] {Libro.NombreLibro} -> {Usuario.NombreCompleto} | Límite {FechaLimite:dd/MM/yyyy} | {Estado}";

    public override string ToString() => ResumenCorto();
}