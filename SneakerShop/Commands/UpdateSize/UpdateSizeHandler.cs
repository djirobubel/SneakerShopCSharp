using AutoMapper;
using MediatR;
using SneakerShop.Dto;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.UpdateSize
{
    public class UpdateSizeHandler : IRequestHandler<UpdateSizeCommand, UpdateSizeResult>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public UpdateSizeHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public Task<UpdateSizeResult> Handle(UpdateSizeCommand request,
            CancellationToken cancellationToken)
        {
            UpdateSizeCommand sizeCommand = new UpdateSizeCommand
            {
                UpdatedSizeId = request.UpdatedSizeId,
                UsSize = request.UsSize
            };

            SizeDto size = new SizeDto
            {
                Id = sizeCommand.UpdatedSizeId,
                UsSize = sizeCommand.UsSize
            };

            var updatedSize = _mapper.Map<Size>(size);
            _sizeRepository.UpdateSize(updatedSize);

            UpdateSizeResult result = new UpdateSizeResult { Message = "Successfully updated." };

            return Task.FromResult(result);

        }
    }
}
