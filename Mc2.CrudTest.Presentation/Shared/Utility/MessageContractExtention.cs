using Mc2.CrudTest.Shared.Contracts;
using System;

namespace Mc2.CrudTest.Shared.Utility
{
    public static class MessageContractExtention
    {
        public static MessageContract<T> ToContract<T>(this T result)
        {
            return new MessageContract<T>()
            {
                Result = result,
                IsSucess = true
            };
        }


        public static MessageContract<T> ToErrorContract<T>(this Exception error)
        {
            return new MessageContract<T>()
            {
                Result = default(T),
                ErrorMessage = error.Message,
                ErrorDetail = error.InnerException.ToString(),
                IsSucess = false
            };
        }


    }
}
