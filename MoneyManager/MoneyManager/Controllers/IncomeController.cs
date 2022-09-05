using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Helpers;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels.ExpenseViewModels;
using MoneyManager.Models.ViewModels.IncomeViewModels;
using MoneyManager.Services.Interfaces;

namespace MoneyManager.Controllers;

[Authorize]
public class IncomeController : Controller
{
    private readonly IIncomeService _incomeService;
    private readonly IIncomeTypeService _incomeTypeService;

    public IncomeController(IIncomeService incomeService, IIncomeTypeService incomeTypeService)
    {
        _incomeService = incomeService;
        _incomeTypeService = incomeTypeService;
    }

    public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
    {
        ViewData["CurrentSort"] = sortOrder;
        ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date" : "";
        ViewBag.AmountSortParm = sortOrder == "amount" ? "amount_desc" : "amount";
        ViewBag.IncomeTypeSortParm = sortOrder == "incomeType" ? "incomeType_desc" : "incomeType";

        if (searchString != null)
        {
            pageNumber = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        ViewData["CurrentFilter"] = searchString;

        var incomes = await _incomeService.GetAllIncomesAsync();

        if (!String.IsNullOrEmpty(searchString))
        {
            incomes = await _incomeService.SearchIncomeAsync(searchString);
        }

        switch (sortOrder)
        {
            case "date":
                incomes = incomes.OrderBy(s => s.DateCreated);
                break;
            case "amount":
                incomes = incomes.OrderBy(s => s.Amount);
                break;
            case "amount_desc":
                incomes = incomes.OrderByDescending(s => s.Amount);
                break;
            case "incomeType":
                incomes = incomes.OrderBy(s => s.IncomeType.Name);
                break;
            case "incomeType_desc":
                incomes = incomes.OrderByDescending(s => s.IncomeType.Name);
                break;
            default:
                incomes = incomes.OrderByDescending(s => s.DateCreated);
                break;
        }

        int pageSize = 8;
        return View(await PaginatedList<Income>.CreateAsync(incomes, pageNumber ?? 1, pageSize)); ;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        IncomeViewModel incomeViewModel = new IncomeViewModel()
        {
            TypeDropDown = await _incomeTypeService.GetIncomeTypesSelectListItemAsync()
        };

        return View(incomeViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IncomeViewModel incomeViewModel)
    {
        if (ModelState.IsValid)
        {
            await _incomeService.AddIncomeViewModelAsync(incomeViewModel);

            return RedirectToAction("Index");
        }

        incomeViewModel.TypeDropDown = await _incomeTypeService.GetIncomeTypesSelectListItemAsync();

        return View(incomeViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var incomeViewModel = await _incomeService.GetIncomeViewModelByIdAsync(id);

        if (incomeViewModel == null)
        {
            return NotFound();
        }

        incomeViewModel.TypeDropDown = await _incomeTypeService.GetIncomeTypesSelectListItemAsync();

        if (incomeViewModel == null)
        {
            return NotFound();
        }

        return View(incomeViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(IncomeViewModel incomeViewModel)
    {
        if (incomeViewModel == null)
        {
            return NotFound();
        }

        var incomeViewModelDelete = await _incomeService.GetIncomeViewModelByIdAsync(incomeViewModel.Id);

        if (incomeViewModelDelete == null)
        {
            return NotFound();
        }

        await _incomeService.RemoveIncomeViewModelAsync(incomeViewModelDelete);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var incomeViewModel = await _incomeService.GetIncomeViewModelByIdAsync(id);

        if (incomeViewModel == null)
        {
            return NotFound();
        }

        incomeViewModel.TypeDropDown = await _incomeTypeService.GetIncomeTypesSelectListItemAsync();

        if (incomeViewModel == null)
        {
            return NotFound();
        }

        return View(incomeViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(IncomeViewModel incomeViewModel)
    {
        if (ModelState.IsValid)
        {
            await _incomeService.UpdateIncomeViewModelAsync(incomeViewModel);

            return RedirectToAction("Index");
        }

        incomeViewModel.TypeDropDown = await _incomeTypeService.GetIncomeTypesSelectListItemAsync();

        return View(incomeViewModel);
    }
}
