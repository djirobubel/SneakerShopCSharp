using AutoMapper;
using MediatR;
using SneakerShop.Dto;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.CreateSize
{
    public class CreateSizeHandler : IRequestHandler<CreateSizeCommand, CreateSizeResult>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public CreateSizeHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public Task<CreateSizeResult> Handle(CreateSizeCommand request,
            CancellationToken cancellationToken)
        {
            CreateSizeCommand size = new CreateSizeCommand
            {
                Id = request.Id,
                UsSize = request.UsSize
            };

            SizeDto sizeDto = new SizeDto
            {
                Id = size.Id,
                UsSize = size.UsSize,
            };

            var createdSize = _mapper.Map<Size>(sizeDto);
            _sizeRepository.CreateSize(createdSize);

            CreateSizeResult result = new CreateSizeResult { Message = "Successfully created." };

            return Task.FromResult(result);
        }
    }
}
