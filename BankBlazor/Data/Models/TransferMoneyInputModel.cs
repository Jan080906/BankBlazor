using System;
using System.ComponentModel.DataAnnotations;

namespace BankBlazor.Data
{
    public class TransferMoneyInputModel
    {
        [Required]
        public string FromAccountNumber { get; set; }

        [Required]
        public string ToAccountNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
