using Mc2.CrudTest.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Storage.Database.Entities
{
    public class CustomerEntity : IDateTime
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
