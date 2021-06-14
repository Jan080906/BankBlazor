using System.Collections.Generic;
using System.Threading.Tasks;
using BankDataAccessLibrary.Models;

namespace BankDataAccessLibrary
{
    public interface ISqliteDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}