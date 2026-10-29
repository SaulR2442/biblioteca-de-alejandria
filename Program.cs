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
                // ShowLoansMenu()
                break;

            case 4:
                // ShowSearchReportsMenu()
                break;

            case 5:
                // ShowPersistenceMenu()
                break;

            case 6:
                // ConfirmExitAndSave()
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 6") ;
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
    byte opcionElegidaLibros ;

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
                RegisterBook() ; 
                break;

            case 2:
                ListBooksMenu() ;
                break;

            case 3:
                ViewBookDetail() ;
                break;

            case 4:
                UpdateBookMenu() ;
                break;

            case 5:
                DeleteBook() ;
                break;

            case 6:
                // Se vuelve al menu principal automaticamente
                break;

            default:
                Console.WriteLine("Numero ingresado incorrecto, es del uno al 6") ;
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

    Console.WriteLine("Ingrese el nombre del libro ->") ;
    string nombreLibro = Console.ReadLine() ;

    Console.WriteLine("Ingrese el nombre del autor del libro ->") ;
    string nombreAutorLibro = Console.ReadLine() ;

    Console.WriteLine("Ingrese la categoria del libro ->") ;
    string categoriaLibro = Console.ReadLine() ;

    Console.WriteLine("Ingrese el año cuando salio el libro ->") ;
    string añoLibro = Console.ReadLine() ;

    Console.WriteLine("Ingrese el id / isbn del libro ->") ;
    string idLibro = Console.ReadLine() ;

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
    byte opcionListarLibro ;

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
    ") ;

    while (!byte.TryParse(Console.ReadLine(), out opcionListarLibro))
    {
        Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
    }

    switch (opcionListarLibro)
    {
        case 1:
            ListBooksAll() ;
            break;

        case 2:
            ListBooksAvailable() ;
            break;

        case 3:
            ListBooksBorrowed() ;
            break;

        default:
            Console.WriteLine("Numero ingresado incorrecto, es del uno al 3") ;
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
    ") ;
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
    ") ;
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
    ") ;
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
    ") ;
}

static void UpdateBookMenu()
{
    byte opcionActualizarLibro ;

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
    ") ;

    while (!byte.TryParse(Console.ReadLine(), out opcionActualizarLibro))
    {
        Console.WriteLine("Opcion no valida, vuelva y elija otra ->");
    }

    switch (opcionActualizarLibro)
    {
        case 1:
            EditBookTitle() ;
            break;

        case 2:
            EditBookAuthor() ;
            break;

        case 3:
            EditBookYearCategory() ;
            break;

        default:
            Console.WriteLine("Numero ingresado incorrecto, es del uno al 3") ;
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

    Console.WriteLine("Ingrese el antiguo nombre del libro ->") ;
    string nombreLibroAntiguo = Console.ReadLine() ;

    Console.WriteLine("Ingrese el nuevo nombre del libro ->") ;
    string nombreLibroNuevo = Console.ReadLine() ;

    Console.WriteLine(@$"
    ===================================
    == Nombre guardado correctamente ==
    ===================================
    El libro {nombreLibroAntiguo}, 
    actualizo su nombre a 
    {nombreLibroNuevo}.
    ") ;
}

static void EditBookAuthor()
{
    Console.WriteLine(@"
    =====================================================================
    === Opcion de editar el autor de los libros elegida correctamente ===
    =====================================================================
    ");

    Console.WriteLine("Ingrese el nombre del libro ->") ;
    string nombreLibroEditarAutor = Console.ReadLine() ;

    Console.WriteLine("Ingrese el antiguo nombre del autor del libro ->") ;
    string nombreAutorLibroAntiguo = Console.ReadLine() ;

    Console.WriteLine("Ingrese el nuevo nombre del autor del libro ->") ;
    string nombreAutorLibroNuevo = Console.ReadLine() ;

    Console.WriteLine(@$"
    ===================================
    == Nombre guardado correctamente ==
    ===================================
    El libro {nombreLibroEditarAutor},
    cambio de autor de {nombreAutorLibroAntiguo},
    a {nombreAutorLibroNuevo}.
    ") ;
}

static void EditBookYearCategory()
{
    Console.WriteLine(@"
    ===============================================================================
    === Opcion de editar el año y categoria de los libros elegida correctamente ===
    ===============================================================================
    ");

    Console.WriteLine("Ingrese el nombre del libro ->") ;
    string nombreLibroEditarCategoria = Console.ReadLine() ;

    Console.WriteLine("Ingrese la antigua categoria del libro ->") ;
    string nombreCategoriaLibroAntiguo = Console.ReadLine() ;

    Console.WriteLine("Ingrese la nueva categoria del libro ->") ;
    string nombreCategoriaLibroNuevo = Console.ReadLine() ;

    Console.WriteLine("Ingrese el antiguo año del libro ->") ;
    string añoLibroAntiguo = Console.ReadLine() ;

    Console.WriteLine("Ingrese el nuevo año del libro ->") ;
    string añoLibroNuevo = Console.ReadLine() ;

    Console.WriteLine(@$"
    ============================================
    == Categoria y año guardado correctamente ==
    ============================================
    El libro {nombreLibroEditarCategoria},
    cambio de categoria de {nombreCategoriaLibroAntiguo},
    a {nombreCategoriaLibroNuevo}, y el año
    cambio de {añoLibroAntiguo}, a {añoLibroNuevo}.
    ") ;
}

static void DeleteBook()
{
    Console.WriteLine(@"
    ===========================================================
    === Opcion de eliminar los libros elegida correctamente ===
    ===========================================================
    ");

    Console.WriteLine("Ingrese el nombre del libro  que desea eliminar ->") ;
    string nombreLibroEliminar = Console.ReadLine() ;

    Console.WriteLine(@$"
    ===================================
    == Libro eliminado correctamente ==
    ===================================
    El libro {nombreLibroEliminar}, 
    a sido totalmente eliminado en 
    la bases de datos correctamente.
    ") ;
}


