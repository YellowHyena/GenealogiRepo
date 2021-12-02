using GenealogiProject.Database;
using GenealogiProject.Models;

namespace GenealogiProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FamilyContext())
            {
                db.People.Add(new Person
                {
                    Name = "Homer",
                    LastName = "Simpson"
                });
                db.SaveChanges();
                }
            }

        }
    }