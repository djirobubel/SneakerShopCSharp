using AutoMapper;
using MediatR;
using SneakerShop.Dto;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.UpdateSneaker
{
    public class UpdateSneakerHandler : IRequestHandler<UpdateSneakerCommand, UpdateSneakerResult>
    {
        private readonly ISneakerRepository _sneakerRepository;
        private readonly IMapper _mapper;

        public UpdateSneakerHandler(ISneakerRepository sneakerRepository, IMapper mapper)
        {
            _sneakerRepository = sneakerRepository;
            _mapper = mapper;
        }

        public Task<UpdateSneakerResult> Handle(UpdateSneakerCommand request,
            CancellationToken cancellationToken)
        {
            UpdateSneakerCommand sneakerCommand = new UpdateSneakerCommand
            {
                UpdatedSneakerId = request.UpdatedSneakerId,
                Model = request.Model,
                Price = request.Price,
                Description = request.Description
            };

            SneakerDto sneaker = new SneakerDto
            {
                Id = sneakerCommand.UpdatedSneakerId,
                Model = sneakerCommand.Model,
                Price = sneakerCommand.Price,
                Description = sneakerCommand.Description
            };

            var updatedSneaker = _mapper.Map<Sneaker>(sneaker);

            _sneakerRepository.UpdateSneaker(updatedSneaker);

            UpdateSneakerResult result = new UpdateSneakerResult
            { Message = "Succesfully updated." };

            return Task.FromResult(result);
        }
    }
}
