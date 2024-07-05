using MediatR;

namespace SneakerShop.Commands.DeleteSize
{
    public class DeleteSizeCommand : IRequest<DeleteSizeResult>
    {
        public int Id { get; set; }
    }
}
