using MediatR;

namespace SneakerShop.Commands.UpdateSize
{
    public class UpdateSizeCommand : IRequest<UpdateSizeResult>
    {
        public int UpdatedSizeId { get; set; }
        public string UsSize { get; set; }
    }
}
