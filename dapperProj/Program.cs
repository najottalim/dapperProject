using dapperProj.Data.Repository;
using dapperProj.Models;
using System;

namespace dapperProj
{
    internal class Program
    {
        public static string GenerateName()
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };

            string Name = "";

            Name += consonants[r.Next(consonants.Length)].ToUpper();

            int b = 1;
            while (b++ < 7)
            {
                Name += consonants[r.Next(consonants.Length)];
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
        static void Main(string[] args)
        {
            DbRepository db = new();

            Person person = new() { Name = GenerateName(), passport = new Passport() { SerialNumber = Guid.NewGuid().ToString() } };

            //db.CreateAsync(persons).Wait();
            //db.UpdateAsync(1, person).Wait();
            db.DeleteAsync(1).Wait();

            foreach (var p in db.GetAll())
            {
                Console.WriteLine($"{p.Id}. {p.Name} -> {p.passport.SerialNumber}");
            }

        }
    }
}
