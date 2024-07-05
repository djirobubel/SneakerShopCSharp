using SneakerShop.Dto;

namespace SneakerShop.Queries.GetSneakerById
{
    public class GetSneakerByIdResult
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<SizeDto> Sizes { get; set; }
        public bool Stock { get; set; }
    }
}
