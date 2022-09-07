namespace Ejercicio.DTO
{
    public class ProductData
    {
        public int id { get; set; }
        public string? title { get; set; }
        public float price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public RatingData rating { get; set; }

    }
}
