namespace GenealogiProject.Utils
{
    internal class Menu
    {
        public static void MainMenu()
        {
            MenuHelper.MainMenuText();

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    View.All();
                    Console.ReadKey();
                    MainMenu();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.Write("Search for: ");
                    CRUD.SearchByName(Console.ReadLine());
                    Console.ReadKey();
                    MainMenu();
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    PersonOptions();
                    Console.ReadKey();
                    MainMenu();
                    break;

                case ConsoleKey.D4:
                    Console.Clear();
                    View.Parents(CRUD.AskForNames());
                    Console.ReadKey();
                    MainMenu();
                    break;

                case ConsoleKey.D5:
                    Console.Clear();
                    View.Children(CRUD.AskForNames());
                    Console.ReadKey();
                    MainMenu();
                    break;

                case ConsoleKey.D6:
                    Console.Clear();
                    View.Siblings(CRUD.AskForNames());
                    Console.ReadKey();
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }

        internal static bool PersonNotFound()
        {
            MenuHelper.PersonNotFoundText();

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    CRUD.CreateOrDeletePerson("add");
                    return false;

                case ConsoleKey.D2:
                    Console.Clear();
                    return true;

                default:
                    Console.Clear();
                    PersonNotFound();
                    return false;
            }
        }

        internal static void PersonOptions()
        {
            MenuHelper.PersonOptionText();

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    CRUD.CreateOrDeletePerson("add");
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    CRUD.Edit();
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    CRUD.CreateOrDeletePerson("delete");
                    break;

                default:
                    Console.Clear();
                    PersonOptions();
                    break;
            }
        }
    }
}
