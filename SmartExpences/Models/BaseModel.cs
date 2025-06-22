namespace SmartExpenses.Models
{
    public abstract class BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
