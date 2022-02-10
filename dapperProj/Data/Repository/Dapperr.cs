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

        public async Task<int> CreateAsync(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text)
        {
            return await db.ExecuteAsync(query, param: pars, commandType: cmdType);
        }

        public async Task<int> UpdateAsync(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text)
        {
            return await db.ExecuteAsync(query, param: pars, commandType: cmdType);
        }

        public async Task<int> DeleteAsync(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text)
        {
            return await db.ExecuteAsync(query, param: pars, commandType: cmdType);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text)
        {
            return await db.QueryAsync<T>(query, param: pars, commandType: cmdType);
        }

        public async Task<T> GetAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text)
        {
            return (await GetAllAsync<T>(query, pars, cmdType)).FirstOrDefault();
        }

    }
}
