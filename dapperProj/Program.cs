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

            //var passports = dapper.GetAllAsync<Passport>(query, cmdType: CommandType.Text).Result;

            //foreach (Passport passport in passports)
            //{
            //    Console.WriteLine(passport.SerialNumber);
            //}



            //var people = dapper.GetAllAsync<Person>(query, null, cmdType: CommandType.Text).Result;

            //foreach (Person person in people)
            //{
            //    Console.WriteLine(person.Name);
            //}


            //var students = dapper.GetAllAsync<Student>(query, null, cmdType: CommandType.StoredProcedure).Result;

            //foreach (Student student in students)
            //{
            //    Console.WriteLine(student);    
            //}

        }
    }
}
