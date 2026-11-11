# Biblioteca de Alejandría

Este proyecto es una aplicación de consola en C# que implementa la navegación por menús y las funcionalidades básicas de gestión para una biblioteca.

El sistema utiliza Programación Orientada a Objetos (POO) para modelar las entidades del dominio de la biblioteca.

## Resumen del estado actual

### Funcionalidades implementadas

*   **Menú principal**: navegación hacia todos los módulos y opción de salida con confirmación.
*   **Módulo de libros**:
    *   Registro de libros.
    *   Listado de libros (todos, disponibles, prestados).
    *   Visualización de detalles.
    *   Actualización de información (título, autor, año/categoría).
    *   Eliminación de libros.
*   **Módulo de usuarios**:
    *   Registro de usuarios.
    *   Listado de usuarios.
    *   Visualización de detalles.
    *   Actualización de información (nombre, contacto, activar/desactivar).
    *   Eliminación de usuarios.
*   **Módulo de préstamos**:
    *   Creación de préstamos con validaciones simuladas.
    *   Listado de préstamos (todos, activos, cerrados).
    *   Detalle de préstamo por ID.
    *   Registro de devoluciones.
    *   Eliminación de préstamos.
*   **Búsquedas y reportes**:
    *   Búsqueda de libros (título, autor, ID/ISBN, categoría).
    *   Búsqueda de usuarios (nombre, ID/documento).
    *   Reportes por usuario, por libro, de vencidos y resumen general.
*   **Guardar / Cargar datos**:
    *   Guardado simulado de datos.
    *   Carga simulada de datos.
    *   Reinicio de datos con confirmación S/N.
*   **Salida**:
    *   Confirmación para guardar antes de salir (S/N).

### Características técnicas

*   Uso de estructuras `do-while` y `switch-case` para la navegación por menús.
*   Validación básica de entradas del usuario utilizando `TryParse`.
*   Interfaz basada completamente en consola (`Console.WriteLine`).
*   Uso de POO para la definición de entidades en la carpeta `Models`:
    *   `Libro`
    *   `Usuario`
    *   `Prestamo`
    *   `EstadoPrestamo` (enum)
*   El menú principal se invoca al iniciar la aplicación.

## Estructura Git Flow

El desarrollo se organizó con ramas `feature/*` fusionadas a `develop`.

## Nota

Todas las operaciones son simuladas. Los datos no se guardan en disco ni en una base de datos; solo se muestran mensajes por consola durante la ejecución.
