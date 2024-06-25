namespace SneakerShop.Models
{
    public class Sneaker
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<SneakerSize> SneakerSizes { get; set; }
    }
}
