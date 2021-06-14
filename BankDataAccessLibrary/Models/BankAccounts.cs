using System;

namespace BankDataAccessLibrary.Models
{
    public class BankAccounts
    {
        
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IBAN { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedWhen { get; set; }
        public DateTime LastModifiedWhen { get; set; }
    }
}
