using HomeExpense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeExpense.ViewModel
{
    public class CategoryExpense
    {
        public List<Expense> Expenses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Month { get; set; }
        public int MonthIndex { get; set; } = 0;
    }
}