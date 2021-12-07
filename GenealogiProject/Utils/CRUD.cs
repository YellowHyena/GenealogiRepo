using GenealogiProject.Database;
using GenealogiProject.Models;

namespace GenealogiProject.Utils
{
    internal class CRUD
    {
        //way too complicated. Basically you decide the action when calling it. I'm not sure if it's acctually usefull but i'm not changing it now..
        public static void FindAnd(string action, string name = "", string lastName = "", int father = 0, int mother = 0)
        {
            action = action.ToLower();
            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(p => p.Name == name && p.LastName == lastName && p.Father == father && p.Mother == mother);

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

        private static void Add(Person person, string name, string lastName, int father, int mother) //simple, just adds the person with the information given
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

        private static void Delete(Person person) //Delete a person
        {
            if (MenuHelper.ConfirmMenu($"delete {person.Name} {person.LastName}") == false) return; //If you decline deletion, return. Else delete         
            using (var db = new FamilyContext())
            {
                db.People.Remove(person);
                db.SaveChanges();
            }
            Box.Simple(new string[] { $"{person.Name} {person.LastName} was deleted." });
        }

        internal static void SearchByName(string input) //Search for a person, will match with first and last names
        {
            input = input.ToLower();
            using (var db = new FamilyContext())
            {
                var persons = db.People.Where(p => p.Name.Contains(input) || p.LastName.Contains(input));
                if (persons == null) Box.Simple(new string[] { "No results." });
                else
                {
                    foreach (var person in persons)
                    {
                        Console.WriteLine(person.Name + " " + person.LastName);
                    }
                }            
            }
        }

        internal static string[] AskForNames() //Will get firs and last name from one input. Not necessary but i learned how .Split works
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

        private static bool FindPerson(string[] split) //helping AskForNames() to find if the person exists
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

        internal static void CreateOrDeletePerson(string action) // write "add" or "delete" when calling. Will ask for all information and will delete or create accordingly
        {
            string name, lastName;
            int motherId, fatherId;
            AskForAllInfo(out name, out lastName, out motherId, out fatherId);
            FindAnd(action, name, lastName, fatherId, motherId);
        }

        private static void AskForAllInfo(out string name, out string lastName, out int motherId, out int fatherId) //asks for all info
        {
            name = "";
            lastName = "";
            string[] motherNames = new string[] { };
            motherId = 0;
            string[] fatherNames = new string[] { };
            fatherId = 0;
            Console.WriteLine("Write first name: ");
            name = Console.ReadLine();

            Console.WriteLine("Write last name: ");
            lastName = Console.ReadLine();

            using (var db = new FamilyContext())
            {
                Console.WriteLine("Write the mother's first and last names separated by a space, leave blank if no mother exists: ");
                motherNames = Console.ReadLine().Split(' ');

                if (motherNames.Length == 1) motherId = 0;   //converts the name of parent to id of parent
                else
                {
                    var mother = db.People.FirstOrDefault(m => m.Name == motherNames[0] && m.LastName == motherNames[1]);
                    if (mother != null) motherId = mother.Id;
                }

                Console.WriteLine("Write the father's first and last names separated by a space, leave blank if no father exists: ");
                fatherNames = Console.ReadLine().Split(' ');

                if (fatherNames.Length == 1) fatherId = 0;   //converts the name of parent to id of parent
                else
                {
                    var father = db.People.FirstOrDefault(f => f.Name == fatherNames[0] && f.LastName == fatherNames[1]);
                    if (father != null) fatherId = father.Id;
                }
            }
        }

        internal static void Edit() // asks for all info to determine which person to edit. then asks again and applies new info to person
        {
            string name, lastName;
            int motherId, fatherId;
            AskForAllInfo(out name, out lastName, out motherId, out fatherId);

            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(p => p.Name == name && p.LastName == lastName && p.Father == fatherId && p.Mother == motherId);
                if (person == null) Menu.PersonNotFound();
                else
                {
                    Console.WriteLine("Write the new information");
                    AskForAllInfo(out name, out lastName, out motherId, out fatherId);
                    
                    person.Name = name;
                    person.LastName = lastName;
                    person.Father = fatherId;
                    person.Mother = motherId;
                    db.People.Update(person);
                    db.SaveChanges();
                }
            }               
        }
    }
}
