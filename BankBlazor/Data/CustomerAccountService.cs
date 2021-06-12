using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BankDataAccessLibrary;
using BankDataAccessLibrary.Models;
using IbanNet;
using IbanNet.Builders;
using IbanNet.Registry;

namespace BankBlazor.Data
{
    public class CustomerAccountService
    {
        private IBankAccountBuilder _bankAccountBuilder;

        public CustomerAccountService(IBankAccountBuilder bankAccountBuilder)
        {
            _bankAccountBuilder = bankAccountBuilder;
        }
         
        public void IbanClassTest()
        {
            List<string> bankAccountList = new List<string>();
            _bankAccountBuilder = new IbanBuilder();

            for (int i = 0; i < 10; i++)
            {
                _bankAccountBuilder.WithCountry("NL",IbanRegistry.Default)
                                    .WithBankAccountNumber("041716")
                                    .WithBankIdentifier("TEST");
                bankAccountList.Add(_bankAccountBuilder.Build());
            }
        }
    } 
}
