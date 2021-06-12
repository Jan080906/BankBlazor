﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankDataAccessLibrary;
using BankDataAccessLibrary.Models;
using IbanNet;
using IbanNet.Builders;

namespace BankBlazor.Data
{
    public class CustomerAccountService
    {
        public static List<CustomerAccountModel> LoadAccount()
        {
            return SqliteDataAccess.LoadAccounts();
        }
    }
}
