using System;
using System.ComponentModel.DataAnnotations;

namespace BankBlazor.Data.Models
{
    public class DepositInputModel
    {
        [Required]
        public string AccountNo { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
