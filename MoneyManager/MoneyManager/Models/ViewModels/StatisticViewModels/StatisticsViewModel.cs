namespace MoneyManager.Models.ViewModels.StatisticViewModels;

public class StatisticsViewModel
{
    public int TotalExpense { get; set; }
    public int CurrentYearExpense { get; set; }
    public int CurrentMonthExpense { get; set; }
    public int CurrentWeekExpense { get; set; }
    public IEnumerable<Tuple<string, int>> ExpenseByExpenseType { get; set; }

    public int TotalIncome { get; set; }
    public int CurrentYearIncome { get; set; }
    public int CurrentMonthIncome { get; set; }
    public int CurrentWeekIncome { get; set; }
    public IEnumerable<Tuple<string, int>> IncomeByIncomeType { get; set; }
}
