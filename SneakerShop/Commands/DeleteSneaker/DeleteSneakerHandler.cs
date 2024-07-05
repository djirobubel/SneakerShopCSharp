using AutoMapper;
using MediatR;
using SneakerShop.Interface;

namespace SneakerShop.Commands.DeleteSneaker
{
    public class DeleteSneakerHandler : IRequestHandler<DeleteSneakerCommand, DeleteSneakerResult>
    {
        private readonly ISneakerRepository _sneakerRepository;
        private readonly IMapper _mapper;

        public DeleteSneakerHandler(ISneakerRepository sneakerRepository, IMapper mapper)
        {
            _sneakerRepository = sneakerRepository;
            _mapper = mapper;
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
