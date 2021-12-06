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
                    //View.Everyone();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    SearchOptionsMenu();
                    Console.ReadKey();
                    MainMenu();
                    break;
                //case ConsoleKey.D3:
                    Console.Clear();
                //    View.Vikings();
                //    Console.ReadKey();
                //    MainMenu();
                //    break;
                //case ConsoleKey.D4:
                //    Console.Clear();
                //    View.MostCommonCountry();
                //    Console.ReadKey();
                //    MainMenu();
                //    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    View.Children(CRUD.AskForNames());
                    Console.ReadKey();
                    MainMenu();
                    break;
                    //case ConsoleKey.D6:
                    //    Console.Clear();
                    //    View.StartingLetter();
                    //    Console.ReadKey();
                    //    MainMenu();
                    //    break;
                    //default:
                    //    Console.Clear();
                    //    MainMenu();
                    //    break;
            }
        }

        internal static void SearchOptionsMenu()
        {
            MenuHelper.SearchOptionsText();
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.Write("Search for: ");
                    CRUD.SearchByName(Console.ReadLine());
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    //CRUD.SearchByAge();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    SearchOptionsMenu();
                    break;

            }
        }
    }
}
