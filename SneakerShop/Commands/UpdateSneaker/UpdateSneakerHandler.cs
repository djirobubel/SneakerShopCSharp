using MediatR;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Commands.UpdateSneaker
{
    public class UpdateSneakerHandler : IRequestHandler<UpdateSneakerCommand, UpdateSneakerResult>
    {
        private readonly ISneakerRepository _sneakerRepository;

        public UpdateSneakerHandler(ISneakerRepository sneakerRepository)
        {
            _sneakerRepository = sneakerRepository;
        }

        public Task<UpdateSneakerResult> Handle(UpdateSneakerCommand request,
            CancellationToken cancellationToken)
        {
            Sneaker updatedSneaker = new Sneaker
            {
                Id = request.UpdatedSneakerId,
                Model = request.Model,
                Price = request.Price,
                Description = request.Description
            };

            _sneakerRepository.UpdateSneaker(updatedSneaker);

            UpdateSneakerResult result = new UpdateSneakerResult
            { Message = "Succesfully updated." };

            return Task.FromResult(result);
        }
    }
}
