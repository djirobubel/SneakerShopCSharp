using MediatR;

namespace SneakerShop.Commands.CreateSneaker
{
    public class CreateSneakerCommand : IRequest<CreateSneakerResult>
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<int> SizeIds { get; set; }
    }
}
