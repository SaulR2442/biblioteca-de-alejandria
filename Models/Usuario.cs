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

    public string ResumenCorto()
    {
        return $@"
        ===================
        == Resumen Corto ==
        ===================
        Nombre del usuario -> {NombreUsuario} 
        Apellido del usuario -> {ApellidoUsuario}
        ";
    }

    public string DetalleCompleto()
    {

        string EstadoUsuario = Activo ? "Si" : "No" ;

        return $@"
        ========================
        == Detalles Completos ==
        ========================
        Nombre del usuario -> {NombreUsuario} 
        Apellido del usuario -> {ApellidoUsuario}
        Edad -> {Edad}
        ";
    }

    public override string ToString() => ResumenCorto();
}
