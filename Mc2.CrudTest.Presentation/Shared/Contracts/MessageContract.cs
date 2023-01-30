using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Contracts
{
    public class MessageContract<T>
    {
        public T? Result { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }
        public bool IsSucess { get; set; }

        public bool IsData()
        {
            if (IsSucess && Result != null)
                return true;
            else
                return false;
        }
    }
}
