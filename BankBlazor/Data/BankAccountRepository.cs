using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankBlazor.Data.Models;
using BankDataAccessLibrary;
using BankDataAccessLibrary.Models;
using Dapper;

namespace BankBlazor.Data
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ISqliteDataAccess _sqliteDataAccess;

        public BankAccountRepository(ISqliteDataAccess sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess;
        }

        public async Task AddAccount(BankAccounts acccount)
        {
            string sqlStatement = "insert into BankAccounts (AccountNo ,Name, Address, PhoneNo, DateOfBirth, IBAN, Amount, CreatedWhen, LastModifiedWhen) " +
                     "values (@AccountNo ,@Name, @Address, @PhoneNo, @DateOfBirth, @IBAN, @Amount, @CreatedWhen, @LastModifiedWhen)";

            await _sqliteDataAccess.SaveData<BankAccounts>(sqlStatement, acccount);
        }

        public async Task UpdateAccountAmount(decimal amount, string accountNo)
        {
            string sqlStatement = "update BankAccounts set Amount = @amount where AccountNo = @accountNo";

            await _sqliteDataAccess.SaveData<dynamic>(sqlStatement, new { amount, accountNo });
        }

        public async Task<List<BankAccounts>> GetAccounts()
        {
            string sqlStatement = "select * from BankAccounts";

            List<BankAccounts> bankAccounts = await _sqliteDataAccess.LoadData<BankAccounts, dynamic>(sqlStatement, new { });

            return bankAccounts;
        }

        public async Task<BankAccounts> GetAccountByAccountNo(string accountNo)
        {
            string sqlStatement = "select * from BankAccounts where AccountNo = @accountNo";

            List<BankAccounts> bankAccounts = await _sqliteDataAccess.LoadData<BankAccounts, dynamic>(sqlStatement, new { accountNo });

            return bankAccounts.FirstOrDefault();
        }
    }
}
