using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace SmartExpenses.Models.Enums
{
    public enum CategoryTypeEnum
    {
        [Display(Name = "Expense")]
        Expense = 1,

        [Display(Name = "Incoming")]
        Incoming = 2,
    }
}
