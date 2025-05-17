namespace GameAPI.DataLayer.Filters
{
    public class VideoGameFilter
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? SizeMin { get; set; }
        public int? SizeMax { get; set; }
        public string? Category { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? PublishingDate { get; set; }
    }
}
