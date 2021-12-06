﻿namespace GenealogiProject.Utils
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
            "[5]  View a persons children",
            "[6]  View a persons siblings"});
        }

        internal static void PersonNotFoundText()
        {
            Box.Simple(new string[]
            {"Person does not exist. Did you spell it right?",
             "[1] Create new person",
             "[2] Try again"});
        }

        internal static void SearchOptionsText()
        {
            Box.Simple(new string[]
            {"[1] Search by name",
             "[2] Search by age",  //null
             "[3] Return to main menu"});
        }

        internal static void AskForNamesText()
        {
            Box.Simple(new string[]
            {"Write the name and last name of " +
                 "the person you want to search for " +
                 "separated by a space"});
        }
    }
}
