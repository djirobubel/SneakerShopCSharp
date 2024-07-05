using AutoMapper;
using MediatR;
using SneakerShop.Dto;
using SneakerShop.Interface;

namespace SneakerShop.Queries.GetSneakerById
{
    public class GetSneakerByIdHandler : IRequestHandler<GetSneakerByIdQuery, GetSneakerByIdResult>
    {
        private readonly ISneakerRepository _sneakerRepository;
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;

        public GetSneakerByIdHandler(ISneakerRepository sneakerRepository, IMapper mapper,
            ISizeRepository sizeRepository)
        {
            _sneakerRepository = sneakerRepository;
            _mapper = mapper;
            _sizeRepository = sizeRepository;
        }

        public Task<GetSneakerByIdResult> Handle(GetSneakerByIdQuery request,
            CancellationToken cancellationToken)
        {
            if(!_sneakerRepository.SneakerExists(request.Id))
            {
                GetSneakerByIdResult outOfStock = new GetSneakerByIdResult
                {
                    Stock = false
                };

                return Task.FromResult(outOfStock);
            }

            var sneaker = _sneakerRepository.GetSneaker(request.Id);
            var sizes = _sizeRepository.GetSizesOfASneaker(request.Id);
            var sizesMap = _mapper.Map<List<SizeDto>>(sizes);

            GetSneakerByIdResult result = new GetSneakerByIdResult
            {
                Id = sneaker.Id,
                Model = sneaker.Model,
                Price = sneaker.Price,
                Description = sneaker.Description,
                Sizes = sizesMap,
                Stock = true
            };

            return Task.FromResult(result);
        }
    }
}
