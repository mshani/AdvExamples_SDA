namespace GameAPI.DataLayer.DTOs
{
    public class VideoGameDTO
    {
        public string? Name { get; set; }
        public int Size { get; set; }
        public string? Category { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? PublishingDate { get; set; }
    }
}
