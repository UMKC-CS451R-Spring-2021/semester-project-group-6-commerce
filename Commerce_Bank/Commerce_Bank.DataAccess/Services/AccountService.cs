using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Model.DTO;
using Commerce_Bank.DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly IPersonService _personService;
        private readonly IBankActivityService _bankActivityService;
        private readonly ILastTransactionService _lastTransactionService;
        private readonly IMailService _mailService;
        //contructor injection(Dependency injection)
        public AccountService(IUserService userService, IPersonService personService,
            IBankActivityService bankActivityService,ILastTransactionService lastTransactionService,IMailService mailService)
        {
            _userService = userService;
            _personService = personService;
            _bankActivityService = bankActivityService;
            _lastTransactionService = lastTransactionService;
            _mailService = mailService;
        }

        public async Task<bool> BankUserTransaction(TrasactionDTO trasactionDTO)
        {
           return await _bankActivityService.BankUserTransaction(trasactionDTO);
        }

        public async Task<bool> CreateBankUsers(BankUserDTO bankUserDTO)
        {
            //User user
            //Check if username exist
            var isUserExist=await _userService.GetBy(f => f.Username == bankUserDTO.UserName);
            if (isUserExist?.Id > 0)
                throw new Exception("Username Already exist");
            Person person = new Person()
            {
                //mapping user entered field to the database table
                AccountNo = bankUserDTO.AccountNo,
                Account_TypeId = bankUserDTO.Account_Type_Id,
                Firstname = bankUserDTO.FirstName,
                Lastname = bankUserDTO.LastName,
                IsActive = true,
                PhoneNo = bankUserDTO.PhoneNo
            };
            var personCreated=await _personService.Save(person);
            if (personCreated > 0)
            {
                User user = new User()
                {
                    Password = bankUserDTO.Password,
                    PersonId = person.Id,
                    Username = bankUserDTO.UserName
                };
                var userCreated = await _userService.Save(user);
                if (userCreated > 0)
                {
                    Bank_Activity bank_Activity = new Bank_Activity()
                    {
                        Balance = bankUserDTO.InitialDeposit,
                        Description = "Opening account deposit",
                        IsDeposit = true,
                        IsOpeningBalance = true,
                        PersonId = person.Id,
                        TrasactionAmount = bankUserDTO.InitialDeposit,
                        TransactionDate=DateTime.Now

                    };
                    var created = await _bankActivityService.Save(bank_Activity);
                    if (created > 0)
                    {
                        Last_Transaction last_Transaction = new Last_Transaction()
                        {
                            Balance = bankUserDTO.InitialDeposit,
                            DateCreated = DateTime.Now,
                            PersonId = person.Id
                        };
                        await _lastTransactionService.Save(last_Transaction);
                    }
                    return true;
                }
                
            }
            return false;
            
        }

        public async Task<bool> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
           return await  _userService.ForgotPassword(forgotPasswordDTO);
        }

        public async Task<IEnumerable<TrasactionDisplayDTO>> GetAccountTransactionBy(int PersonId)
        {
            return await _bankActivityService.GetAccountTransactionBy(PersonId);
        }

        public async Task<IEnumerable<DisplayAccountHolderDetailDTO>> GetAllAccountHolderDetail()
        {
            return await _lastTransactionService.GetAllAccountHolderDetail();
        }

        public async Task<decimal> GetUserCurentAccountBalance(int PersonId)
        {
            return await _lastTransactionService.GetUserCurentAccountBalance(PersonId);
        }

        public async Task<UserLoginDTO> Login(string username, string password)
        {
            try
            {
                var user = await _userService.GetUserBy(username, password);
                if (user == null)
                    throw new Exception("User not exist");
                UserLoginDTO userLoginDTO = new UserLoginDTO()
                {
                    Fullname = $"{user.Person.Firstname} {user.Person.Lastname}",
                    AccountNumber = user.Person.AccountNo,
                    UserId = user.Id,
                    Username = user.Username,
                    PersonId = user.PersonId
                };
                return userLoginDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
                
        }
    }
}
