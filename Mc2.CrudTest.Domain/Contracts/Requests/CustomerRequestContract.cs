using Mc2.CrudTest.Domain.Contracts.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Contracts.Requests
{
    public class CustomerRequestContract
    {
        [Required]
        [MaxLength(450)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(450)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Phone]
        [MaxLength(32)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string BankAccountNumber { get; set; }

        public CustomerContract Convert()
        {
            return new CustomerContract()
            {
                BankAccountNumber = BankAccountNumber,
                DateOfBirth = DateOfBirth,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
            };
        }

    }
}
