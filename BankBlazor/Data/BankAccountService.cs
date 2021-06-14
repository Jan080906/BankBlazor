using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BankBlazor.Data.Models;
using BankDataAccessLibrary;
using BankDataAccessLibrary.Models;
using IbanNet;
using IbanNet.Builders;
using IbanNet.Registry;

namespace BankBlazor.Data
{
    public class BankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private IBankAccountBuilder _bankAccountBuilder;

        public BankAccountService(IBankAccountRepository bankAccountRepository
            , IBankAccountBuilder bankAccountBuilder)
        { 
            _bankAccountRepository = bankAccountRepository;
            _bankAccountBuilder = new IbanBuilder(); 
        }

        public async Task<BankAccounts> CreateAccount(CreateBankAccountInputModel createBankAccountInput)
        {
            List<BankAccounts> accounts = await _bankAccountRepository.GetAccounts();

            BankAccounts lastCreatedAccount = accounts.OrderByDescending(a => a.CreatedWhen).FirstOrDefault();

            int accountNo = lastCreatedAccount == null ? 1 : Int16.Parse(lastCreatedAccount.AccountNo) + 1;

            //_bankAccountBuilder = new IbanBuilder();

            _bankAccountBuilder.WithCountry("NL", IbanRegistry.Default)
                                .WithBankAccountNumber(accountNo.ToString())
                                .WithBankIdentifier("BLAZ");

            BankAccounts input = new BankAccounts()
            {
                AccountNo = String.Format("{0:0000000000}", accountNo),
                Name = createBankAccountInput.Name,
                Address = createBankAccountInput.Address,
                PhoneNo = createBankAccountInput.PhoneNo,
                DateOfBirth = createBankAccountInput.DateOfBirth,
                Amount = 0,
                IBAN = _bankAccountBuilder.Build(),
                CreatedWhen = DateTime.UtcNow,
                LastModifiedWhen = DateTime.UtcNow
            };

           await _bankAccountRepository.AddAccount(input);

            return input;
        }

        public async Task Deposit(DepositInputModel depositInput)
        {

            BankAccounts account = await _bankAccountRepository.GetAccountByAccountNo(depositInput.AccountNo);

            if(account == null)
            {
                throw new Exception($"Account with account number {depositInput.AccountNo} is not exist");
            }

            account.Amount += (depositInput.Amount * (decimal)0.99);

            await _bankAccountRepository.UpdateAccountAmount(account.Amount, account.AccountNo);
        }

        public async Task Transfer(TransferMoneyInputModel transferMoneyInput)
        {

            BankAccounts fromAccount = await _bankAccountRepository.GetAccountByAccountNo(transferMoneyInput.FromAccountNumber);
            BankAccounts toAccount = await _bankAccountRepository.GetAccountByAccountNo(transferMoneyInput.ToAccountNumber);

            if (fromAccount == null)
            {
                throw new Exception($"Origin account with account number {fromAccount.AccountNo} is not exist");
            }

            if (fromAccount == null)
            {
                throw new Exception($"Target account with account number {toAccount.AccountNo} is not exist");
            }

            fromAccount.Amount = fromAccount.Amount - transferMoneyInput.Amount;

            await _bankAccountRepository.UpdateAccountAmount(fromAccount.Amount, fromAccount.AccountNo);

            toAccount.Amount = toAccount.Amount + transferMoneyInput.Amount;

            await _bankAccountRepository.UpdateAccountAmount(toAccount.Amount, toAccount.AccountNo);
        }

        public async Task<List<BankAccounts>> GetAccounts()
        {
            return await _bankAccountRepository.GetAccounts();
        }
    } 
}
