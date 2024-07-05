using AutoMapper;
using MediatR;
using SneakerShop.Interface;

namespace SneakerShop.Commands.DeleteSize
{
    public class DeleteSizeHandler : IRequestHandler<DeleteSizeCommand, DeleteSizeResult>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public DeleteSizeHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public Task<DeleteSizeResult> Handle(DeleteSizeCommand request,
            CancellationToken cancellationToken)
        {
            var deletedSize = _sizeRepository.GetSize(request.Id);
            var deletedSneakerSizes = _sizeRepository.GetSneakerSizes(request.Id);

            _sizeRepository.DeleteSize(deletedSize, deletedSneakerSizes);

            DeleteSizeResult result = new DeleteSizeResult { Message = "Successfully deleted." };

            return Task.FromResult(result);
        }
    }
}
