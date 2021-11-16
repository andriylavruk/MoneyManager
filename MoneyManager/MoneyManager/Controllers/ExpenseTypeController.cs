using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models;
using MoneyManager.Repositories.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Models.ViewModels;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ExpenseType> expenseTypes = await _expenseTypeService.GetAllExpenseTypesAsync();
            return View(expenseTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseTypeViewModel expenseTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _expenseTypeService.AddExpenseTypeViewModelAsync(expenseTypeViewModel);
                return RedirectToAction("Index");
            }
            return View(expenseTypeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expenseTypeViewModel = await _expenseTypeService.GetExpenseTypeViewModelByIdAsync(id);

            if (expenseTypeViewModel == null)
            {
                return NotFound();
            }

            return View(expenseTypeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(ExpenseTypeViewModel expenseTypeViewModel)
        {
            if (expenseTypeViewModel == null)
            {
                return NotFound();
            }

            var expenseTypeViewModelDelete = await _expenseTypeService.GetExpenseTypeViewModelByIdAsync(expenseTypeViewModel.Id);

            if (expenseTypeViewModelDelete == null)
            {
                return NotFound();
            }

            await _expenseTypeService.RemoveExpenseTypeViewModelAsync(expenseTypeViewModelDelete);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expenseTypeViewModel = await _expenseTypeService.GetExpenseTypeViewModelByIdAsync(id);

            if (expenseTypeViewModel == null)
            {
                return NotFound();
            }

            return View(expenseTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ExpenseTypeViewModel expenseTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _expenseTypeService.UpdateExpenseTypeViewModelAsync(expenseTypeViewModel);

                return RedirectToAction("Index");
            }
            return View(expenseTypeViewModel);
        }
    }
}