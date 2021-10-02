using Microsoft.AspNetCore.Mvc;
using MoneyManager.Data;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expenses = _db.Expenses;
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expense = _db.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        //Post Delete
        public IActionResult DeletePost(int? id)
        {
            var expense = _db.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(expense);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        //Get Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expense = _db.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        //Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }
    }
}
