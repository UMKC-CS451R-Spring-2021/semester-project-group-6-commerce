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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //public async Task<IActionResult> GetAllUser()
        //{
        //    //the clients queries the api, the method referes to the service for the queried record,
        //    //which is then sent back to the client as response.
        //    var response=await _userService.GetAll();
        //    return Ok(response);
        //}
    }
}