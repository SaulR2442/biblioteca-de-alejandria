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
                // ShowPersistenceMenu()
                break;

            case 6:
                // ConfirmExitAndSave()
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
    string nombreLibro = Console.ReadLine();

    Console.WriteLine("Ingrese el nombre del autor del libro ->");
    string nombreAutorLibro = Console.ReadLine();

    Console.WriteLine("Ingrese la categoria del libro ->");
    string categoriaLibro = Console.ReadLine();

    Console.WriteLine("Ingrese el año cuando salio el libro ->");
    string añoLibro = Console.ReadLine();

    Console.WriteLine("Ingrese el id / isbn del libro ->");
    string idLibro = Console.ReadLine();

    Console.WriteLine($@"
    ====================================
    === Libro guardado correctamente ===
    ====================================
    Nombre -> {nombreLibro}.
    Author -> {nombreAutorLibro}.
    Categoria -> {categoriaLibro}.
    Año -> {añoLibro}.
    id / isbn -> {idLibro}.
    ====================================
    ");
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
    • Cien años de soledad – Gabriel García Márquez
    • La vorágine – José Eustasio Rivera
    • María – Jorge Isaacs
    • El olvido que seremos – Héctor Abad Faciolince
    • Delirio – Laura Restrepo
    • Satanás – Mario Mendoza
    • La perra – Pilar Quintana
    • El ruido de las cosas al caer – Juan Gabriel Vásquez
    • Changó, el gran putas – Manuel Zapata Olivella
    • La tejedora de coronas – Germán Espinosa
    ");
}

static void ListBooksAvailable()
{
    Console.WriteLine(@"
    ==================================
    == Todos los libros disponibles ==
    ==================================
    • La vorágine – José Eustasio Rivera
    • María – Jorge Isaacs
    • Satanás – Mario Mendoza
    • La perra – Pilar Quintana
    • Changó, el gran putas – Manuel Zapata Olivella
    • La tejedora de coronas – Germán Espinosa
    ");
}

static void ListBooksBorrowed()
{
    Console.WriteLine(@"
    ================================
    == Todos los libros prestados ==
    ================================
    • Cien años de soledad – Gabriel García Márquez 
    • El olvido que seremos – Héctor Abad Faciolince 
    • Delirio – Laura Restrepo 
    • El ruido de las cosas al caer – Juan Gabriel Vásquez 
    ");
}

static void ViewBookDetail()
{
    Console.WriteLine(@"
    =================================================================
    === Opcion de ver detalle de los libros elegida correctamente ===
    =================================================================
    ");

    Console.WriteLine(@"
    ========================================
    == Todos los libros, con sus detalles ==
    ========================================
    • Cien años de soledad – Gabriel García Márquez - id: 1967 - Realismo magico
    • La vorágine – José Eustasio Rivera - id: 1924 - Literatura de la selva / Realismo social
    • María – Jorge Isaacs - id: 1867 - Romanticismo
    • El olvido que seremos – Héctor Abad Faciolince - id: 2006 - Literatura de la selva / Realismo social
    • Delirio – Laura Restrepo - id: 2004 - Drama psicológico / Ficción contemporánea
    • Satanás – Mario Mendoza id: 2002 - Realismo degradado / Novela negra
    • La perra – Pilar Quintana - id: 2017 - Drama psicológico / Realismo
    • El ruido de las cosas al caer – Juan Gabriel Vásquez - id: 2011 - Ficción histórica / Drama contemporáneo
    • Changó, el gran putas – Manuel Zapata Olivella - id: 1983 - Ficción histórica / Epopeya afroamericana
    • La tejedora de coronas – Germán Espinosa - id: 1982 - Ficción histórica / Barroco
    ");
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

    Console.WriteLine("Ingrese el antiguo nombre del libro ->");
    string nombreLibroAntiguo = Console.ReadLine();

    Console.WriteLine("Ingrese el nuevo nombre del libro ->");
    string nombreLibroNuevo = Console.ReadLine();

    Console.WriteLine(@$"
    ===================================
    == Nombre guardado correctamente ==
    ===================================
    El libro {nombreLibroAntiguo}, 
    actualizo su nombre a 
    {nombreLibroNuevo}.
    ");
}

static void EditBookAuthor()
{
    Console.WriteLine(@"
    =====================================================================
    === Opcion de editar el autor de los libros elegida correctamente ===
    =====================================================================
    ");

    Console.WriteLine("Ingrese el nombre del libro ->");
    string nombreLibroEditarAutor = Console.ReadLine();

    Console.WriteLine("Ingrese el antiguo nombre del autor del libro ->");
    string nombreAutorLibroAntiguo = Console.ReadLine();

    Console.WriteLine("Ingrese el nuevo nombre del autor del libro ->");
    string nombreAutorLibroNuevo = Console.ReadLine();

    Console.WriteLine(@$"
    ===================================
    == Nombre guardado correctamente ==
    ===================================
    El libro {nombreLibroEditarAutor},
    cambio de autor de {nombreAutorLibroAntiguo},
    a {nombreAutorLibroNuevo}.
    ");
}

static void EditBookYearCategory()
{
    Console.WriteLine(@"
    ===============================================================================
    === Opcion de editar el año y categoria de los libros elegida correctamente ===
    ===============================================================================
    ");

    Console.WriteLine("Ingrese el nombre del libro ->");
    string nombreLibroEditarCategoria = Console.ReadLine();

    Console.WriteLine("Ingrese la antigua categoria del libro ->");
    string nombreCategoriaLibroAntiguo = Console.ReadLine();

    Console.WriteLine("Ingrese la nueva categoria del libro ->");
    string nombreCategoriaLibroNuevo = Console.ReadLine();

    Console.WriteLine("Ingrese el antiguo año del libro ->");
    string añoLibroAntiguo = Console.ReadLine();

    Console.WriteLine("Ingrese el nuevo año del libro ->");
    string añoLibroNuevo = Console.ReadLine();

    Console.WriteLine(@$"
    ============================================
    == Categoria y año guardado correctamente ==
    ============================================
    El libro {nombreLibroEditarCategoria},
    cambio de categoria de {nombreCategoriaLibroAntiguo},
    a {nombreCategoriaLibroNuevo}, y el año
    cambio de {añoLibroAntiguo}, a {añoLibroNuevo}.
    ");
}

static void DeleteBook()
{
    Console.WriteLine(@"
    ===========================================================
    === Opcion de eliminar los libros elegida correctamente ===
    ===========================================================
    ");

    Console.WriteLine("Ingrese el nombre del libro  que desea eliminar ->");
    string nombreLibroEliminar = Console.ReadLine();

    Console.WriteLine(@$"
    ===================================
    == Libro eliminado correctamente ==
    ===================================
    El libro {nombreLibroEliminar}, 
    a sido totalmente eliminado en 
    la bases de datos correctamente.
    ");
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
    2. Listar usuario.
    3. Ver detalle por usuario (por ID/documento).
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
    string nombreUsuario = Console.ReadLine();

    Console.WriteLine("Ingrese el apellido del usuario ->");
    string apellidoUsuario = Console.ReadLine();

    Console.WriteLine("Ingrese la edad del usuario ->");
    string edadUsuario = Console.ReadLine();

    Console.WriteLine("Ingrese el documento del usuario ->");
    string documentoUsuario = Console.ReadLine();

    Console.WriteLine("Ingrese el telefono del usuario ->");
    string telefonoUsuario = Console.ReadLine();

    Console.WriteLine($@"
    ========================================
    === Usuario registrado correctamente ===
    ========================================
    Nombre -> {nombreUsuario}.
    Apellido -> {apellidoUsuario}.
    Edad -> {edadUsuario}.
    Documento -> {documentoUsuario}.
    Telefono -> {telefonoUsuario}.
    ====================================
    ");
}

static void ListUsers()
{
    Console.WriteLine(@"
    ====================================================
    === Opcion listar usuarios elegida correctamente ===
    ====================================================
    ");

    Console.WriteLine(@"
    =======================
    == Lista de usuarios ==
    =======================
    - Carlos Gómez 
    - María López 
    - Juan Ramírez 
    - Ana Martínez 
    - Luis Torres 
    - Laura Sánchez 
    - Pedro Castro 
    - Sofía Herrera 
    - Andrés Rojas 
    - Camila Vargas 
    ");

}

static void ViewUserDetail()
{
    Console.WriteLine(@"
    =====================================================================
    === Opcion ver los detalles de los usuarios elegida correctamente ===
    =====================================================================
    ");

    Console.WriteLine(@"
    =======================
    == Lista de usuarios ==
    =======================
    - Carlos - Gómez - 25 - 1039485721 - 3001234567
    - María - López - 32 - 1012938475 - 3109876543
    - Juan - Ramírez - 19 - 1002345678 - 3123456789
    - Ana - Martínez - 45 - 43567891 - 3156789123
    - Luis - Torres - 28 - 1023456789 - 3112345678
    - Laura - Sánchez - 22 - 1056789123 - 3209876543
    - Pedro - Castro - 50 - 71234567 - 3187654321
    - Sofía - Herrera - 30 - 1034567890 - 3012345678
    - Andrés - Rojas - 21 - 1045678901 - 3023456789
    - Camila - Vargas - 27 - 1098765432 - 3145678901
    ");
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
    3. Editar edad.
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
            ;
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

    Console.WriteLine("Ingrese el antiguo nombre del usuario ->");
    string nombreUsuarioAntiguo = Console.ReadLine();

    Console.WriteLine("Ingrese el nuevo nombre del usuario ->");
    string nombreUsuarioNuevo = Console.ReadLine();

    Console.WriteLine(@$"
    ===================================
    == Nombre guardado correctamente ==
    ===================================
    El usuario {nombreUsuarioAntiguo}, 
    actualizo su nombre a 
    {nombreUsuarioNuevo}.
    ");
}

static void EditUserContact()
{
    Console.WriteLine(@"
    =======================================================================
    === Opcion de editar el telefono del usuario elegida correctamente  ===
    =======================================================================
    ");

    Console.WriteLine("Ingrese el nombre del usuario ->");
    string nombreUsuarioTelefono = Console.ReadLine();

    Console.WriteLine("Ingrese el antiguo telefono del usuario ->");
    string telefonoAntiguo = Console.ReadLine();

    Console.WriteLine("Ingrese el nuevo telefono del usuario ->");
    string telefonoNuevo = Console.ReadLine();

    Console.WriteLine(@$"
    =====================================
    == Telefono guardado correctamente ==
    =====================================
    El usuario {nombreUsuarioTelefono}, 
    actualizo su telefono de {telefonoAntiguo},
    a {telefonoNuevo}.
    ");
}

static void EditUserAge()
{
    Console.WriteLine(@"
    ===================================================================
    === Opcion de editar la edad del usuario elegida correctamente  ===
    ===================================================================
    ");

    Console.WriteLine("Ingrese el nombre del usuario ->");
    string nombreUsuarioEdad = Console.ReadLine();

    Console.WriteLine("Ingrese la antigua edad del usuario ->");
    string edadAntiguo = Console.ReadLine();

    Console.WriteLine("Ingrese la nueva edad del usuario ->");
    string edadNuevo = Console.ReadLine();

    Console.WriteLine(@$"
    =================================
    == Edad guardado correctamente ==
    =================================
    El usuario {nombreUsuarioEdad}, 
    actualizo su edad de {edadAntiguo},
    a {edadNuevo}.
    ");
}

static void DeleteUser()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de eliminar usuario elegida correctamente ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el nombre del usuario  que desea eliminar ->");
    string nombreUsuarioEliminar = Console.ReadLine();

    Console.WriteLine(@$"
    =====================================
    == Usuario eliminado correctamente ==
    =====================================
    El libro {nombreUsuarioEliminar}, 
    a sido totalmente eliminado en 
    la bases de datos correctamente.
    ");
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

    Console.WriteLine("Ingrese el ID del usuario ->");
    string idUsuario = Console.ReadLine();

    Console.WriteLine("Ingrese el ID del libro ->");
    string idLibro = Console.ReadLine();

    Console.WriteLine(@"
    ===========================================
    == Validaciones de préstamo (simuladas) ==
    ===========================================
    - Verificando si usuario existe y está activo...
    - Verificando si libro existe y está disponible...
    - Verificando límite de préstamos...
    ");

    Console.WriteLine($@"
    ========================================
    === Préstamo creado correctamente    ===
    ========================================
    Usuario ID: {idUsuario}
    Libro ID: {idLibro}
    ========================================
    ");
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
    ===========================
    - Préstamo ID: 001 - Libro: Cien años de soledad - Usuario: Carlos Gómez
    - Préstamo ID: 002 - Libro: El olvido que seremos - Usuario: María López
    ");
}

static void ListLoansActive()
{
    Console.WriteLine(@"
    ===========================
    == Préstamos activos     ==
    ===========================
    - Préstamo ID: 001 - Libro: Cien años de soledad - Usuario: Carlos Gómez
    ");
}

static void ListLoansClosed()
{
    Console.WriteLine(@"
    ===========================
    == Préstamos cerrados    ==
    ===========================
    - Préstamo ID: 002 - Libro: El olvido que seremos - Usuario: María López
    ");
}

static void ViewLoanDetail()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Ver detalle de préstamo elegida ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el ID del préstamo ->");
    string idPrestamo = Console.ReadLine();

    Console.WriteLine($@"
    ========================================
    == Detalle del préstamo (simulado) ==
    ========================================
    Préstamo ID: {idPrestamo}
    Libro: Cien años de soledad
    Usuario: Carlos Gómez
    Estado: Activo
    Fecha prestamo: 02/11/2026
    ========================================
    ");
}

static void RegisterReturn()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Registrar devolucion elegida ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el ID del préstamo a devolver ->");
    string idPrestamo = Console.ReadLine();

    Console.WriteLine(@"
    ===========================================
    == Registro de devolucion (simulado) ==
    ===========================================
    - Marcando el préstamo como devuelto...
    - Marcando el libro como disponible...
    ");

    Console.WriteLine($@"
    ========================================
    === Devolución registrada correctamente ===
    ========================================
    Préstamo ID: {idPrestamo}
    Estado: Devuelto
    Libro disponible
    ========================================
    ");
}

static void DeleteLoan()
{
    Console.WriteLine(@"
    ========================================================
    === Opcion de Eliminar préstamo elegida ===
    ========================================================
    ");

    Console.WriteLine("Ingrese el ID del préstamo a eliminar ->");
    string idPrestamo = Console.ReadLine();

    Console.WriteLine(@"
    ===========================================
    == Reglas sugeridas para eliminación ==
    ===========================================
    - Validar que el préstamo esté cerrado...
    - Validar que no haya multas pendientes...
    ");

    Console.WriteLine($@"
    ========================================
    === Préstamo eliminado correctamente ===
    ========================================
    Préstamo ID: {idPrestamo}
    ========================================
    ");
}

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