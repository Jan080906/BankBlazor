using System;
using System.ComponentModel.DataAnnotations;

namespace BankBlazor.Data.Models
{
    public class CreateBankAccountInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int PhoneNo { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
