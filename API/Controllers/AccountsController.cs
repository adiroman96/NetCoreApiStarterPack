using API.Dtos.Account;
using API.Services;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly DataContext _dataContext;
        private readonly IBaseService<Account> _accountService;
        private readonly IMapper _mapper;

        public AccountsController(
            DataContext dataContext,
            IBaseService<Account> accountService, 
            IMapper mapper
            )
        {
            _dataContext = dataContext;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult RegisterAsync(RegisterRequest model)
        {
            
            return Ok("acc");
        }
    }
}
