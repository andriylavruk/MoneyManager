using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Helpers;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class IncomeTypeController : Controller
    {
        private readonly IIncomeTypeService _incomeTypeService;

        public IncomeTypeController(IIncomeTypeService incomeTypeService)
        {
            _incomeTypeService = incomeTypeService;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var incomeTypes = await _incomeTypeService.GetAllIncomeTypesAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                incomeTypes = await _incomeTypeService.SearchIncomeTypeAsync(searchString);
            }

            switch (sortOrder)
            {
                case "name":
                    incomeTypes = incomeTypes.OrderBy(s => s.Name);
                    break;
                default:
                    incomeTypes = incomeTypes.OrderByDescending(s => s.Name);
                    break;
            }

            int pageSize = 8;
            return View(await PaginatedList<IncomeType>.CreateAsync(incomeTypes, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncomeTypeViewModel incomeTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _incomeTypeService.AddIncomeTypeViewModelAsync(incomeTypeViewModel);
                return RedirectToAction("Index");
            }
            return View(incomeTypeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var incomeTypeViewModel = await _incomeTypeService.GetIncomeTypeViewModelByIdAsync(id);

            if (incomeTypeViewModel == null)
            {
                return NotFound();
            }

            return View(incomeTypeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(IncomeTypeViewModel incomeTypeViewModel)
        {
            if (incomeTypeViewModel == null)
            {
                return NotFound();
            }

            var incomeTypeViewModelDelete = await _incomeTypeService.GetIncomeTypeViewModelByIdAsync(incomeTypeViewModel.Id);

            if (incomeTypeViewModelDelete == null)
            {
                return NotFound();
            }

            await _incomeTypeService.RemoveIncomeTypeViewModelAsync(incomeTypeViewModelDelete);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var incomeTypeViewModel = await _incomeTypeService.GetIncomeTypeViewModelByIdAsync(id);

            if (incomeTypeViewModel == null)
            {
                return NotFound();
            }

            return View(incomeTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(IncomeTypeViewModel incomeTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _incomeTypeService.UpdateIncomeTypeViewModelAsync(incomeTypeViewModel);

                return RedirectToAction("Index");
            }
            return View(incomeTypeViewModel);
        }
    }
}