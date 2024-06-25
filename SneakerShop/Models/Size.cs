namespace SneakerShop.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string UsSize { get; set; }
        public ICollection<SneakerSize> SneakerSizes { get; set; }
    }
}
