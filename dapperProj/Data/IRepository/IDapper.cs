using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dapperProj.Data.IRepository
{
    internal interface IDapper : IDisposable
    {
        Task DeleteAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure);
        Task UpdateAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure);
        Task CreateAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure);
        Task<T> GetAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetAllAsync<T>(string query, DynamicParameters par = null, CommandType cmdType = CommandType.StoredProcedure);
    }
}
