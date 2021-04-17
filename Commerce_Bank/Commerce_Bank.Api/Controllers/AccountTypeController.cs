using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce_Bank.DataAccess.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commerce_Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;
        
        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            //this is called contructor injection
            _accountTypeService = accountTypeService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _accountTypeService.GetAll();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _accountTypeService.GetById(id);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostAccountType(string AccountTypeName)
        {
            return Ok(await _accountTypeService.AddAccountType(AccountTypeName));
        }
    }
}