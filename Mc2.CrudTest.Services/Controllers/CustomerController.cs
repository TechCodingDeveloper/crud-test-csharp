using Mc2.CrudTest.Domain.Contracts.Common;
using Mc2.CrudTest.Logics.Logics;
using Mc2.CrudTest.Storage.Database.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Services.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private DatabaseContext _context { get; set; }
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(DatabaseContext context, ILogger<CustomerController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetCustomer")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CustomerContract), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerContract>> GetCustomerById(long id)
        {
            return Ok(new CustomerLogic(_context).Get(id));
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MessageContract<CustomerContract>>> CreateCustomer([FromBody] CustomerRequestContract customerRequest)
        {
            var result = await new CustomerLogic(_context).AddCustomer(customerRequest.Convert());
            if (result.IsSucess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpPost("UpdateCustomer")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> UpdateCustomer([FromBody] CustomerUpdateRequestContract customerRequest)
        {
            var result = await new CustomerLogic(_context).UpdateCustomer(customerRequest.Convert());
            if (result.IsSucess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpDelete("DeleteCustomer")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> DeleteCustomerById(long id)
        {
            var result = await new CustomerLogic(_context).Delete(id);
            if (result.IsSucess)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpGet("GetCustomers")]
        [ProducesResponseType(typeof(MessageContract<List<CustomerContract>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MessageContract<List<CustomerContract>>>> GetCustomers()
        {
            return Ok(new CustomerLogic(_context).GetAll());
        }

    }
}
