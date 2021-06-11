using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankDataAccessLibrary.Models;

namespace BankDataAccessLibrary
{
    public class PeopleData
    {
        private readonly ISqlDataAccess _db;

        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People";
        }
    }
}
