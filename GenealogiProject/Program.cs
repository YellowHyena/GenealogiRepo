using GenealogiProject.Database;
using GenealogiProject.Models;
using GenealogiProject.Utils;
namespace GenealogiProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Sorry för min fula kod i detta programmet, tidspress och dålig planering.
            TheSimpsonsAdder.AddTheSimpsons();
            Menu.MainMenu();
        }
    }
}