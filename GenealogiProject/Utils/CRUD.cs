using GenealogiProject.Database;
using GenealogiProject.Models;

namespace GenealogiProject.Utils
{
    internal class CRUD
    {
        public static Person FindAnd(string action, string name, string lastName, int father, int mother)
        {
            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(h => h.Name == name); // Får error här för den är null
                if (person == null && action.ToLower() == "add")            //Men den måste ju kunna va null för att denna raden ska funka?
                {
                    Add(person, name, lastName, father, mother);
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
    }
}
