using dapperProj.Data.Repository;
using dapperProj.Models;
using System;

namespace dapperProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbRepository db = new();

            Person persons = new() { Name = "Me", passport = new Passport() { SerialNumber = "7854" } };

            db.CreateAsync(persons).Wait();


            foreach (var person in db.GetAll())
            {
                Console.WriteLine(person.Name + " " + person.passport.SerialNumber);
            }

        }
    }
}
