using GenealogiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GenealogiProject.Database
{
    public class FamilyContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MEGenealogi;Trusted_Connection=True;");
        }
    }
}