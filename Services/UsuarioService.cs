public class UsuarioService
{
    private List<Usuario> usuarios = new List<Usuario>();
    private int siguienteId = 1;

    // Operaciones básicas
    public bool AgregarUsuario(Usuario usuario)
    {
        if (BuscarPorDocumento(usuario.Documento) != null) return false; // documento repetido
        usuario.Id = siguienteId++;
        usuarios.Add(usuario);
        return true;
    }

    public bool EliminarUsuario(string documento)
    {
        var usuario = BuscarPorDocumento(documento);
        return usuario != null && usuarios.Remove(usuario);
    }

    // Eliminación lógica
    public bool CambiarEstado(string documento, bool activo)
    {
        var usuario = BuscarPorDocumento(documento);
        if (usuario == null) return false;
        usuario.Activo = activo;
        return true;
    }

    public List<Usuario> ObtenerTodos() => usuarios.ToList();

    // Búsquedas
    public Usuario? BuscarPorDocumento(string documento) =>
        usuarios.FirstOrDefault(u => u.Documento == documento);

    public Usuario? BuscarPorId(int id) => usuarios.FirstOrDefault(u => u.Id == id);

    public List<Usuario> BuscarPorNombre(string nombre) =>
        usuarios.Where(u => u.NombreCompleto.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

    // Ordenación
    public List<Usuario> OrdenarPorNombre() => usuarios.OrderBy(u => u.NombreCompleto).ToList();

    // KPIs
    public int TotalUsuarios() => usuarios.Count;
    public int UsuariosActivos() => usuarios.Count(u => u.Activo);
    public int UsuariosInactivos() => usuarios.Count(u => !u.Activo);

    public void Reiniciar()
    {
        usuarios.Clear();
        siguienteId = 1;
    }
}