using GenealogiProject.Database;
using GenealogiProject.Models;

namespace GenealogiProject.Utils
{
    internal class CRUD
    {
        public static Person FindAnd(string action, string name, string lastName, int father, int mother)
        {
            action = action.ToLower();
            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(h => h.Name == name);
                if (person == null && action == "add")
                {
                    Add(person, name, lastName, father, mother);
                }
                else if (person != null && action == "delete")
                {
                    Delete(person);
                }

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
            if (MenuHelper.Confirm($"delete {person.Name} {person.LastName}") == false) return;          
            using(var db = new FamilyContext())
            { 
                db.People.Remove(person);
                db.SaveChanges();
            }
        }

    }
}
