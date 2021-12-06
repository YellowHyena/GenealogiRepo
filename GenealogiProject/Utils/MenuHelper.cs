using GenealogiProject.Utils;

namespace GenealogiProject.Utils
{
    internal class MenuHelper
    {
        static public bool Confirm(string action)
        {
            Box.Simple(new string[]{"Do you want to " + action + "?"});
            Box.Simple(new string[]{"Press Enter to confirm", "Press any other key to decline."});
            var key = Console.ReadKey().Key; 
            if (key != ConsoleKey.Enter) return false;
            else return true;
        }
    }
}
