using GenealogiProject.Database;

namespace GenealogiProject.Utils
{
    internal class View
    {
        internal static void All() //Shows everyone
        {
            using var db = new FamilyContext();
            foreach (var person in db.People)
            {
                Console.WriteLine(person.Name + " " + person.LastName);
            }
        }

        internal static void Parents(string[] names) //Search for parent of searched person, aka "child"
        {
            using var db = new FamilyContext();

            string name = names[0];
            string lastName = names[1];
            string motherText = "";
            string fatherText = "";

            var child = db.People.FirstOrDefault(c => c.Name == name && c.LastName == lastName);
            var mother = db.People.FirstOrDefault(m => m.Id == child.Mother);
            var father = db.People.FirstOrDefault(d => d.Id == child.Father);


            if (mother == null) motherText = "unknown";                                                //checks if child has parents and adapts text accordingly
            else motherText = $"{mother.Name} {mother.LastName}";

            if (father == null) fatherText = "unknown";
            else fatherText = $"{father.Name} {father.LastName}";

            Box.Simple(new string[] { $"{name}'s mother is {motherText} and {name}'s father is {fatherText}." });
        }

        internal static void Children(string[] names) //search for children of searched person, aka "parent"
        {
            using var db = new FamilyContext();

            string name = names[0];
            string lastName = names[1];

            var parent = db.People.FirstOrDefault(p => p.Name == name && p.LastName == lastName);
            var children = db.People.Where(c => c.Mother == parent.Id || c.Father == parent.Id);

            if (children.Count() == 0) Box.Simple(new string[] { $"{parent.Name} has no children." }); //checks if parent has children and adapts text accordingly
            else
            {
                Box.Simple(new string[] { $"These are {parent.Name}'s children" });
                foreach (var child in children)
                {
                    Box.Simple(new string[] { child.Name });
                }
            }
        }

        internal static void Siblings(string[] names) //Search for siblings of searched person
        {
            using var db = new FamilyContext();

            string name = names[0];
            string lastName = names[1];

            var person = db.People.FirstOrDefault(p => p.Name == name && p.LastName == lastName);
            var siblings = db.People.Where(s => s.Mother == person.Mother || s.Father == person.Father);

            if (siblings.Count() == 0) Box.Simple(new string[] { $"{person.Name} has no siblings." }); //checks if person has siblings and adapts text accordingly
            else
            {
                Box.Simple(new string[] { $"These are {person.Name}'s siblings" });
                foreach (var sibling in siblings)
                {
                    if (sibling != person) Box.Simple(new string[] { sibling.Name }); //skips writing person amongst persons siblings
                }
            }
        }
    }
}
