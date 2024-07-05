using MediatR;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.CreateSize
{
    public class CreateSizeHandler : IRequestHandler<CreateSizeCommand, CreateSizeResult>
    {
        private readonly ISizeRepository _sizeRepository;

        public CreateSizeHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public Task<CreateSizeResult> Handle(CreateSizeCommand request,
            CancellationToken cancellationToken)
        {
            Size createdSize = new Size
            {
                Id = request.Id,
                UsSize = request.UsSize,
            };

            _sizeRepository.CreateSize(createdSize);

            CreateSizeResult result = new CreateSizeResult { Message = "Successfully created." };

            return Task.FromResult(result);
        }
    }
}
