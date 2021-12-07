namespace GenealogiProject.Models
{
    public class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Mother { get; set; }
        public int Father { get; set; }
    }
}
