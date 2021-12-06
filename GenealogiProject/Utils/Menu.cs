namespace GenealogiProject.Utils
{
    internal class Menu
    {
        public static void MainMenuText()
        {
            Console.Clear();
            Box.Simple(new string[]
           {"Choose an option",
            "[1]  View all persons",
            "[2]  Search for person",
            "[3]  Create person",
            "[4]  View one generation back",
            "[5]  View children",
            "[6]  View all users whos name and last name share the same starting letter"});
        }

        public static void MainMenu()
        {
            MainMenuText();

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    View.UniqueCountries();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    View.UniqueUserAndPassword();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    View.Vikings();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    View.MostCommonCountry();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    View.Top10L();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    View.StartingLetter();
                    Console.ReadKey();
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
    }
}
