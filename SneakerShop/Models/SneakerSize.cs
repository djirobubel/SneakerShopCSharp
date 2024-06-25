namespace SneakerShop.Models
{
    public class SneakerSize
    {
        public int SneakerId { get; set; }
        public int SizeId { get; set; }
        public Sneaker Sneaker { get; set; }
        public Size Size { get; set; }
    }
}
