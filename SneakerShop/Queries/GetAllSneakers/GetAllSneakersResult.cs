using SneakerShop.Dto;

namespace SneakerShop.Queries.GetAllSneakers
{
    public class GetAllSneakersResult
    {
        public ICollection<SneakerDto> Sneakers { get; set; }
    }
}
