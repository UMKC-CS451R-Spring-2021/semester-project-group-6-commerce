using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce_Bank.DataAccess.Model.DTO;
using Commerce_Bank.DataAccess.Services;
using Commerce_Bank.DataAccess.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commerce_Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //this called tight coupling. the time taken to instantiate this class is too enormous, it better that we user injection
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewAccount(BankUserDTO bankUserDTO)
        {
            var response = await _accountService.CreateBankUsers(bankUserDTO);
            return Ok(response);
        }
    }
}