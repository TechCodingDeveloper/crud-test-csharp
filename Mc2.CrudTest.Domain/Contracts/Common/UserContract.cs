using Mc2.CrudTest.Storage.Database.Entities;
using System;

namespace Mc2.CrudTest.Domain.Contracts.Common
{
    public class UserContract
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserEntity Convert()
        {
            return new UserEntity()
            {
                Id = Id.HasValue ? Id.Value : default(long),
                LastName = LastName,
                FirstName = FirstName,
                UserName = UserName,
                Password = Password,
            };
        }

        public static UserContract ConvertContract(UserEntity user)
        {
            if (user is null)
                return null;

            return new UserContract()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                UserName = user.UserName,
                Password = user.Password,
            };
        }
    }
}
