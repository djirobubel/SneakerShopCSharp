using MediatR;
using SneakerShop.Dto;
using SneakerShop.Interface;
using AutoMapper;

namespace SneakerShop.Queries.GetAllSneakers
{
    public class GetAllSneakersHandler : IRequestHandler<GetAllSneakersQuery, GetAllSneakersResult>
    {
        private readonly ISneakerRepository _sneakerRepository;
        private readonly IMapper _mapper;

        public GetAllSneakersHandler(ISneakerRepository sneakerRepository, IMapper mapper)
        {
            _sneakerRepository = sneakerRepository;
            _mapper = mapper;
        }

        public Task<GetAllSneakersResult> Handle(GetAllSneakersQuery request,
            CancellationToken cancellationToken)
        {
            var sneakers = _sneakerRepository.GetSneakers();
            var result = _mapper.Map<List<SneakerDto>>(sneakers);

            GetAllSneakersResult getAllSneakersResult = new GetAllSneakersResult
            { Sneakers = result };

            return Task.FromResult(getAllSneakersResult);
        }
    }
}