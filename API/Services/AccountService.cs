using API.Services.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class AccountService : BaseService<Account>, IAccountServices
    {
        public AccountService(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> UsernameExists(string username)
        {
            username = username.ToTrimmedLowerCase();
            return (await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Username == username && x.StatusCode != (int)StatusCode.Terminated)) != null;
        }

        public async Task<bool> EmailExists(string email)
        {
            email = email.ToTrimmedLowerCase();
            return (await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Email == email && x.StatusCode != (int)StatusCode.Terminated)) != null;
        }

    }
}
