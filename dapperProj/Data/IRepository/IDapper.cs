using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dapperProj.Data.IRepository
{
    internal interface IDapper : IDisposable
    {
        Task<int> DeleteAsync(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text);
        Task<int> UpdateAsync(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text);
        Task<int> CreateAsync(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text);
        Task<T> GetAsync<T>(string query, DynamicParameters pars = null, CommandType cmdType = CommandType.Text);
        Task<IEnumerable<T>> GetAllAsync<T>(string query, DynamicParameters par = null, CommandType cmdType = CommandType.Text);
    }
}
