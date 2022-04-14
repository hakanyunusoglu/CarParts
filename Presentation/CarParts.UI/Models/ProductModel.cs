namespace CarParts.UI.Models
{
    public class ProductModel
    {
        public Guid? Id { get; set; }


        public string? Name { get; set; }
        public decimal? Price{ get; set; }
        public int? Stok{ get; set; }
        public string? Barkod { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public string? Slug { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Description { get; set; }
     }
}
