# Biblioteca de Alejandría

Este proyecto es una aplicación de consola en C# que implementa la estructura de navegación y las funcionalidades básicas de gestión para una biblioteca.

### Resumen del Estado Actual

#### Funcionalidades implementadas:
*   **Menú Principal**: Interfaz de navegación para acceder a los distintos módulos.
*   **Módulo de Libros**:
    *   Registro de libros.
    *   Listado de libros (todos, disponibles, prestados).
    *   Visualización de detalles.
    *   Actualización de información (título, autor, año/categoría).
    *   Eliminación de libros.
*   **Módulo de Usuarios**:
    *   Registro de usuarios.
    *   Listado de usuarios.
    *   Visualización de detalles.
    *   Actualización de información (nombre, teléfono, edad).
    *   Eliminación de usuarios.

#### Características técnicas:
*   Uso de estructuras `do-while` y `switch-case` para la navegación por menús.
*   Implementación de validación básica de entradas del usuario utilizando `TryParse`.
*   Interfaz basada completamente en consola (`Console.WriteLine`).
*   **Nota**: Actualmente, el sistema no cuenta con persistencia de datos; todas las operaciones son simuladas y los datos se manejan únicamente de forma temporal durante la ejecución.
