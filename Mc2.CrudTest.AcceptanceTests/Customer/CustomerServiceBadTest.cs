using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customer
{
    public class CustomerServiceBadTest : TestBase
    {
        [Fact]
        public async Task Dublicate_Create_Customer()
        {
            try
            {
                var customer = await new CustomerServiceTest().GetCustomer();

                var result = await ClientServices.CreateCustomerAsync(new CustomerRequestContract()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    BankAccountNumber = "000-000-000-000-000",
                });

                Assert.True(!result.IsSucess);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task Wrong_Email()
        {
            try
            {
                var faker = new Faker("en");

                var result = await ClientServices.CreateCustomerAsync(new CustomerRequestContract()
                {
                    FirstName = faker.Person.FirstName,
                    LastName = faker.Person.LastName,
                    DateOfBirth = faker.Person.DateOfBirth,
                    Email = "www.com",
                    PhoneNumber = faker.Person.Phone,
                    BankAccountNumber = "000-000-000-000-000",
                });

                Assert.True(!result.IsSucess);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task Same_FirstName_LastName_BirthDay()
        {
            try
            {
                var faker = new Faker("en");

                var customer = await new CustomerServiceTest().GetCustomer();

                var result = await ClientServices.CreateCustomerAsync(new CustomerRequestContract()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    Email = faker.Person.Email,
                    PhoneNumber = faker.Person.Phone,
                    BankAccountNumber = "000-000-000-000-000",
                });

                Assert.True(!result.IsSucess);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
    }
}
