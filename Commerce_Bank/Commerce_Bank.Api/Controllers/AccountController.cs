using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce_Bank.Api.Model;
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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserBankTransactions(int personId)
        {
            var response = await _accountService.GetAccountTransactionBy(personId);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserBalance(int personId)
        {
            var response = await _accountService.GetUserCurentAccountBalance(personId);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAccountHolderDetails()
        {
            var response = await _accountService.GetAllAccountHolderDetail();
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewAccount(BankUserDTO bankUserDTO)
        {
            var response = await _accountService.CreateBankUsers(bankUserDTO);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var response = await _accountService.Login(loginModel.username, loginModel.password);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> BankTrasaction(TrasactionDTO trasactionDTO)
        {
            var response = await _accountService.BankUserTransaction(trasactionDTO);
            return Ok(response);
        }
       
    }
}