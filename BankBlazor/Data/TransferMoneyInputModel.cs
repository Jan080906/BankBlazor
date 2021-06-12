using System;
namespace BankBlazor.Data
{
    public class TransferMoneyInputModel
    {
        public int FromAccountNumber { get; set; }
        public int ToAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
