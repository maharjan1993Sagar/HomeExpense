using HomeExpense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeExpense.ViewModel
{
    public class Dashboard
    {
        public decimal TotalExpense { get; set; }   
        public decimal TotalSavings { get; set; }
        public decimal TotalIncome { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<string> Months { get; set; } = new string[]{
            "बैशाख","जेठ","असार","श्रावण","भदौ","अशोज","कार्तिक","मंसिर","पुष","माघ","फाल्गुन","चैत्र"
        }.AsEnumerable();

    }
}