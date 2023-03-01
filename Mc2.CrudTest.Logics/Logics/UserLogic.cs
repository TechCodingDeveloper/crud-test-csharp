using Mc2.CrudTest.Domain.Contracts.Common;
using Mc2.CrudTest.Shared.Contracts;
using Mc2.CrudTest.Shared.Utility;
using Mc2.CrudTest.Storage.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Logics.Logics
{
    public class UserLogic
    {
        private DatabaseContext DatabaseContext { get; set; }
        public UserLogic(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        public async Task<MessageContract<long>> AddUser(UserContract user)
        {
            try
            {
                var result = await DatabaseContext.Users.AddAsync(user.Convert());

                await DatabaseContext.SaveChangesAsync();

                return result.Entity.Id.ToContract();
            }
            catch (Exception ex)
            {
                return ex.ToErrorContract<long>();
            }
        }
        public async Task<MessageContract<long>> UpdateUser(UserContract user)
        {
            try
            {
                var customerResult = await Get(user.Id.Value);

                if (customerResult.IsData())
                {
                    var result = DatabaseContext.Users.Update(user.Convert());

                    await DatabaseContext.SaveChangesAsync();

                    return result.Entity.Id.ToContract();
                }
                else
                {
                    return new MessageContract<long>() { IsSucess = false, ErrorMessage = "Not Find Data" };
                }
            }
            catch (Exception ex)
            {
                return ex.ToErrorContract<long>();
            }
        }
        public async Task<MessageContract<long>> Delete(long Id)
        {
            try
            {
                var customerResult = await Get(Id);

                if (customerResult.IsData())
                {
                    var result = DatabaseContext.Users.Remove(customerResult.Result.Convert());

                    await DatabaseContext.SaveChangesAsync();

                    return result.Entity.Id.ToContract();
                }
                else
                {
                    return new MessageContract<long>() { IsSucess = false, ErrorMessage = "Not Find Data" };
                }
            }
            catch (Exception ex)
            {
                return ex.ToErrorContract<long>();
            }
        }
        public async Task<MessageContract<UserContract>> Get(long Id)
        {
            var result = await DatabaseContext.Users.AsNoTracking().FirstOrDefaultAsync(dr => dr.Id == Id);

            return UserContract.ConvertContract(result).ToContract();
        }
        public async Task<MessageContract<List<UserContract>>> GetAll()
        {
            var result = await DatabaseContext.Users.AsNoTracking().Select(dr => UserContract.ConvertContract(dr)).ToListAsync();
            return result.ToContract();
        }

        public async Task<MessageContract<UserContract>> IsUser(UserLoginRequestContract userLoginRequest)
        {
            return new MessageContract<UserContract>()
            {
                IsSucess =true,
                Result = new UserContract()
                {
                    UserName = "Mohammadreza",
                    Password = "Mohammadreza"
                }
            };
        }

    }
}
