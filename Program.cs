/*
En la rama feature/main-menu-navigation, se creo el menu de navegacion basico
con el do while, una validacion simple con .TryParse y un switch / case donde
se revisa cual caso escogio el usario y se mete al otro sub menu 
*/

static void ShowMainMenu()
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

static void ShowBooksMenu()
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

static void RegisterBook()
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

static void ListBooksMenu()
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

static void ListBooksAll()
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

static void ListBooksAvailable()
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

static void ListBooksBorrowed()
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

static void ViewBookDetail()
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

static void UpdateBookMenu()
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

static void EditBookTitle()
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

static void EditBookAuthor()
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

static void EditBookYearCategory()
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

static void DeleteBook()
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

static void ShowUsersMenu()
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

static void RegisterUser()
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

static void ListUsers()
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

static void ViewUserDetail()
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

static void UpdateUserMenu()
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

static void EditUserName()
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

static void EditUserContact()
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

static void ToggleUserActiveStatus()
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

static void DeleteUser()
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

static void ShowLoansMenu()
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

static void CreateLoan()
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

static void ListLoansMenu()
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

static void ListLoansAll()
{
    Console.WriteLine(@"
    ===========================
    == Todos los préstamos   ==
    ===========================");
    var list = prestamoService.ObtenerTodos();
    if (list.Count == 0) Console.WriteLine("No hay préstamos registrados.");
    else foreach (var p in list) Console.WriteLine(p.Linea());
}

static void ListLoansActive()
{
    Console.WriteLine(@"
    ===========================
    == Préstamos activos     ==
    ===========================");
    var list = prestamoService.BuscarPorEstado(EstadoPrestamo.Activo);
    if (list.Count == 0) Console.WriteLine("No hay préstamos activos.");
    else foreach (var p in list) Console.WriteLine(p.Linea());
}

static void ListLoansClosed()
{
    Console.WriteLine(@"
    ===========================
    == Préstamos cerrados    ==
    ===========================");
    var list = prestamoService.ObtenerCerrados();
    if (list.Count == 0) Console.WriteLine("No hay préstamos cerrados.");
    else foreach (var p in list) Console.WriteLine(p.Linea());
}

static void ViewLoanDetail()
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

static void RegisterReturn()
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

static void DeleteLoan()
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

static void ShowPersistenceMenu()
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

static void ShowSearchReportsMenu()
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

static void SearchBook()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Buscar libro elegida correctamente   ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el titulo, autor, id o categoria del libro ->");
    string busquedaLibro = Console.ReadLine();

    Console.WriteLine($@"
    ========================================
    == Resultado de busqueda de libro (simulado) ==
    ========================================
    Busqueda: {busquedaLibro}
    - Libro encontrado: Cien años de soledad - Gabriel García Márquez
    - Libro encontrado: La vorágine - José Eustasio Rivera
    ========================================
    ");
}

static void SearchUser()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Buscar usuario elegida correctamente ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el nombre o ID del usuario ->");
    string busquedaUsuario = Console.ReadLine();

    Console.WriteLine($@"
    ========================================
    == Resultado de busqueda de usuario (simulado) ==
    ========================================
    Busqueda: {busquedaUsuario}
    - Usuario encontrado: Carlos Gómez - ID: 1039485721
    - Usuario encontrado: María López - ID: 1012938475
    ========================================
    ");
}

static void ShowReportsMenu()
{
    byte opcionReporte;

    do
    {
        Console.WriteLine(@"
    ===================================
    === Menu Reportes            ===
    ===================================
    1. Reporte por usuario.
    2. Reporte por libro.
    3. Reporte vencidos.
    4. Resumen general.
    5. Salir al menu anterior
    ===================================
    Ingrese su opcion (solo el numero) -> 
    ");

        while (!byte.TryParse(Console.ReadLine(), out opcionReporte))
        {
            Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
        }

        switch (opcionReporte)
        {
            case 1:
                ReportByUser();
                break;

            case 2:
                ReportByBook();
                break;

            case 3:
                ReportOverdue();
                break;

            case 4:
                ReportSummary();
                break;

            case 5:
                // Se vuelve al menu anterior automaticamente
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 5");
                break;
        }
    }
    while (opcionReporte != 5);
}

static void ReportByUser()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Reporte por usuario elegida ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el nombre o ID del usuario ->");
    string idUsuarioReporte = Console.ReadLine();

    Console.WriteLine($@"
    ========================================
    == Reporte por usuario (simulado) ==
    ========================================
    Usuario: {idUsuarioReporte}
    - Prestamos activos: 1
    - Prestamos cerrados: 2
    - Multas pendientes: 0
    ========================================
    ");
}

static void ReportByBook()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Reporte por libro elegida ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el titulo o ID del libro ->");
    string idLibroReporte = Console.ReadLine();

    Console.WriteLine($@"
    ========================================
    == Reporte por libro (simulado) ==
    ========================================
    Libro: {idLibroReporte}
    - Estado: Prestado
    - Usuario actual: Carlos Gómez
    - Historial de prestamos: 3
    ========================================
    ");
}

static void ReportOverdue()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Reporte vencidos elegida ===
    ========================================================
    ");

    Console.WriteLine(@"
    ========================================
    == Reporte de prestamos vencidos (simulado) ==
    ========================================
    - Préstamo ID: 003 - Libro: María - Usuario: Juan Ramírez - Vencido desde: 15/10/2026
    - Préstamo ID: 004 - Libro: Delirio - Usuario: Ana Martínez - Vencido desde: 20/10/2026
    ========================================
    ");
}

static void ReportSummary()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Resumen general elegida ===
    ========================================================
    ");

    Console.WriteLine(@"
    ========================================
    == Resumen general del sistema (simulado) ==
    ========================================
    - Total libros registrados: 10
    - Libros disponibles: 6
    - Libros prestados: 4
    - Total usuarios registrados: 10
    - Total prestamos activos: 3
    - Total prestamos cerrados: 1
    - Prestamos vencidos: 2
    ========================================
    ");
}

static void SaveData()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Guardar datos elegida correctamente   ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el nombre del archivo para guardar ->");
    string nombreArchivo = Console.ReadLine();

    Console.WriteLine(@"
    ========================================
    == Guardando datos (simulado) ==
    ========================================
    - Serializando libros...
    - Serializando usuarios...
    - Serializando prestamos...
    ");

    Console.WriteLine($@"
    ========================================
    === Datos guardados en: {nombreArchivo} ===
    ========================================
    ");
}

static void LoadData()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Cargar datos elegida correctamente   ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el nombre del archivo para cargar ->");
    string nombreArchivo = Console.ReadLine();

    Console.WriteLine(@"
    ========================================
    == Cargando datos (simulado) ==
    ========================================
    - Deserializando libros...
    - Deserializando usuarios...
    - Deserializando prestamos...
    ");

    Console.WriteLine($@"
    ========================================
    === Datos cargados desde: {nombreArchivo} ===
    ========================================
    ");
}

static bool ConfirmResetData()
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

static void ResetData()
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

    Console.WriteLine(@"
    ========================================
    == Reiniciando datos (simulado) ==
    ========================================
    - Eliminando libros...
    - Eliminando usuarios...
    - Eliminando prestamos...
    ");

    Console.WriteLine(@"
    ========================================
    === Datos reiniciados correctamente  ===
    ========================================
    ");
}

/*
En la rama feature/exit-flow, se hizo lo siguiente:

6. Salir
- Preguntar: ¿Guardar antes de salir? (S/N)
- Llamar al menú principal al iniciar la aplicación.
*/

static void ConfirmExitAndSave()
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

// Llamada al menu principal para iniciar la aplicacion.
static LibroService libroService = new LibroService();
static UsuarioService usuarioService = new UsuarioService();
static PrestamoService prestamoService = new PrestamoService();

ShowMainMenu();
