﻿using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce_Bank.DataAccess.Services
{
   
    public class PersonService : RepositoryService<Person>, IPersonService
    {
        public PersonService(CommerceBankAppContext context)
           : base(context)
        {

        }
    }
}
