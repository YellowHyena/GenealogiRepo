using GenealogiProject.Database;
using GenealogiProject.Models;
using GenealogiProject.Utils;
namespace GenealogiProject.Utils
{
    internal class TheSimpsonsAdder
    {
        public static void AddTheSimpsons()
        {
            CRUD.FindAnd("add", "Homer", "Simpson", 6, 7);
            CRUD.FindAnd("add", "Marge", "Bouvier", 8, 9);
            CRUD.FindAnd("add", "Bart", "Simpson", 1, 2);
            CRUD.FindAnd("add", "Lisa", "Simpson", 1, 2);
            CRUD.FindAnd("add", "Maggie", "Simpson", 1, 2);
            CRUD.FindAnd("add", "Abe", "Simpson", 0,0 );
            CRUD.FindAnd("add", "Mona", "Olsen", 0, 0);
            CRUD.FindAnd("add", "Clancy", "Bouvier", 0, 0);
            CRUD.FindAnd("add", "Jacqline", "Gurney", 0, 0);

            //using (var db = new FamilyContext())
            //{
                
            //    db.People.Add(new Person
            //    {
            //        //Id = 1,
            //        Name = "Homer",
            //        LastName = "Simpson",
            //        Father = 6,
            //        Mother = 7

            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 2,
            //        Name = "Marge",
            //        LastName = "Bouvier",
            //        Father = 8,
            //        Mother = 9
            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 3,
            //        Name = "Bart",
            //        LastName = "Simpson",
            //        Father = 1,
            //        Mother = 2
            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 4,
            //        Name = "Lisa",
            //        LastName = "Simpson",
            //        Father = 1,
            //        Mother = 2
            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 5,
            //        Name = "Maggie",
            //        LastName = "Simpson",
            //        Father = 1,
            //        Mother = 2
            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 6,
            //        Name = "Abe",
            //        LastName = "Simpson",
            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 7,
            //        Name = "Mona",
            //        LastName = "Olsen",
            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 8,
            //        Name = "Clancy",
            //        LastName = "Bouvier",
            //    });
            //    db.People.Add(new Person
            //    {
            //        //Id = 9,
            //        Name = "Jacqueline",
            //        LastName = "Gurney",
            //    });

            //    db.SaveChanges();
            //}
        }
    }
}

