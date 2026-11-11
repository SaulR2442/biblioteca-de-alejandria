using System;

public class Prestamo
{
    public string NombreApellido { get; set; }
    public string Estado { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public DateTime? FechaDevolucion { get; set; }

    public Prestamo()
    {
        NombreApellido = string.Empty;
        Estado = "Activo";
        FechaDevolucion = null;
    }

    public Prestamo(string nombreApellido, DateTime fechaPrestamo, DateTime fechaVencimiento)
    {
        NombreApellido = nombreApellido;
        FechaPrestamo = fechaPrestamo;
        FechaVencimiento = fechaVencimiento;
        
        Estado = "Activo";
        FechaDevolucion = null;
    }

    public bool EstaVencido()
    {
        return !FechaDevolucion.HasValue && DateTime.Now > FechaVencimiento;
    }

    public int DiasTranscurridos()
    {
        return (DateTime.Now - FechaPrestamo).Days;
    }

    public string ResumenCorto()
    {
        return $"Préstamo de {NombreApellido} | Estado: {Estado}";
    }

    public string DetalleCompleto()
    {
        string devolucionTexto = FechaDevolucion.HasValue
            ? FechaDevolucion.Value.ToString("dd/MM/yyyy")
            : "Pendiente de devolución";

        return $"--- DETALLE DEL PRÉSTAMO ---\n" +
               $"Titular: {NombreApellido}\n" +
               $"Estado: {Estado}\n" +
               $"Fecha de Préstamo: {FechaPrestamo:dd/MM/yyyy}\n" +
               $"Fecha de Vencimiento: {FechaVencimiento:dd/MM/yyyy}\n" +
               $"Fecha de Devolución: {devolucionTexto}\n" +
               $"Días Transcurridos: {DiasTranscurridos()}\n" +
               $"¿Vencido?: {(EstaVencido() ? "Sí" : "No")}";
    }

    public override string ToString()
    {
        return $"{NombreApellido} - {FechaPrestamo:dd/MM/yyyy} ({Estado})";
    }
}