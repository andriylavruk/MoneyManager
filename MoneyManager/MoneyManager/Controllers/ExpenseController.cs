using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Repositories.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService)
        {
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _expenseService.GetAllExpensesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ExpenseViewModel expenseViewModel = new ExpenseViewModel()
            {
                TypeDropDown = await _expenseTypeService.GetExpenseTypesSelectListItemAsync(),
                TotalExpense = await _expenseService.GetTotalExpenseAsync(),
                CurrentMonthExpense = await _expenseService.GetCurrentMonthExpenseAsync()
            };

            return View(expenseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (ExpenseViewModel expenseViewModel)
        {
            if (ModelState.IsValid)
            {
                await _expenseService.AddExpenseViewModelAsync(expenseViewModel);

                return RedirectToAction("Index");
            }
            return View(expenseViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expenseViewModel = await _expenseService.GetExpenseViewModelByIdAsync(id);
            expenseViewModel.TypeDropDown = await _expenseTypeService.GetExpenseTypesSelectListItemAsync();

            if (expenseViewModel == null)
            {
                return NotFound();
            }

            return View(expenseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ExpenseViewModel expenseViewModel)
        {
            if (expenseViewModel == null)
            {
                return NotFound();
            }

            var expenseViewModelDelete = await _expenseService.GetExpenseViewModelByIdAsync(expenseViewModel.Id);

            if (expenseViewModelDelete == null)
            {
                return NotFound();
            }

            await _expenseService.RemoveExpenseViewModelAsync(expenseViewModelDelete);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expenseViewModel = await _expenseService.GetExpenseViewModelByIdAsync(id);
            expenseViewModel.TypeDropDown = await _expenseTypeService.GetExpenseTypesSelectListItemAsync();

            if (expenseViewModel == null)
            {
                return NotFound();
            }

            return View(expenseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ExpenseViewModel expenseViewModel)
        {
            if (ModelState.IsValid)
            {
                await _expenseService.UpdateExpenseViewModelAsync(expenseViewModel);

                return RedirectToAction("Index");
            }
            return  View(expenseViewModel);
        }
    }
}