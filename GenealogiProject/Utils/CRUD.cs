using GenealogiProject.Database;
using GenealogiProject.Models;

namespace GenealogiProject.Utils
{
    internal class CRUD
    {
        public static Person FindAnd(string action, string name = "", string lastName = "", int father = 0, int mother = 0)
        {
            action = action.ToLower();
            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(h => h.Name == name && h.LastName == lastName);
                if (person == null && action == "add")
                {
                    Add(person, name, lastName, father, mother);
                }
                else if (person != null && action == "delete")
                {
                    Delete(person);
                }
                else if (person != null && action == "ask for names")
                {

                }
                else Menu.PersonNotFound();
                return person;
            }
        }

        private static Person Add(Person person, string name, string lastName, int father, int mother)
        {
            using (var db = new FamilyContext())
            {
                person = new Person
                {
                    Name = name,
                    LastName = lastName,
                    Father = father,
                    Mother = mother
                };
                db.People.Add(person);
                db.SaveChanges();
            }
            return person;
        }

        private static void Delete(Person person)
        {
            if (MenuHelper.ConfirmMenu($"delete {person.Name} {person.LastName}") == false) return; //If you decline deletion, return.         
            using (var db = new FamilyContext())
            {
                db.People.Remove(person);
                db.SaveChanges();
            }
        }

        internal static void SearchByName(string input)
        {
            input = input.ToLower();
            using (var db = new FamilyContext())
            {
                var persons = db.People.Where(p => p.Name.Contains(input) || p.LastName.Contains(input));
                if (persons == null) Box.Simple(new string[] { "No results." });
                else foreach (var person in persons)
                    {
                        Console.WriteLine(person.Name + " " + person.LastName);
                    }
                Menu.SearchOptionsMenu();
            }
        }

        internal static string[] AskForNames()
        {
            string input = "";
            string[]? split = new string[] { };
            bool tryAgain = false;
            do
            {
                Console.Clear();

                MenuHelper.AskForNamesText();

                input = Console.ReadLine();

                split = input.Split(' ');

                if (split.Length >1 && split.Length<3) tryAgain = FindPerson(split);
                else tryAgain=true;

            } while (tryAgain == true);

            return split;
        }

        private static bool FindPerson(string[] split)
        {
            string name = split[0];
            string lastName = split[1];
            var person = new Person();

            using (var db = new FamilyContext())
            {
                person = db.People.FirstOrDefault(p => p.Name == name && p.LastName == lastName);

                if (person == null) return Menu.PersonNotFound();
                else return false;
            }
        }
    }
}
