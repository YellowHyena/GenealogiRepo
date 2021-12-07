using GenealogiProject.Database;
using GenealogiProject.Models;

namespace GenealogiProject.Utils
{
    internal class CRUD
    {
        public static void FindAnd(string action, string name = "", string lastName = "", int father = 0, int mother = 0)
        {
            action = action.ToLower();
            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(h => h.Name == name && h.LastName == lastName);

                if (person == null && action == "add")
                {
                    Add(person, name, lastName, father, mother);
                }
                else if (person != null && action == "add")
                {
                    Box.Simple(new string[] { "This person already exists" });
                }
                else if (person != null && action == "delete")
                {
                    Delete(person);
                }

                else Menu.PersonNotFound();
            }
        }

        private static void Add(Person person, string name, string lastName, int father, int mother)
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
        }

        private static void Delete(Person person)
        {
            if (MenuHelper.ConfirmMenu($"delete {person.Name} {person.LastName}") == false) return; //If you decline deletion, return. Else remove         
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
            string[] split = new string[] { };
            bool tryAgain = false;
            do
            {
                Console.Clear();

                MenuHelper.AskForNamesText();

                input = Console.ReadLine();

                split = input.Split(' ');

                if (split.Length > 1 && split.Length < 3) tryAgain = FindPerson(split);
                else tryAgain = true;

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

        internal static void CreatePerson()
        {
            string name = "";
            string lastName = "";
            string[] motherNames = new string[] { };
            int motherId = 0;
            string[] fatherNames = new string[] { };
            int fatherId = 0;

            Console.WriteLine("Write first name: ");
            name = Console.ReadLine();

            Console.WriteLine("Write last name: ");
            lastName = Console.ReadLine();

            using (var db = new FamilyContext())
            {
                Console.WriteLine("Write the mother's first and last names separated by a space, leave blank if no mother exists: ");
                motherNames = Console.ReadLine().Split(' ');

                if (motherNames.Length == 1) motherId = 0;
                else
                {
                    var mother = db.People.FirstOrDefault(m => m.Name == motherNames[0] && m.LastName == motherNames[1]);
                    if (mother != null) motherId = mother.Id;
                }

                Console.WriteLine("Write the father's first and last names separated by a space, leave blank if no father exists: ");
                fatherNames = Console.ReadLine().Split(' ');

                if (fatherNames.Length == 1) fatherId = 0;
                else
                {
                    var father = db.People.FirstOrDefault(f => f.Name == fatherNames[0] && f.LastName == fatherNames[1]);
                    if (father != null) fatherId = father.Id;
                }

            }
            FindAnd("add",name,lastName,fatherId,motherId);
        }
    }
}
