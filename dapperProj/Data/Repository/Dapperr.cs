using Dapper;
using dapperProj.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dapperProj.Data.Repository
{
    internal class Dapperr : IDapper
    {
        private static IDbConnection db;

        public Dapperr()
        {
            db = new SqlConnection(Constants.CONNECTION_STRING);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual async Task CreateAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            await db.QueryAsync<T>(query, param: pars, commandType: cmdType);
        }

        public async Task UpdateAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            await db.QueryAsync<T>(query, param: pars, commandType: cmdType);
        }

        public async Task DeleteAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            await db.QueryAsync<T>(query, param: pars, commandType: cmdType);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            return await db.QueryAsync<T>(query, param: pars, commandType: cmdType);
        }

        public async Task<T> GetAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            return (await GetAllAsync<T>(query, pars, cmdType)).FirstOrDefault();
        }

    }
}
