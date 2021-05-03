using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Commerce_Bank.Screen.Models;
using Commerce_Bank.Screen.ScreenServices.ScreenInterface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using static Commerce_Bank.Screen.Controllers.Message;
using Microsoft.AspNetCore.Authorization;
using Commerce_Bank.Screen.Models.ViewModel;

namespace Commerce_Bank.Screen.Controllers
{
    public class HomeController : WebBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScreenAccountService _screenAccountService;
        private readonly AccountViewModel accountViewModel;
        //contructor injection
        public HomeController(ILogger<HomeController> logger, IScreenAccountService screenAccountService)
        {
            _logger = logger;
            _screenAccountService = screenAccountService;
            accountViewModel = new AccountViewModel();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    LoginModel loginModel = new LoginModel()
                    {
                        password = password,
                        username = username
                    };
                    var result = await _screenAccountService.LoginUser(loginModel);
                    if (result != null)
                    {
                        var identity = new ClaimsIdentity(new[] {
                         //new Claim(ClaimTypes.Name, result..FullName),
                         new Claim(ClaimTypes.Email, result.Username),
                         new Claim(ClaimTypes.Sid, result.PersonId.ToString()),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return RedirectToAction("Dashboard", "Home");
                    }
                    Alert("Username or Password not correct", NotificationType.info);
                    return RedirectToAction("index");

                }
                
            }
            catch (Exception ex)
            {

                Alert(ex.Message, NotificationType.info);
            }
            return RedirectToAction("index");

        }
        //[Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");


        }
        public async Task<IActionResult> Transactions()
        {

            string personIdString = User.FindFirstValue(ClaimTypes.Sid);
            int personId = Convert.ToInt32(personIdString);
            accountViewModel.Trasactions= (await _screenAccountService.GetUserBankTransactions(personId)).ToList();
            return View(accountViewModel);
        }
        public  ActionResult AddTransaction()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTransaction(string transactionDescription, decimal transactionAmount, string transactionType)
        {
            string personIdString = User.FindFirstValue(ClaimTypes.Sid);
            int personId = Convert.ToInt32(personIdString);
            bool type = transactionType == "DR" ? false : true;
            TransactionModel transactionModel = new TransactionModel()
            {
                Description = transactionDescription,
                TransactionAmount = transactionAmount,
                TransactionType = type,
                PersonId = personId
            };
            var response=await _screenAccountService.AddTransaction(transactionModel);
            if (response)
                return RedirectToAction("Transactions");
            return View();
        }
    }
}
