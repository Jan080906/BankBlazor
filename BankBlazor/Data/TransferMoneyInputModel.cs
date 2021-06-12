using System;
namespace BankBlazor.Data
{
    public class TransferMoneyInputModel
    {
        public string FromAccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
