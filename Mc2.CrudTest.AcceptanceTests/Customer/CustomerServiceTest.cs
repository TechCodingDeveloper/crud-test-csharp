using Bogus;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customer
{
    public class CustomerServiceTest : TestBase
    {
        [Fact]
        public async void GetCustomers()
        {
            var result = await ClientServices.GetCustomersAsync();
            Assert.True(result.IsSucess);
        }

        [Fact]
        public async Task<long> CreateCustomer()
        {
            var faker = new Faker("en");
            var result = await ClientServices.CreateCustomerAsync(new CustomerRequestContract()
            {
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                DateOfBirth = faker.Person.DateOfBirth,
                Email = faker.Person.Email,
                PhoneNumber = faker.Person.Phone,
                BankAccountNumber = "000-000-000-000-000",
            });

            Assert.True(result.IsSucess);

            return result.Result;
        }

        [Fact]
        public async Task<CustomerContract> GetCustomer()
        {
            var customerId = await CreateCustomer();

            var result= await ClientServices.GetCustomerAsync(customerId);  

            Assert.True(result.IsSucess);

            return result.Result;
        }

        [Fact]
        public async Task<long> DeleteCustomer()
        {
            var customer = await GetCustomer();

            var result = await ClientServices.DeleteCustomerAsync(customer.Id);

            Assert.True(result.IsSucess);

            return result.Result;
        }

        [Fact]
        public async Task<long> UpdateCustomer()
        {
            var customer = await GetCustomer();
            var faker = new Faker("en");

            var result = await ClientServices.UpdateCustomerAsync(new CustomerUpdateRequestContract()
            {
                Id = customer.Id.Value,
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                DateOfBirth = faker.Person.DateOfBirth,
                Email = faker.Person.Email,
                PhoneNumber = faker.Person.Phone,
                BankAccountNumber = "000-000-000-000-000",
            });

            Assert.True(result.IsSucess);

            return result.Result;
        }

    }
}
