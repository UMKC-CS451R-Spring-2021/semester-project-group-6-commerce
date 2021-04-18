using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce_Bank.DataAccess.Model
{
    public class CommerceBankAppContext:DbContext
    {
        public CommerceBankAppContext(DbContextOptions<CommerceBankAppContext> options)
        : base(options)
        {
            //constructor injection
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //relationship among model
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(f => f.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<User> USER { get; set; }
        public DbSet<Person> PERSON { get; set; }
        public DbSet<Account_Type> ACCOUNT_TYPE { get; set; }
        public DbSet<Bank_Activity> BANK_ACTIVITY { get; set; }
        public DbSet<Last_Transaction> LAST_TRANSACTION { get; set; }
    }
}
