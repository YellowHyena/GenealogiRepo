﻿using GenealogiProject.Database;
using GenealogiProject.Models;
using GenealogiProject.Utils;
namespace GenealogiProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            TheSimpsonsAdder.AddTheSimpsons();
            View.Children("Homer", "Simpson");
            Menu.MainMenu();
        }
    }
}