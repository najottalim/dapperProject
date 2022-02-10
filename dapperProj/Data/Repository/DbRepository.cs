using dapperProj.Data.IRepository;
using dapperProj.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace dapperProj.Data.Repository
{
    internal class DbRepository
    {
        private IDapper db = new Dapperr();
        public async Task CreateAsync(Person person)
        {
            string query = $"INSERT INTO Passports (SerialNumber) VALUES ('{person.passport.SerialNumber}')";

            await db.CreateAsync<Passport>(query, cmdType: CommandType.Text);

            query = $"SELECT id FROM Passports WHERE SerialNumber = '{person.passport.SerialNumber}'";

            var passId = db.GetAllAsync<int>(query, cmdType: CommandType.Text).Result.FirstOrDefault();


            query = $"INSERT INTO People (name, PassId) VALUES ('{person.Name}', {passId})";

            await db.CreateAsync<Person>(query, cmdType: CommandType.Text);
        }

        public void DeleteAsync(long PersonId)
        {

        }

        public void UpdateAsync(long PersonId, Person person)
        {

        }

        public List<Person> GetAllAsync()
        {
            string query = $"SELECT * FROM Passports";

            var passports = db.GetAllAsync<Passport>(query, cmdType: CommandType.Text).Result;


            query = $"SELECT Id, Name, PassId FROM People";

            var people = db.GetAllAsync<(long Id, string Name, int PassId)>(query, cmdType: CommandType.Text).Result;

            var result = new List<Person>();

            foreach (var item in people)
            {
                var buff = passports.FirstOrDefault(p => p.Id == item.PassId);

                result.Add(new Person()
                {
                    Id = item.Id,
                    Name = item.Name,
                    passport = buff
                });
            }

            return result;
        }

        public Person GetAsync(long PersonId)
        {
            return GetAllAsync().FirstOrDefault(p => p.Id == PersonId);
        }

    }
}
