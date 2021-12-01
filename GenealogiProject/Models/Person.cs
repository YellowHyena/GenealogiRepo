using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogiProject.Models
{
    public class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; } //VG
        public string DateOfDeath { get; set; } //VG
        public int Mother { get; set; }
        public int Father { get; set; }      
    }
}
