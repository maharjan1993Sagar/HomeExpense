using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeExpense.DAL;
using HomeExpense.Models;
using HomeExpense.ViewModel;

namespace HomeExpense.Controllers
{
    public class ExpensesController : Controller
    {
        private HomeContext db = new HomeContext();

        // GET: Expenses
        public ActionResult Index()
        {
            var expenses = db.Expenses.Include(e => e.Category);
            return View(expenses.ToList());
        }

        // GET: Expenses/Details/5
        public ActionResult Details()
        {
            List<CategoryExpense> cat = (from p in db.Expenses
                                         group p by p.CategoryId into g
                                         select new CategoryExpense {
                                             CategoryId = g.Key,
                                             Expenses = g.Select(m => m).ToList(),
                                             
                                         }).ToList();
            cat[0].Categories = db.Categories;
            return View(cat);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            Expense exp = new Expense();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View(exp);
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                string MIndex = expense.NepaliDate.Split(new string[] { "-" }, 3, StringSplitOptions.None)[1];
                expense.MonthIndex = Convert.ToInt32(MIndex);
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                string MIndex = expense.NepaliDate.Split(new string[] { "-" }, 3, StringSplitOptions.None)[1];
                expense.MonthIndex = Convert.ToInt32(MIndex);
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
