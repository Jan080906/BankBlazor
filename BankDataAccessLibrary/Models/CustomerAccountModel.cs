using System;
namespace BankDataAccessLibrary.Models
{
    public class CustomerAccountModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string IBAN { get; set; }
        public decimal Amount { get; set; }
        public string CreatedWhen { get; set; }
        public string LastModifiedWhen { get; set; }

    }
}
