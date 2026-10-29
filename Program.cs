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
                // ShowBooksMenu()
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
                // ListBooksMenu()
                break;

            case 3:
                // ViewBookDetail()
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
