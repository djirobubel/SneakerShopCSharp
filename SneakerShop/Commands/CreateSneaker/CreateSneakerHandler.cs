using AutoMapper;
using MediatR;
using SneakerShop.Dto;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.CreateSneaker
{
    public class CreateSneakerHandler : IRequestHandler<CreateSneakerCommand, CreateSneakerResult>
    {
        private readonly ISneakerRepository _sneakerRepository;
        private readonly IMapper _mapper;

        public CreateSneakerHandler(ISneakerRepository sneakerRepository, IMapper mapper)
        {
            _sneakerRepository = sneakerRepository;
            _mapper = mapper;
        }
        public Task<CreateSneakerResult> Handle(CreateSneakerCommand request,
            CancellationToken cancellationToken)
        {
            SneakerDto sneaker = new SneakerDto
            {
                Id = request.Id,
                Model = request.Model,
                Price = request.Price,
                Description = request.Description
            };

            var sizes = request.SizeIds;

            var createdSneaker = _mapper.Map<Sneaker>(sneaker);
            _sneakerRepository.CreateSneaker(createdSneaker, sizes);

            CreateSneakerResult result = new CreateSneakerResult
            { Message = "Successfully created." };

            return Task.FromResult(result);
        }
    }
}
