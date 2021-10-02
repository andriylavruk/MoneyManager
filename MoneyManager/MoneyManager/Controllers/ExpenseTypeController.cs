using Microsoft.AspNetCore.Mvc;
using MoneyManager.Data;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> expenseTypes = _db.ExpenseTypes;
            return View(expenseTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(expenseType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }

        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expenseType = _db.ExpenseTypes.Find(id);

            if (expenseType == null)
            {
                return NotFound();
            }

            return View(expenseType);
        }

        //Post Delete
        public IActionResult DeletePost(int? id)
        {
            var expenseType = _db.ExpenseTypes.Find(id);

            if (expenseType == null)
            {
                return NotFound();
            }

            _db.ExpenseTypes.Remove(expenseType);
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

            var expenseType = _db.ExpenseTypes.Find(id);

            if (expenseType == null)
            {
                return NotFound();
            }

            return View(expenseType);
        }

        //Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(expenseType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }
    }
}
