public class Usuario
{
    public int Id { get; set; }
    public string Documento { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; }

    public string NombreCompleto => $"{Nombre} {Apellido}";

    public Usuario()
    {
        Documento = Nombre = Apellido = Telefono = string.Empty;
        Activo = true;
    }

    public Usuario(string documento, string nombre, string apellido, int edad, string telefono)
    {
        Documento = documento;
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Telefono = telefono;
        Activo = true;
    }

    public string ResumenCorto() => $"Usuario: {NombreCompleto} | Doc: {Documento}";

    public string DetalleCompleto() => string.Join(Environment.NewLine,
        $"Id         -> {Id}",
        $"Documento  -> {Documento}",
        $"Nombre     -> {NombreCompleto}",
        $"Edad       -> {Edad}",
        $"Telefono   -> {Telefono}",
        $"Activo     -> {(Activo ? "Sí" : "No")}");

    public string Linea() =>
        $"[{Id}] {NombreCompleto} | Doc {Documento} | Tel {Telefono} | {(Activo ? "Activo" : "Inactivo")}";

    public override string ToString() => ResumenCorto();
}