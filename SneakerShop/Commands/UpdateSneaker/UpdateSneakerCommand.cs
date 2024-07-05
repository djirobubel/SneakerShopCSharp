using MediatR;

namespace SneakerShop.Commands.UpdateSneaker
{
    public class UpdateSneakerCommand : IRequest<UpdateSneakerResult>
    {
        public int UpdatedSneakerId { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
