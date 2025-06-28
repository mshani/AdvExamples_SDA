using Microsoft.AspNetCore.Mvc.Rendering;
using SmartExpenses.Models;

namespace SmartExpenses.ViewModels.Expenses
{
    public class ExpensesOverviewVM
    {
        public List<Expense>? Expenses { get; set; }
        public IEnumerable<SelectListItem>? CategoryListItems { get; set; }
        public Category? SelectedCategory { get; set; }
    }
}