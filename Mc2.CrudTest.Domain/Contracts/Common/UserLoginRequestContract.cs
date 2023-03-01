using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Contracts.Common
{
    public class UserLoginRequestContract
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
