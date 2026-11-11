public class Usuario
{
    
    public int Documento { get; set; }
    public string NombreUsuario { get; set; }
    public string ApellidoUsuario { get; set; }
    public byte Edad { get; set; }
    public bool Activo { get; set; }

    public Usuario ()
    {
        Activo = true ;
    }

    public Usuario (int documento, string nombreUsuario, string apellidoUsuario, byte edad)
    {
        Documento = documento ;
        NombreUsuario = nombreUsuario ;
        ApellidoUsuario = apellidoUsuario ;
        Edad = edad ;
        Activo = true ;
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

        string EstadoUsuario = Activo ? "Sí" : "No" ;

        return $@"
        ========================
        == Detalles Completos ==
        ========================
        Nombre del usuario -> {NombreUsuario} 
        Apellido del usuario -> {ApellidoUsuario}
        Edad -> {Edad}
        Estado Activo -> {EstadoUsuario}
        ";
    }

    public override string ToString()
    {
        return ResumenCorto() ;
    }    

}
