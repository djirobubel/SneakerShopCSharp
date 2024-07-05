using MediatR;

namespace SneakerShop.Commands.DeleteSneaker
{
    public class DeleteSneakerCommand : IRequest<DeleteSneakerResult>
    {
        public int Id { get; set; }

        public DeleteSneakerCommand(int id)
        {
            Id = id;
        }
    }
}
