class Libro
{
    public int Id { get; set; } 
    public string NombreAutor { get; set; }
    public string NombreLibro { get; set; }
    public bool Disponible { get; set; }

    public Libro(int id, string nombreAutor, string nombreLibro)
    {
        Id = id ;
        NombreAutor = nombreAutor ;
        NombreLibro = nombreLibro ;
        Disponible = true ;
    }

    public string ResumenCorto()
    {
        return $@"
        ===================
        == Resumen Corto ==
        ===================
        Nombre del autor -> {NombreAutor}
        Nombre del libro -> {NombreLibro}
        " ;
    }

    public string DetalleCompleto()
    {
        return $@"
        ========================
        == Detalles Completos ==
        ========================
        Nombre del autor -> {NombreAutor}
        Nombre del libro -> {NombreLibro}
        Id -> {Id}
        Disponible -> {Disponible}
        " ;
    }

    public override string ToString()
    {
        return ResumenCorto() ;
    }


    
}