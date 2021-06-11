using System;
namespace BankDataAccessLibrary.Models
{
    public class CustomerAccountModel
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string IBAN { get; set; }
    }
}
