namespace CarParts.UI.Models
{
    public class CategoryListResponseModel
    {
        public Guid Id { get; set; }
        

        public string? Definition { get; set; }
        public string? Image { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int? Parent { get; set; }
    }
}
