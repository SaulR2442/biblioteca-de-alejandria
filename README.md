# Biblioteca de Alejandría

Aplicación de consola en **C# (.NET 8)** para gestionar una biblioteca. El proyecto evolucionó desde un menú simulado (EV06) a un modelo con POO (EV07) y una capa de servicios con colecciones dinámicas `List<T>` (EV08).

## Estructura del proyecto

```text
/Models
  Libro.cs
  Usuario.cs
  Prestamo.cs
  EstadoPrestamo.cs
/Services
  LibroService.cs
  UsuarioService.cs
  PrestamoService.cs
Program.cs
```

## Funcionalidades

- **Menú principal**: navegación entre módulos, validación básica de entrada y salida con confirmación.
- **Libros**: registrar, listar (todos/disponibles/prestados), detalle por ISBN, actualizar, eliminar. No permite eliminar un libro prestado.
- **Usuarios**: registrar, listar/ordenar por nombre, detalle por documento, actualizar, activar/desactivar, eliminar. No permite eliminar usuarios con préstamos activos.
- **Préstamos**: crear con validaciones (usuario activo, libro disponible, límite de préstamos), listar/ordenar por fecha límite, detalle por ID, registrar devolución, eliminar préstamos cerrados.
- **Búsquedas y reportes**: búsqueda de libros por título/autor/ISBN/categoría; usuarios por nombre/documento; reportes por usuario/libro, vencidos y resumen general.
- **KPIs**: total de libros/disponibles/prestados, usuarios activos/inactivos, préstamos activos/vencidos/devueltos y promedio de días de préstamo.
- **Comparación Array vs List**: demo en consola desde el menú Reportes/KPIs.
- **Datos de prueba**: `SeedData()` carga datos iniciales al iniciar para probar búsquedas, ordenaciones y KPIs.

## Modelos (POO)

- `Libro`: ISBN, autor, título, categoría, año, disponibilidad; `ResumenCorto()`, `DetalleCompleto()`, `Linea()`.
- `Usuario`: documento, nombre, apellido, edad, teléfono, activo; `ResumenCorto()`, `DetalleCompleto()`, `Linea()`.
- `Prestamo`: libro, usuario, fechas, estado; `EstaVencido()`, `DiasTranscurridos()`, `ActualizarEstado()`.
- `EstadoPrestamo`: `Activo`, `Devuelto`, `Vencido`.

## Servicios (List<T>)

Cada servicio encapsula su `List<T>` y la lógica de negocio:

- `LibroService`: agregar, eliminar, obtener, buscar por ISBN/título/autor/categoría, ordenar por título/año, KPIs.
- `UsuarioService`: agregar, eliminar, cambiar estado, buscar por documento/nombre, ordenar por nombre, KPIs.
- `PrestamoService`: validar/registrar/devolver/eliminar, buscar por ID/estado/usuario/libro, ordenar por fecha límite, KPIs.

## Ejecución

```bash
dotnet build
dotnet run
```

## Git Flow

El desarrollo se gestiona con ramas `feature/*`, integración en `develop` y cierre en `main`. Los commits usan mensajes claros (`feat:`, `fix:`, `docs:`, `merge:`).
