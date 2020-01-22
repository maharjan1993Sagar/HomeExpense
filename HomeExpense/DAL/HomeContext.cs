using HomeExpense.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeExpense.DAL
{
    public class HomeContext:DbContext
    {
        public HomeContext() : base("DefaultConnection")
        {

        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}