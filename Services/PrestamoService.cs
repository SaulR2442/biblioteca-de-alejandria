public class PrestamoService
{
    private List<Prestamo> prestamos = new List<Prestamo>();
    private int siguienteId = 1;
    private const int MaxPrestamosAbiertos = 3;

    // Devuelve el motivo del rechazo, o null si el préstamo es válido
    public string? ValidarPrestamo(Libro? libro, Usuario? usuario)
    {
        if (usuario == null) return "El usuario no existe.";
        if (!usuario.Activo) return "El usuario está inactivo.";
        if (libro == null) return "El libro no existe.";
        if (!libro.Disponible) return "El libro no está disponible.";
        if (ObtenerPorUsuario(usuario.Documento).Count(p => p.Estado != EstadoPrestamo.Devuelto) >= MaxPrestamosAbiertos)
            return $"El usuario ya tiene {MaxPrestamosAbiertos} préstamos abiertos.";
        return null;
    }

    public Prestamo? RegistrarPrestamo(Libro libro, Usuario usuario, int dias = 7, DateTime? fechaPrestamo = null)
    {
        if (ValidarPrestamo(libro, usuario) != null) return null;

        var prestamo = new Prestamo(siguienteId++, libro, usuario, fechaPrestamo ?? DateTime.Now, dias);
        libro.Disponible = false;
        prestamo.ActualizarEstado();
        prestamos.Add(prestamo);
        return prestamo;
    }

    public bool DevolverPrestamo(int id, DateTime? fechaDevolucion = null)
    {
        var prestamo = BuscarPorId(id);
        if (prestamo == null || prestamo.Estado == EstadoPrestamo.Devuelto) return false;

        prestamo.FechaDevolucion = fechaDevolucion ?? DateTime.Now;
        prestamo.Libro.Disponible = true;
        prestamo.ActualizarEstado();
        return true;
    }

    // Solo se puede eliminar un préstamo cerrado
    public bool EliminarPrestamo(int id)
    {
        var prestamo = BuscarPorId(id);
        if (prestamo == null || prestamo.Estado != EstadoPrestamo.Devuelto) return false;
        return prestamos.Remove(prestamo);
    }

    public List<Prestamo> ObtenerTodos()
    {
        ActualizarEstados();
        return prestamos.ToList();
    }

    // Abiertos = activos + vencidos (todo lo que no se ha devuelto)
    public List<Prestamo> ObtenerAbiertos()
    {
        ActualizarEstados();
        return prestamos.Where(p => p.Estado != EstadoPrestamo.Devuelto).ToList();
    }

    public List<Prestamo> ObtenerCerrados() => BuscarPorEstado(EstadoPrestamo.Devuelto);

    // Búsquedas
    public Prestamo? BuscarPorId(int id)
    {
        var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
        prestamo?.ActualizarEstado();
        return prestamo;
    }

    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        ActualizarEstados();
        return prestamos.Where(p => p.Estado == estado).ToList();
    }

    public List<Prestamo> ObtenerPorUsuario(string documento)
    {
        ActualizarEstados();
        return prestamos.Where(p => p.Usuario.Documento == documento).ToList();
    }

    public List<Prestamo> ObtenerPorLibro(string isbn)
    {
        ActualizarEstados();
        return prestamos.Where(p => p.Libro.Isbn == isbn).ToList();
    }

    public bool TienePrestamosAbiertos(Usuario usuario) =>
        ObtenerPorUsuario(usuario.Documento).Any(p => p.Estado != EstadoPrestamo.Devuelto);

    // Ordenación
    public List<Prestamo> OrdenarPorFechaLimite()
    {
        ActualizarEstados();
        return prestamos.OrderBy(p => p.FechaLimite).ToList();
    }

    // KPIs
    public int TotalPrestamos() => prestamos.Count;
    public int PrestamosActivos() => BuscarPorEstado(EstadoPrestamo.Activo).Count;
    public int PrestamosVencidos() => BuscarPorEstado(EstadoPrestamo.Vencido).Count;
    public int PrestamosDevueltos() => BuscarPorEstado(EstadoPrestamo.Devuelto).Count;

    public double PromedioDiasPrestamo()
    {
        var devueltos = prestamos.Where(p => p.FechaDevolucion.HasValue).ToList();
        return devueltos.Count == 0 ? 0 : devueltos.Average(p => (p.FechaDevolucion!.Value - p.FechaPrestamo).TotalDays);
    }

    public void Reiniciar()
    {
        prestamos.Clear();
        siguienteId = 1;
    }

    private void ActualizarEstados()
    {
        foreach (var p in prestamos) p.ActualizarEstado();
    }
}