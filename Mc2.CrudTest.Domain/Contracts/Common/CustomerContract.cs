using Mc2.CrudTest.Storage.Database.Entities;
using System;

namespace Mc2.CrudTest.Domain.Contracts.Common
{
    public class CustomerContract
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public CustomerEntity Convert()
        {
            return new CustomerEntity()
            {
                Id = Id.HasValue ? Id.Value : default(long),
                LastName = LastName,
                FirstName = FirstName,
                Email = Email,
                BankAccountNumber = BankAccountNumber,
                CreationDateTime = DateTime.Now,
                DateOfBirth = DateOfBirth,
                ModificationDateTime = DateTime.Now,
                PhoneNumber = PhoneNumber,
            };
        }

        public static CustomerContract ConvertContract(CustomerEntity customerEntity)
        {
            if (customerEntity is null)
                return null;

            return new CustomerContract()
            {
                Id = customerEntity.Id,
                LastName = customerEntity.LastName,
                FirstName = customerEntity.FirstName,
                Email = customerEntity.Email,
                BankAccountNumber = customerEntity.BankAccountNumber,
                DateOfBirth = customerEntity.DateOfBirth,
                PhoneNumber = customerEntity.PhoneNumber,
            };
        }
    }
}
