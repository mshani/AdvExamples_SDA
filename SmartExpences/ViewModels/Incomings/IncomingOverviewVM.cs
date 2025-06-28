using SmartExpenses.Models;

namespace SmartExpenses.ViewModels.Incomings
{
    public class IncomingOverviewVM
    {
        public List<Incoming>? Incomings { get; set; }
        public List<Category>? Categories { get; set; }
        public Category? SelectedCategory { get; set; }
    }
}
