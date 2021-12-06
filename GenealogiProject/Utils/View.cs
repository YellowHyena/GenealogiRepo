using GenealogiProject.Database;

namespace GenealogiProject.Utils
{
    internal class View
    {
        internal static void Parents(string name, string lastName)
        {
            string motherText = "";
            string fatherText = "";
            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(p => p.Name == name && p.LastName == lastName);

                var mother = db.People.FirstOrDefault(mom => mom.Id == person.Mother);
                if (mother == null) motherText = "unknown";
                else motherText = $"{mother.Name} {mother.LastName}";

                var father = db.People.FirstOrDefault(mom => mom.Id == person.Father);
                if (father == null) fatherText = "unknown";
                else fatherText = $"{father.Name} {father.LastName}";

                Box.Simple(new string[] { $"{name}'s mother is {motherText} and {name}'s father is {fatherText} ." });
            }
        }
    }
}
