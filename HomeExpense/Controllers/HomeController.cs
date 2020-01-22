using HomeExpense.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using HomeExpense.DAL;
using HomeExpense.Models;

namespace HomeExpense.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext db = new HomeContext();
        public ActionResult Index()
        {
            Dashboard dash = new Dashboard();
            dash.Expenses = db.Expenses;
            dash.Categories = db.Categories;
            if (db.Categories.Any() && db.Expenses.Any())
            {
                Category cat = db.Categories.FirstOrDefault(m => m.Name.ToUpper().Contains("SAVING"));
                dash.TotalExpense = db.Expenses.Where(m => m.CategoryId != cat.Id).Sum(m => m.Price);
                dash.TotalSavings = db.Expenses.Where(m => m.CategoryId == cat.Id).Sum(m => m.Price);
                dash.TotalIncome = 0;//use income db
                dash.Expenses = db.Expenses;
            }
            return View(dash);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}