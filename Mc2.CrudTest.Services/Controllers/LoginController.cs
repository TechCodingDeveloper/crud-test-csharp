using Mc2.CrudTest.Domain.Contracts.Common;
using Mc2.CrudTest.Logics.Logics;
using Mc2.CrudTest.Shared.Contracts;
using Mc2.CrudTest.Storage.Database.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class LoginController : ControllerBase
    {

        private DatabaseContext _context { get; set; }
        private IConfiguration _configuration;
        public LoginController(DatabaseContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException();

        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MessageContract<CustomerContract>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MessageContract<string>>> Login([FromBody] UserLoginRequestContract userRequest)
        {
            var resut = await new UserLogic(_context).IsUser(userRequest);

            if (resut.IsSucess)
            {
                return new JWTAuthManagerLogic(_configuration).GenerateJWT(resut.Result);
            }
            else
            {
                return null;
            }
        }

        [HttpPost("ValidationToken")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MessageContract<CustomerContract>), (int)HttpStatusCode.OK)]
        public ActionResult<MessageContract<bool>> ValidationToken([FromBody] TokenValidatiionContract tokenValidation)
        {
            return new JWTAuthManagerLogic(_configuration).IsTokenValidation(tokenValidation);
        }

    }
}
