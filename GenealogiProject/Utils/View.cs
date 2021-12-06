using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogiProject.Utils
{
    internal class View
    {
        internal static void Parents(string name, string lastName)
        {
            using (var db = new FamilyContext())
            {
                var persons = db.People.Where(p => p.Name.Contains(input) || p.LastName.Contains(input));
                foreach (var person in persons)
                {
                    Console.WriteLine(person.Name + " " + person.LastName);
                }
            }
        }
    }
}
