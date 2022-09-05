using AutoMapper;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels.ExpenseViewModels;
using MoneyManager.Models.ViewModels.IncomeViewModels;
using MoneyManager.Models.ViewModels.ExpenseTypeViewModels;
using MoneyManager.Models.ViewModels.IncomeTypeViewModels;

namespace MoneyManager.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, ExpenseViewModel>().ReverseMap();
            CreateMap<Income, IncomeViewModel>().ReverseMap();
            CreateMap<ExpenseType, ExpenseTypeViewModel>().ReverseMap();
            CreateMap<IncomeType, IncomeTypeViewModel>().ReverseMap();
        }
    }
}
