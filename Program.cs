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
                // ShowUsersMenu()
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
                // UpdateBookMenu()
                break;

            case 5:
                // DeleteBook()
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