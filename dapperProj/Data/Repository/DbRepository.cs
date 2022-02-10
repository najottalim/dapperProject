using dapperProj.Data.IRepository;
using dapperProj.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace dapperProj.Data.Repository
{
    internal class DbRepository : IDbRepository
    {
        private readonly IDapper db = new Dapperr();

        public async Task CreateAsync(Person person)
        {
            #region Insert Passports
            string query = $"INSERT INTO Passports (SerialNumber) VALUES ('{person.passport.SerialNumber}')";

            await db.CreateAsync(query);
            #endregion

            #region Select From Passports
            query = $"SELECT id FROM Passports WHERE SerialNumber = '{person.passport.SerialNumber}'";

            var passId = db.GetAllAsync<long>(query).Result.FirstOrDefault();
            #endregion

            #region Insert People
            query = $"INSERT INTO People (name, PassId) VALUES ('{person.Name}', {passId})";

            await db.CreateAsync(query);
            #endregion
        }

        public async Task DeleteAsync(long personId)
        {
            var person = Get(personId);

            #region Delete People Query
            string query = $"DELETE FROM People WHERE id = {personId}";

            await db.DeleteAsync(query);
            #endregion
            
            
            #region Delete People Query
            query = $"DELETE FROM Passports WHERE id = {person.passport.Id}";

            await db.DeleteAsync(query);
            #endregion

        }

        public async Task UpdateAsync(long personId, Person newPerson)
        {
            var oldPerson = Get(personId);

            #region Update People
            string query = $"UPDATE People SET " +
                $"Name = '{newPerson.Name}' " +
                $"WHERE id = {personId}";
            #endregion

            await db.UpdateAsync(query);

            #region Update Passports
            query = $"UPDATE Passports SET " +
                $"SerialNumber = '{newPerson.passport.SerialNumber}' " +
                $"WHERE Id = {oldPerson.passport.Id}";
            #endregion

            await db.UpdateAsync(query);

        }

        public IEnumerable<Person> GetAll()
        {
            #region Select Passports Query
            string query = $"SELECT * FROM Passports";

            var passports = db.GetAllAsync<Passport>(query).Result;
            #endregion


            #region Select People Query
            query = $"SELECT * FROM People";
            
            var people = db.GetAllAsync<(long Id, string Name, int PassId)>(query).Result;
            #endregion


            #region Creating People objects
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
            #endregion

            return result;
        }

        public Person Get(long personId)
        {
            return GetAll().FirstOrDefault(p => p.Id == personId);
        }

    }
}
