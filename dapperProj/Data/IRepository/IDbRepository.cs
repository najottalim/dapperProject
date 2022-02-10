using dapperProj.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dapperProj.Data.IRepository
{
    internal interface IDbRepository
    {
        public Task CreateAsync(Person person);

        public Task DeleteAsync(long PersonId);

        public Task UpdateAsync(long PersonId, Person person);

        public IEnumerable<Person> GetAll();

        public Person Get(long PersonId);
    }
}
