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

    }
}
