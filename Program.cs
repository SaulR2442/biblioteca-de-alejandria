/*
En la rama feature/main-menu-navigation, se creo el menu de navegacion basico
con el do while, una validacion simple con .TryParse y un switch / case donde
se revisa cual caso escogio el usario y se mete al otro sub menu 
*/

static void ShowMainMenu()
{
    byte opcionElegida;

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

        while (!byte.TryParse(Console.ReadLine(), out opcionElegida))
        {
            Console.WriteLine("Opcion no valida, vuelva y eliga otra ->");
        }

        switch (opcionElegida)
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
    while (opcionElegida != 6);
}



