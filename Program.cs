LibroService libroService = new LibroService();
UsuarioService usuarioService = new UsuarioService();
PrestamoService prestamoService = new PrestamoService();

﻿/*
En la rama feature/main-menu-navigation, se creo el menu de navegacion basico
con el do while, una validacion simple con .TryParse y un switch / case donde
se revisa cual caso escogio el usario y se mete al otro sub menu 
*/

void ShowMainMenu()
{
    byte opcionElegidaMenu;

    do
    {
        Console.WriteLine(@"
    ==========================
    ===== Menu Principal =====
    ==========================
    1. Libros
    2. Usuarios
    3. Préstamos
    4. Búsquedas y reportes
    5. Guardar / Cargar datos
    6. Salir
    ==========================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionElegidaMenu))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionElegidaMenu)
        {
            case 1:
                ShowBooksMenu() ;
                break;

            case 2:
                ShowUsersMenu() ;
                break;

            case 3:
                ShowLoansMenu() ;
                break;

            case 4:
                ShowSearchReportsMenu();
                break;

            case 5:
                ShowPersistenceMenu();
                break;

            case 6:
                ConfirmExitAndSave();
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 6");
                break;
        }
    }
    while (opcionElegidaMenu != 6);
}

/*
En la rama feature/books-menu, se hizo lo siguiente:

1.1 Registrar libro

1.2 Listar libros

- 1.2.1 Listar todos
- 1.2.2 Listar disponibles
- 1.2.3 Listar prestados
    
    1.3 Ver detalle de libro (por ID/ISBN)
    
    1.4 Actualizar libro
    
- 1.4.1 Editar título
- 1.4.2 Editar autor
- 1.4.3 Editar año / categoría
    
    1.5 Eliminar libro

Cabe aclarar que sin guardar ningun tipo de dato, en un base de datos; solo los datos se guardan temporalmente.
*/

void ShowBooksMenu()
{
    byte opcionElegidaLibros;

    do
    {
        Console.WriteLine(@"
    ==========================
    ====== Menu Libros =======
    ==========================
    1. Registrar Libro
    2. Listar libros
    3. Ver detalle de libro (por ID/ISBN)
    4. Actualizar libro
    5. Eliminar libro
    6. Salir al menu principal
    ==========================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionElegidaLibros))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionElegidaLibros)
        {
            case 1:
                RegisterBook();
                break;

            case 2:
                ListBooksMenu();
                break;

            case 3:
                ViewBookDetail();
                break;

            case 4:
                UpdateBookMenu();
                break;

            case 5:
                DeleteBook();
                break;

            case 6:
                // Se vuelve al menu principal automaticamente
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 6");
                break;
        }
    }
    while (opcionElegidaLibros != 6);
}

void RegisterBook()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Registrar libros elegida correctamente ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el nombre del libro ->");
    string nombreLibro = Console.ReadLine() ?? "";

    Console.WriteLine("Ingrese el nombre del autor del libro ->");
    string nombreAutorLibro = Console.ReadLine() ?? "";

    Console.WriteLine("Ingrese la categoria del libro ->");
    string categoriaLibro = Console.ReadLine() ?? "";

    Console.WriteLine("Ingrese el año cuando salio el libro ->");
    if (!int.TryParse(Console.ReadLine(), out int añoLibro)) añoLibro = 2024;

    Console.WriteLine("Ingrese el isbn del libro ->");
    string isbnLibro = Console.ReadLine() ?? "";

    Libro nuevoLibro = new Libro(isbnLibro, nombreAutorLibro, nombreLibro, categoriaLibro, añoLibro);

    if (libroService.AgregarLibro(nuevoLibro))
    {
        Console.WriteLine($@"
    ====================================
    === Libro guardado correctamente ===
    ====================================
    Nombre -> {nombreLibro}.
    Autor -> {nombreAutorLibro}.
    Categoria -> {categoriaLibro}.
    Año -> {añoLibro}.
    ISBN -> {isbnLibro}.
    ====================================
    ");
    }
    else
    {
        Console.WriteLine("Error: No se pudo agregar el libro (¿ISBN duplicado?)");
    }
}

void ListBooksMenu()
{
    byte opcionListarLibro;

    Console.WriteLine(@"
    ========================================================
    === Opcion de Listar libros elegida correctamente ===
    ========================================================
    ");

    Console.WriteLine(@"
    =====================================
    == Que desea hacer especificamente ==
    =====================================
    1. Listar todos los libros.
    2. Listar solo los libros disponibles.
    3. Listar libros prestados.
    ");

    while (!byte.TryParse(Console.ReadLine(), out opcionListarLibro))
    {
        Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
    }

    switch (opcionListarLibro)
    {
        case 1:
            ListBooksAll();
            break;

        case 2:
            ListBooksAvailable();
            break;

        case 3:
            ListBooksBorrowed();
            break;

        default:
            Console.WriteLine("Numero ingresado incorrecto, es del uno al 3");
            break;

    }
}

void ListBooksAll()
{
    Console.WriteLine(@"
    ======================
    == Todos los libros ==
    ======================
    ");
    var libros = libroService.ObtenerTodos();
    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros registrados.");
    }
    else
    {
        foreach (var l in libros)
        {
            Console.WriteLine(l.Linea());
        }
    }
}

void ListBooksAvailable()
{
    Console.WriteLine(@"
    ==================================
    == Todos los libros disponibles ==
    ==================================
    ");
    var libros = libroService.ObtenerDisponibles();
    if (libros.Count == 0) Console.WriteLine("No hay libros disponibles.");
    else foreach (var l in libros) Console.WriteLine(l.Linea());
}

void ListBooksBorrowed()
{
    Console.WriteLine(@"
    ================================
    == Todos los libros prestados ==
    ================================
    ");
    var libros = libroService.ObtenerPrestados();
    if (libros.Count == 0) Console.WriteLine("No hay libros prestados.");
    else foreach (var l in libros) Console.WriteLine(l.Linea());
}

void ViewBookDetail()
{
    Console.WriteLine(@"
    =================================================================
    === Opcion de ver detalle de los libros elegida correctamente ===
    =================================================================
    ");
    Console.WriteLine("Ingrese el ISBN del libro ->");
    string isbn = Console.ReadLine() ?? "";
    var libro = libroService.BuscarPorIsbn(isbn);
    if (libro == null)
    {
        Console.WriteLine("Libro no encontrado.");
    }
    else
    {
        Console.WriteLine(libro.DetalleCompleto());
    }
}

void UpdateBookMenu()
{
    byte opcionActualizarLibro;

    Console.WriteLine(@"
    =========================================================
    === Opcion de actualizar libros elegida correctamente ===
    =========================================================
    ");

    Console.WriteLine(@"
    =====================================
    == Que desea hacer especificamente ==
    =====================================
    1. Editar titulo.
    2. Editar autor.
    3. Editar año / categoria.
    ");

    while (!byte.TryParse(Console.ReadLine(), out opcionActualizarLibro))
    {
        Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
    }

    switch (opcionActualizarLibro)
    {
        case 1:
            EditBookTitle();
            break;

        case 2:
            EditBookAuthor();
            break;

        case 3:
            EditBookYearCategory();
            break;

        default:
            Console.WriteLine("Numero ingresado incorrecto, es del uno al 3");
            break;

    }
}

void EditBookTitle()
{
    Console.WriteLine(@"
    ======================================================================
    === Opcion de editar el titulo de los libros elegida correctamente ===
    ======================================================================
    ");
    Console.WriteLine("Ingrese el ISBN del libro a editar ->");
    string isbn = Console.ReadLine() ?? "";
    var libro = libroService.BuscarPorIsbn(isbn);
    if (libro == null) { Console.WriteLine("Libro no encontrado."); return; }

    Console.WriteLine($"Titulo actual: {libro.NombreLibro}");
    Console.WriteLine("Ingrese el nuevo nombre del libro ->");
    string nuevo = Console.ReadLine() ?? "";
    libro.NombreLibro = nuevo;
    Console.WriteLine("Nombre actualizado correctamente.");
}

void EditBookAuthor()
{
    Console.WriteLine(@"
    =====================================================================
    === Opcion de editar el autor de los libros elegida correctamente ===
    =====================================================================
    ");
    Console.WriteLine("Ingrese el ISBN del libro a editar ->");
    string isbn = Console.ReadLine() ?? "";
    var libro = libroService.BuscarPorIsbn(isbn);
    if (libro == null) { Console.WriteLine("Libro no encontrado."); return; }

    Console.WriteLine($"Autor actual: {libro.NombreAutor}");
    Console.WriteLine("Ingrese el nuevo nombre del autor ->");
    libro.NombreAutor = Console.ReadLine() ?? "";
    Console.WriteLine("Autor actualizado correctamente.");
}

void EditBookYearCategory()
{
    Console.WriteLine(@"
    ===============================================================================
    === Opcion de editar el año y categoria de los libros elegida correctamente ===
    ===============================================================================
    ");
    Console.WriteLine("Ingrese el ISBN del libro a editar ->");
    string isbn = Console.ReadLine() ?? "";
    var libro = libroService.BuscarPorIsbn(isbn);
    if (libro == null) { Console.WriteLine("Libro no encontrado."); return; }

    Console.WriteLine($"Categoria actual: {libro.Categoria}. Ingrese nueva categoria ->");
    libro.Categoria = Console.ReadLine() ?? "";
    Console.WriteLine($"Año actual: {libro.Anio}. Ingrese nuevo año ->");
    if (int.TryParse(Console.ReadLine(), out int anio)) libro.Anio = anio;
    Console.WriteLine("Categoria y año actualizados correctamente.");
}

void DeleteBook()
{
    Console.WriteLine(@"
    ===========================================================
    === Opcion de eliminar los libros elegida correctamente ===
    ===========================================================
    ");
    Console.WriteLine("Ingrese el ISBN del libro que desea eliminar ->");
    string isbn = Console.ReadLine() ?? "";
    if (libroService.EliminarLibro(isbn))
        Console.WriteLine("Libro eliminado correctamente.");
    else
        Console.WriteLine("No se pudo eliminar (no encontrado).");
}

/*
En la rama feature/users-menu, se agrego lo siguiente:

2.1Registrar usuario

2.2 Listar usuarios

2.3 Ver detalle de usuario (por ID/documento)

2.4 Actualizar usuario

- 2.4.1 Editar nombre
- 2.4.2 Editar contacto
- 2.4.3 Activar / desactivar
    
    2.5 Eliminar usuario
*/

void ShowUsersMenu()
{
    byte opcionElegidaUsuario;

    do
    {
        Console.WriteLine(@"
    ============================
    ====== Menu usuarios =======
    ============================
    1. Registrar usuario.
    2. Listar usuarios.
    3. Ver detalle de usuario (por ID/documento).
    4. Actualizar usuario.
    5. Eliminar usuario.
    6. Salir al menu principal
    ==========================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionElegidaUsuario))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionElegidaUsuario)
        {
            case 1:
                RegisterUser();
                break;

            case 2:
                ListUsers();
                break;

            case 3:
                ViewUserDetail();
                break;

            case 4:
                UpdateUserMenu();
                break;

            case 5:
                DeleteUser();
                break;

            case 6:
                // Se vuelve al menu principal automaticamente
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 6");
                break;
        }
    }
    while (opcionElegidaUsuario != 6);
}

void RegisterUser()
{
    Console.WriteLine(@"
    =========================================================
    === Opcion de Registrar usuario elegida correctamente ===
    =========================================================
    ");

    Console.WriteLine("Ingrese el nombre del usuario ->");
    string nombreUsuario = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el apellido del usuario ->");
    string apellidoUsuario = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese la edad del usuario ->");
    if (!int.TryParse(Console.ReadLine(), out int edadUsuario)) edadUsuario = 0;
    Console.WriteLine("Ingrese el documento del usuario ->");
    string documentoUsuario = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el telefono del usuario ->");
    string telefonoUsuario = Console.ReadLine() ?? "";

    var usuario = new Usuario(documentoUsuario, nombreUsuario, apellidoUsuario, edadUsuario, telefonoUsuario);
    if (usuarioService.AgregarUsuario(usuario))
    {
        Console.WriteLine($@"
    ========================================
    === Usuario registrado correctamente ===
    ========================================
    Nombre -> {nombreUsuario} {apellidoUsuario}.
    Documento -> {documentoUsuario}.
    ====================================");
    }
    else
    {
        Console.WriteLine("Error: No se pudo registrar (¿documento duplicado?)");
    }
}

void ListUsers()
{
    Console.WriteLine(@"
    ====================================================
    === Opcion listar usuarios elegida correctamente ===
    ====================================================
    ");
    var usuarios = usuarioService.ObtenerTodos();
    if (usuarios.Count == 0) Console.WriteLine("No hay usuarios registrados.");
    else foreach (var u in usuarios) Console.WriteLine(u.Linea());
}

void ViewUserDetail()
{
    Console.WriteLine(@"
    =====================================================================
    === Opcion ver los detalles de los usuarios elegida correctamente ===
    =====================================================================
    ");
    Console.WriteLine("Ingrese el documento del usuario ->");
    string doc = Console.ReadLine() ?? "";
    var usuario = usuarioService.BuscarPorDocumento(doc);
    if (usuario == null) Console.WriteLine("Usuario no encontrado.");
    else Console.WriteLine(usuario.DetalleCompleto());
}

void UpdateUserMenu()
{
    byte opcionActualizarUsuario;

    Console.WriteLine(@"
    ==========================================================
    === Opcion de actualizar usuario elegida correctamente ===
    ==========================================================
    ");

    Console.WriteLine(@"
    =====================================
    == Que desea hacer especificamente ==
    =====================================
    1. Editar nombre.
    2. Editar telefono.
    3. Activar / desactivar.
    ");

    while (!byte.TryParse(Console.ReadLine(), out opcionActualizarUsuario))
    {
        Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
    }

    switch (opcionActualizarUsuario)
    {
        case 1:
            EditUserName();
            break;

        case 2:
            EditUserContact();
            break;

        case 3:
            ToggleUserActiveStatus();
            break;

        default:
            Console.WriteLine("Numero ingresado incorrecto, es del uno al 3");
            break;

    }
}

void EditUserName()
{
    Console.WriteLine(@"
    =====================================================================
    === Opcion de editar el nombre del usuario elegida correctamente  ===
    =====================================================================
    ");
    Console.WriteLine("Ingrese el documento del usuario ->");
    string doc = Console.ReadLine() ?? "";
    var usuario = usuarioService.BuscarPorDocumento(doc);
    if (usuario == null) { Console.WriteLine("Usuario no encontrado."); return; }

    Console.WriteLine($"Nombre actual: {usuario.Nombre}. Nuevo nombre ->");
    usuario.Nombre = Console.ReadLine() ?? "";
    Console.WriteLine($"Apellido actual: {usuario.Apellido}. Nuevo apellido ->");
    usuario.Apellido = Console.ReadLine() ?? "";
    Console.WriteLine("Nombre actualizado correctamente.");
}

void EditUserContact()
{
    Console.WriteLine(@"
    =======================================================================
    === Opcion de editar el telefono del usuario elegida correctamente  ===
    =======================================================================
    ");
    Console.WriteLine("Ingrese el documento del usuario ->");
    string doc = Console.ReadLine() ?? "";
    var usuario = usuarioService.BuscarPorDocumento(doc);
    if (usuario == null) { Console.WriteLine("Usuario no encontrado."); return; }

    Console.WriteLine($"Telefono actual: {usuario.Telefono}. Nuevo telefono ->");
    usuario.Telefono = Console.ReadLine() ?? "";
    Console.WriteLine("Telefono actualizado correctamente.");
}

void ToggleUserActiveStatus()
{
    Console.WriteLine(@"
    ===================================================================
    === Opcion de activar / desactivar usuario elegida correctamente ===
    ===================================================================
    ");
    Console.WriteLine("Ingrese el documento del usuario ->");
    string doc = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el nuevo estado (A = Activo / I = Inactivo) ->");
    string estado = Console.ReadLine() ?? "";
    bool activo = estado.Trim().Equals("A", StringComparison.OrdinalIgnoreCase);
    if (usuarioService.CambiarEstado(doc, activo))
        Console.WriteLine("Estado actualizado correctamente.");
    else
        Console.WriteLine("Usuario no encontrado.");
}

void DeleteUser()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de eliminar usuario elegida correctamente ===
    ========================================================
    ");
    Console.WriteLine("Ingrese el documento del usuario que desea eliminar ->");
    string doc = Console.ReadLine() ?? "";
    if (usuarioService.EliminarUsuario(doc))
        Console.WriteLine("Usuario eliminado correctamente.");
    else
        Console.WriteLine("No se pudo eliminar (no encontrado).");
}

/*
En la rama feature/loans-menu se realizo las siguientes cosas:
Crear préstamo

- Validaciones:
    - usuario existe y está activo
    - libro existe y está disponible
    - (opcional) máximo de préstamos activos por usuario
        
        3.2 Listar préstamos
        
- 3.2.1 Todos
- 3.2.2 Activos
- 3.2.3 Cerrados (devueltos)
    
    3.3 Ver detalle de préstamo (por ID)
    
    3.4 Registrar devolución
    
- Cambia el préstamo a “devuelto”
- Marca el libro como “disponible”
    
    3.5 Eliminar préstamo
*/

void ShowLoansMenu()
{
     byte opcionElegidaPrestamos;

    do
    {
        Console.WriteLine(@"
    =============================
    ====== Menu prestamos =======
    =============================
    1.  Crear prestamo.
    2. Listar prestamos.
    3. Ver detalle por prestamos (por ID).
    4. Registrar devolucion.
    5. Eliminar prestamo.
    6. Salir al menu principal
    ==========================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionElegidaPrestamos))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionElegidaPrestamos)
        {
            case 1:
                CreateLoan();
                break;

            case 2:
                ListLoansMenu();
                break;

            case 3:
                ViewLoanDetail();
                break;

            case 4:
                RegisterReturn();
                break;

            case 5:
                DeleteLoan();
                break;

            case 6:
                // Se vuelve al menu principal automaticamente
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 6");
                break;
        }
    }
    while (opcionElegidaPrestamos != 6);
}

void CreateLoan()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Crear préstamo elegida correctamente   ===
    ========================================================
    ");
    Console.WriteLine("Ingrese el documento del usuario ->");
    string doc = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese el ISBN del libro ->");
    string isbn = Console.ReadLine() ?? "";

    var usuario = usuarioService.BuscarPorDocumento(doc);
    var libro = libroService.BuscarPorIsbn(isbn);
    string? error = prestamoService.ValidarPrestamo(libro, usuario);
    if (error != null)
    {
        Console.WriteLine($"No se pudo crear el préstamo: {error}");
        return;
    }

    var prestamo = prestamoService.RegistrarPrestamo(libro!, usuario!);
    if (prestamo != null)
        Console.WriteLine($"Préstamo creado correctamente. ID: {prestamo.Id}");
    else
        Console.WriteLine("No se pudo crear el préstamo.");
}

void ListLoansMenu()
{
    byte opcionListarPrestamo;

    Console.WriteLine(@"
    ========================================================
    === Opcion de Listar préstamos elegida correctamente ===
    ========================================================
    ");

    Console.WriteLine(@"
    =====================================
    == Que desea hacer especificamente ==
    =====================================
    1. Listar todos los préstamos.
    2. Listar préstamos activos.
    3. Listar préstamos cerrados.
    ");

    while (!byte.TryParse(Console.ReadLine(), out opcionListarPrestamo))
    {
        Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
    }

    switch (opcionListarPrestamo)
    {
        case 1:
            ListLoansAll();
            break;

        case 2:
            ListLoansActive();
            break;

        case 3:
            ListLoansClosed();
            break;

        default:
            Console.WriteLine("Numero ingresado incorrecto, es del uno al 3");
            break;
    }
}

void ListLoansAll()
{
    Console.WriteLine(@"
    ===========================
    == Todos los préstamos   ==
    ===========================");
    var list = prestamoService.ObtenerTodos();
    if (list.Count == 0) Console.WriteLine("No hay préstamos registrados.");
    else foreach (var p in list) Console.WriteLine(p.Linea());
}

void ListLoansActive()
{
    Console.WriteLine(@"
    ===========================
    == Préstamos activos     ==
    ===========================");
    var list = prestamoService.BuscarPorEstado(EstadoPrestamo.Activo);
    if (list.Count == 0) Console.WriteLine("No hay préstamos activos.");
    else foreach (var p in list) Console.WriteLine(p.Linea());
}

void ListLoansClosed()
{
    Console.WriteLine(@"
    ===========================
    == Préstamos cerrados    ==
    ===========================");
    var list = prestamoService.ObtenerCerrados();
    if (list.Count == 0) Console.WriteLine("No hay préstamos cerrados.");
    else foreach (var p in list) Console.WriteLine(p.Linea());
}

void ViewLoanDetail()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Ver detalle de préstamo elegida ===
    ========================================================
    ");
    Console.WriteLine("Ingrese el ID del préstamo ->");
    if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
    var prestamo = prestamoService.BuscarPorId(id);
    if (prestamo == null) Console.WriteLine("Préstamo no encontrado.");
    else Console.WriteLine(prestamo.DetalleCompleto());
}

void RegisterReturn()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Registrar devolucion elegida ===
    ========================================================
    ");
    Console.WriteLine("Ingrese el ID del préstamo a devolver ->");
    if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
    if (prestamoService.DevolverPrestamo(id))
        Console.WriteLine("Devolución registrada correctamente.");
    else
        Console.WriteLine("No se pudo registrar la devolución (no encontrado o ya devuelto).");
}

void DeleteLoan()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Eliminar préstamo elegida ===
    ========================================================
    ");
    Console.WriteLine("Ingrese el ID del préstamo a eliminar ->");
    if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
    if (prestamoService.EliminarPrestamo(id))
        Console.WriteLine("Préstamo eliminado correctamente.");
    else
        Console.WriteLine("No se pudo eliminar (no encontrado o no está devuelto).");
}

/*
En la rama feature/persistence-menu, se hizo lo siguiente:

5.1 Guardar datos (libros, usuarios, préstamos)

5.2 Cargar datos

5.3 Reiniciar datos (vaciar todo), pidiendo confirmación S/N
*/

void ShowPersistenceMenu()
{
    byte opcionElegidaPersistencia;

    do
    {
        Console.WriteLine(@"
    ===================================
    === Menu Guardar / Cargar datos ===
    ===================================
    1. Guardar datos.
    2. Cargar datos.
    3. Reiniciar datos.
    4. Salir al menu principal
    ===================================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionElegidaPersistencia))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionElegidaPersistencia)
        {
            case 1:
                SaveData();
                break;

            case 2:
                LoadData();
                break;

            case 3:
                ResetData();
                break;

            case 4:
                // Se vuelve al menu principal automaticamente
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 4");
                break;
        }
    }
    while (opcionElegidaPersistencia != 4);
}

/*
En la rama feature/search-reports-menu, se hizo lo siguiente:

4.1 Buscar libro
- por título
- por autor
- por ID/ISBN
- por categoría

4.2 Buscar usuario
- por nombre
- por ID/documento

4.3 Reportes
- préstamos por usuario
- préstamos por libro
- préstamos vencidos
- resumen general: total libros / disponibles / prestados
*/

void ShowSearchReportsMenu()
{
    byte opcionElegidaBuscar;

    do
    {
        Console.WriteLine(@"
    ===================================
    === Menu Buscar y Reportar   ===
    ===================================
    1. Buscar libro.
    2. Buscar usuario.
    3. Reportes.
    4. Salir al menu principal
    ===================================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionElegidaBuscar))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionElegidaBuscar)
        {
            case 1:
                SearchBook();
                break;

            case 2:
                SearchUser();
                break;

            case 3:
                ShowReportsMenu();
                break;

            case 4:
                // Se vuelve al menu principal automaticamente
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 4");
                break;
        }
    }
    while (opcionElegidaBuscar != 4);
}

void SearchBook()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Buscar libro elegida correctamente   ===
    ========================================================
    ");
    Console.WriteLine("Buscar por: 1. Título  2. Autor  3. ISBN  4. Categoría");
    string op = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese término de búsqueda ->");
    string term = Console.ReadLine() ?? "";
    List<Libro> resultados = op switch
    {
        "1" => libroService.BuscarPorTitulo(term),
        "2" => libroService.BuscarPorAutor(term),
        "3" => libroService.BuscarPorIsbn(term) is Libro l ? new List<Libro> { l } : new List<Libro>(),
        "4" => libroService.BuscarPorCategoria(term),
        _ => new List<Libro>()
    };
    if (resultados.Count == 0) Console.WriteLine("No se encontraron libros.");
    else foreach (var l in resultados) Console.WriteLine(l.Linea());
}

void SearchUser()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Buscar usuario elegida correctamente ===
    ========================================================
    ");
    Console.WriteLine("Buscar por: 1. Nombre  2. Documento");
    string op = Console.ReadLine() ?? "";
    Console.WriteLine("Ingrese término de búsqueda ->");
    string term = Console.ReadLine() ?? "";
    List<Usuario> resultados = op switch
    {
        "1" => usuarioService.BuscarPorNombre(term),
        "2" => usuarioService.BuscarPorDocumento(term) is Usuario u ? new List<Usuario> { u } : new List<Usuario>(),
        _ => new List<Usuario>()
    };
    if (resultados.Count == 0) Console.WriteLine("No se encontraron usuarios.");
    else foreach (var u in resultados) Console.WriteLine(u.Linea());
}

void ShowReportsMenu()
{
    byte opcionReporte;

    do
    {
        Console.WriteLine(@"
    ===================================
    === Menu Reportes / KPIs      ===
    ===================================
    1. Reporte por usuario.
    2. Reporte por libro.
    3. Reporte vencidos.
    4. Resumen general (KPIs).
    5. Comparación Array vs List.
    6. Salir al menu anterior
    ===================================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionReporte))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionReporte)
        {
            case 1: ReportByUser(); break;
            case 2: ReportByBook(); break;
            case 3: ReportOverdue(); break;
            case 4: ReportSummary(); break;
            case 5: DemostrarArrayVsList(); break;
            case 6: break;
            default: Console.WriteLine("Numero ingresado incorrecto, es del uno al 6"); break;
        }
    }
    while (opcionReporte != 6);
}

void ReportByUser()
{
    Console.WriteLine("Ingrese el documento del usuario ->");
    string doc = Console.ReadLine() ?? "";
    var usuario = usuarioService.BuscarPorDocumento(doc);
    if (usuario == null) { Console.WriteLine("Usuario no encontrado."); return; }
    var prestamos = prestamoService.ObtenerPorUsuario(doc);
    Console.WriteLine($@"
    == Reporte por usuario ==
    Usuario: {usuario.NombreCompleto} ({doc})
    - Total préstamos: {prestamos.Count}
    - Activos/Vencidos: {prestamos.Count(p => p.Estado != EstadoPrestamo.Devuelto)}
    - Devueltos: {prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto)}");
    foreach (var p in prestamos) Console.WriteLine("  " + p.Linea());
}

void ReportByBook()
{
    Console.WriteLine("Ingrese el ISBN del libro ->");
    string isbn = Console.ReadLine() ?? "";
    var libro = libroService.BuscarPorIsbn(isbn);
    if (libro == null) { Console.WriteLine("Libro no encontrado."); return; }
    var prestamos = prestamoService.ObtenerPorLibro(isbn);
    Console.WriteLine($@"
    == Reporte por libro ==
    Libro: {libro.NombreLibro} ({isbn})
    - Disponible: {(libro.Disponible ? "Sí" : "No")}
    - Historial de préstamos: {prestamos.Count}");
    foreach (var p in prestamos) Console.WriteLine("  " + p.Linea());
}

void ReportOverdue()
{
    Console.WriteLine(@"
    == Préstamos vencidos ==");
    var vencidos = prestamoService.BuscarPorEstado(EstadoPrestamo.Vencido);
    if (vencidos.Count == 0) Console.WriteLine("No hay préstamos vencidos.");
    else foreach (var p in vencidos) Console.WriteLine(p.Linea());
}

void ReportSummary()
{
    Console.WriteLine($@"
    ========================================
    == Resumen general / KPIs ==
    ========================================
    LIBROS
    - Total: {libroService.TotalLibros()}
    - Disponibles: {libroService.LibrosDisponibles()}
    - Prestados: {libroService.LibrosPrestados()}

    USUARIOS
    - Total: {usuarioService.TotalUsuarios()}
    - Activos: {usuarioService.UsuariosActivos()}
    - Inactivos: {usuarioService.UsuariosInactivos()}

    PRÉSTAMOS
    - Total: {prestamoService.TotalPrestamos()}
    - Activos: {prestamoService.PrestamosActivos()}
    - Vencidos: {prestamoService.PrestamosVencidos()}
    - Devueltos: {prestamoService.PrestamosDevueltos()}
    - Promedio días préstamo: {prestamoService.PromedioDiasPrestamo():F2}
    ========================================");
}

// Requerimiento 7: Comparación Array vs List<T>
void DemostrarArrayVsList()
{
    Console.WriteLine(@"
    ==========================================
    == Comparación: Array vs List<T> ==
    ==========================================");

    // --- ARRAY: tamaño fijo ---
    // Un array tiene un tamaño definido al crearse. No se puede agregar o quitar elementos dinámicamente.
    Libro[] arrayLibros = new Libro[2];
    arrayLibros[0] = new Libro("A1", "Autor A", "Libro Array 1", "Cat", 2001);
    arrayLibros[1] = new Libro("A2", "Autor B", "Libro Array 2", "Cat", 2002);
    Console.WriteLine($"Array: Length = {arrayLibros.Length} (fijo). No se puede hacer Add().");
    // Para "agregar" un 3er elemento habría que crear un nuevo array más grande y copiar.
    // arrayLibros[2] = ... -> lanzaría IndexOutOfRangeException

    // --- LIST<T>: tamaño dinámico ---
    // List<T> crece y se reduce según se necesite. Ofrece Add, Remove, búsquedas, etc.
    List<Libro> listaLibros = new List<Libro>();
    listaLibros.Add(new Libro("L1", "Autor A", "Libro List 1", "Cat", 2001));
    listaLibros.Add(new Libro("L2", "Autor B", "Libro List 2", "Cat", 2002));
    listaLibros.Add(new Libro("L3", "Autor C", "Libro List 3", "Cat", 2003)); // crece dinámicamente
    Console.WriteLine($"List:  Count  = {listaLibros.Count} (dinámico). Se puede Add/Remove.");
    listaLibros.RemoveAt(0);
    Console.WriteLine($"List tras RemoveAt(0): Count = {listaLibros.Count}");

    Console.WriteLine(@"
    Conclusión:
    - Array: tamaño fijo, acceso por índice, menos flexible.
    - List<T>: tamaño dinámico, métodos Add/Remove/Find/OrderBy, ideal para colecciones que cambian.
    ");
}

void SaveData()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Guardar datos elegida correctamente   ===
    ========================================================
    ");
    Console.WriteLine("(Simulado) Los datos están en memoria durante la ejecución.");
}

void LoadData()
{
    Console.WriteLine("Cargar datos (simulado): los datos de prueba ya están en memoria.");
}

bool ConfirmResetData()
{
    char respuestaConfirmacion;

    Console.WriteLine(@"
    =========================================
    == Esta seguro de reiniciar los datos? ==
    == Se eliminaran todos los registros.  ==
    =========================================
    Ingrese S para confirmar o N para cancelar -> 
    ");

    while (!char.TryParse(Console.ReadLine(), out respuestaConfirmacion) ||
           (respuestaConfirmacion != 'S' && respuestaConfirmacion != 's' &&
            respuestaConfirmacion != 'N' && respuestaConfirmacion != 'n'))
    {
        Console.WriteLine("Opcion no valida, ingrese S o N ->");
    }

    return respuestaConfirmacion == 'S' || respuestaConfirmacion == 's';
}

void ResetData()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Reiniciar datos elegida correctamente ===
    ========================================================
    ");

    if (!ConfirmResetData())
    {
        Console.WriteLine(@"
    ==============================
    == Reinicio cancelado       ==
    ==============================
    Los datos se mantienen intactos.
        ");
        return;
    }

    libroService.Reiniciar();
    usuarioService.Reiniciar();
    prestamoService.Reiniciar();

    Console.WriteLine("Datos reiniciados correctamente.");
}

/*
En la rama feature/exit-flow, se hizo lo siguiente:

6. Salir
- Preguntar: ¿Guardar antes de salir? (S/N)
- Llamar al menú principal al iniciar la aplicación.
*/

void ConfirmExitAndSave()
{
    char respuestaGuardar;

    Console.WriteLine(@"
    =========================================
    == Desea guardar antes de salir? (S/N) ==
    =========================================
    Ingrese S para guardar o N para salir sin guardar -> 
    ");

    while (!char.TryParse(Console.ReadLine(), out respuestaGuardar) ||
           (respuestaGuardar != 'S' && respuestaGuardar != 's' &&
            respuestaGuardar != 'N' && respuestaGuardar != 'n'))
    {
        Console.WriteLine("Opcion no valida, ingrese S o N ->");
    }

    if (respuestaGuardar == 'S' || respuestaGuardar == 's')
    {
        Console.WriteLine(@"
    ========================================
    == Guardando datos antes de salir...  ==
    ========================================
    ");
    }
    else
    {
        Console.WriteLine(@"
    ========================================
    == Saliendo sin guardar los datos...  ==
    ========================================
    ");
    }

    Console.WriteLine(@"
    ========================================
    === Gracias por usar la Biblioteca   ===
    ========================================
    ");
}




void SeedData()
{
    libroService.AgregarLibro(new Libro("ISBN-001", "Gabriel García Márquez", "Cien años de soledad", "Realismo mágico", 1967));
    libroService.AgregarLibro(new Libro("ISBN-002", "Antoine de Saint-Exupéry", "El Principito", "Fábula", 1943));
    libroService.AgregarLibro(new Libro("ISBN-003", "Miguel de Cervantes", "Don Quijote", "Novela", 1605));

    usuarioService.AgregarUsuario(new Usuario("1001", "Carlos", "Gómez", 25, "3001234567"));
    usuarioService.AgregarUsuario(new Usuario("1002", "María", "López", 32, "3109876543"));

    var u1 = usuarioService.BuscarPorDocumento("1001");
    var l1 = libroService.BuscarPorIsbn("ISBN-001");
    var l2 = libroService.BuscarPorIsbn("ISBN-002");
    if (u1 != null && l1 != null) prestamoService.RegistrarPrestamo(l1, u1, 7, DateTime.Now.AddDays(-20));
    if (u1 != null && l2 != null)
    {
        var p = prestamoService.RegistrarPrestamo(l2, u1, 7, DateTime.Now.AddDays(-3));
        if (p != null) prestamoService.DevolverPrestamo(p.Id, DateTime.Now.AddDays(-1));
    }
}

SeedData();
ShowMainMenu();
