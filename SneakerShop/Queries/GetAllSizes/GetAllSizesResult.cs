using SneakerShop.Dto;

namespace SneakerShop.Queries.GetAllSizes
{
    public class GetAllSizesResult
    {
        public ICollection<SizeDto> Sizes { get; set; }
    }
}
