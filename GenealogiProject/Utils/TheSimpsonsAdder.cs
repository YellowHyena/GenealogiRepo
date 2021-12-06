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
        }
    }
}

