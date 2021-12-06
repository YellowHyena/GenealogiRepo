﻿using GenealogiProject.Database;
using GenealogiProject.Models;

namespace GenealogiProject.Utils
{
    internal class CRUD
    {
        public static Person FindAnd(string action, string name, string lastName, int father, int mother)
        {
            action = action.ToLower();
            using (var db = new FamilyContext())
            {
                var person = db.People.FirstOrDefault(h => h.Name == name && h.LastName ==lastName);
                if (person == null && action == "add")
                {
                    Add(person, name, lastName, father, mother);
                }
                else if (person != null && action == "delete")
                {
                    Delete(person);
                }
                else if (person != null && action == "ask for names")
                {

                }
                else MenuHelper.PersonNotFound();
                return person;
            }
        }

        private static Person Add(Person person, string name, string lastName, int father, int mother)
        {
            using (var db = new FamilyContext())
            {
                person = new Person
                {
                    Name = name,
                    LastName = lastName,
                    Father = father,
                    Mother = mother
                };
                db.People.Add(person);
                db.SaveChanges();
            }
            return person;
        }

        private static void Delete(Person person)
        {
            if (MenuHelper.ConfirmMenu($"delete {person.Name} {person.LastName}") == false) return; //If you decline deletion, return.         
            using(var db = new FamilyContext())
            { 
                db.People.Remove(person);
                db.SaveChanges();
            }
        }

        internal static void SearchByName(string input)
        {
            input = input.ToLower();
            using (var db = new FamilyContext())
            {
                var persons = db.People.Where(p => p.Name.Contains(input) || p.LastName.Contains(input));
                if (persons == null) Box.Simple(new string[] { "No results." });
                else foreach (var person in persons)
                {
                    Console.WriteLine(person.Name + " " + person.LastName);
                }
                Menu.SearchOptionsMenu();
            }        
        }

        internal static string[] AskForNames()
        {
            string input = "";
            string[] split = new string[] { };
            string name = "";
            string lastName = "";

            do
            {
                Console.Clear();
                Box.Simple(new string[] 
                {"Write the name and last name of " +
                 "the person you want to search for " +
                 "separated by a space"});

                input = Console.ReadLine();
                split = input.Split(' ');
                name = split[0];
                lastName = split[1];

            } while (split.Length == 0);           
            return split;
        }
    }
}
