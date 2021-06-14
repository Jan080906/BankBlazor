using System.Collections.Generic;
using System.Threading.Tasks;
using BankDataAccessLibrary.Models;

namespace BankBlazor.Data
{
    public interface IBankAccountRepository
    {
        Task<BankAccounts> GetAccountByAccountNo(string accountNo);
        Task<List<BankAccounts>> GetAccounts();
        Task AddAccount(BankAccounts acccount);
        Task UpdateAccountAmount(decimal amount, string accountNo);
    }
}