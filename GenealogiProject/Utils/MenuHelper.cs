namespace GenealogiProject.Utils
{
    internal class MenuHelper
    {
        static internal bool ConfirmMenu(string action)
        {
            Box.Simple(new string[] { "Do you want to " + action + "?" });
            Box.Simple(new string[] { "Press Enter to confirm", "Press any other key to decline." });
            var key = Console.ReadKey().Key;
            if (key != ConsoleKey.Enter) return false;
            else return true;
        }
        internal static void MainMenuText()
        {
            Console.Clear();
            Box.Simple(new string[]
           {"Choose an option",
            "[1]  View all persons",
            "[2]  Search for person",
            "[3]  Create person",
            "[4]  View a persons parents",
            "[5]  View children",
            "[6]  View all users whos name and last name share the same starting letter"});
        }
        internal static void SearchOptionsText()
        {
            Box.Simple(new string[]
            {"[1] Search by name?",
             "[2] Search by age?",  //null
             "[3] Return to main menu?"});
        }
    }
}
