using GenealogiProject.Database;

namespace GenealogiProject.Utils
{
    internal class View
    {
        internal static void Parents(string[] names)
        {
            string name = names[0];
            string lastName = names[1];
            string motherText = "";
            string fatherText = "";
            using (var db = new FamilyContext())
            {
                var child = db.People.FirstOrDefault(c => c.Name == name && c.LastName == lastName);
                if (child == null) MenuHelper.PersonNotFound();
                var mother = db.People.FirstOrDefault(m => m.Id == child.Mother);
                if (mother == null) motherText = "unknown";
                else motherText = $"{mother.Name} {mother.LastName}";

                var father = db.People.FirstOrDefault(d => d.Id == child.Father);
                if (father == null) fatherText = "unknown";
                else fatherText = $"{father.Name} {father.LastName}";

                Box.Simple(new string[] { $"{name}'s mother is {motherText} and {name}'s father is {fatherText}." });
                Console.Read();
            }
        }

        internal static void Children(string[] names)
        {
            string name = names[0];
            string lastName = names[1];

            using (var db = new FamilyContext())
            {
                var parent = db.People.FirstOrDefault(p => p.Name == name && p.LastName == lastName);

                var children = db.People.Where(c => c.Mother == parent.Id || c.Father == parent.Id);

                if (children.Count() == 0) Box.Simple(new string[] { $"{parent.Name} has no children." });
                else
                {
                    Box.Simple(new string[] { $"These are {parent.Name}'s children" });
                    foreach (var child in children)
                    {
                        Box.Simple(new string[] { child.Name });
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
