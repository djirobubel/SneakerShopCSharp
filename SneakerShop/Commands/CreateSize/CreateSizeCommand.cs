using MediatR;

namespace SneakerShop.Commands.CreateSize
{
    public class CreateSizeCommand : IRequest<CreateSizeResult>
    {
        public int Id { get; set; }
        public string UsSize { get; set; }
    }
}
