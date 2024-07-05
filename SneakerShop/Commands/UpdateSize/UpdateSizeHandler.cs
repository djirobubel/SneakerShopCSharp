using MediatR;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.UpdateSize
{
    public class UpdateSizeHandler : IRequestHandler<UpdateSizeCommand, UpdateSizeResult>
    {
        private readonly ISizeRepository _sizeRepository;

        public UpdateSizeHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public Task<UpdateSizeResult> Handle(UpdateSizeCommand request,
            CancellationToken cancellationToken)
        {
            Size updatedSize = new Size
            {
                Id = request.UpdatedSizeId,
                UsSize = request.UsSize
            };

            _sizeRepository.UpdateSize(updatedSize);

            UpdateSizeResult result = new UpdateSizeResult { Message = "Successfully updated." };

            return Task.FromResult(result);
        }
    }
}
