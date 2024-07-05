using MediatR;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.CreateSneaker
{
    public class CreateSneakerHandler : IRequestHandler<CreateSneakerCommand, CreateSneakerResult>
    {
        private readonly ISneakerRepository _sneakerRepository;

        public CreateSneakerHandler(ISneakerRepository sneakerRepository)
        {
            _sneakerRepository = sneakerRepository;
        }
        public Task<CreateSneakerResult> Handle(CreateSneakerCommand request,
            CancellationToken cancellationToken)
        {
            Sneaker createdSneaker = new Sneaker
            {
                Id = request.Id,
                Model = request.Model,
                Price = request.Price,
                Description = request.Description
            };

            var sizes = request.SizeIds;

            _sneakerRepository.CreateSneaker(createdSneaker, sizes);

            CreateSneakerResult result = new CreateSneakerResult
            { Message = "Successfully created." };

            return Task.FromResult(result);
        }
    }
}
