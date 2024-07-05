using MediatR;
using SneakerShop.Interface;

namespace SneakerShop.Commands.DeleteSneaker
{
    public class DeleteSneakerHandler : IRequestHandler<DeleteSneakerCommand, DeleteSneakerResult>
    {
        private readonly ISneakerRepository _sneakerRepository;

        public DeleteSneakerHandler(ISneakerRepository sneakerRepository)
        {
            _sneakerRepository = sneakerRepository;
        }

        public Task<DeleteSneakerResult> Handle(DeleteSneakerCommand request,
            CancellationToken cancellationToken)
        {
            var deletedSneaker = _sneakerRepository.GetSneaker(request.Id);
            var deletedSneakerSizes = _sneakerRepository.GetSneakerSizes(request.Id);

            _sneakerRepository.DeleteSneaker(deletedSneaker, deletedSneakerSizes);

            DeleteSneakerResult result = new DeleteSneakerResult
            { Message = "Successfully deleted." };

            return Task.FromResult(result);
        }
    }
}
