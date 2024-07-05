using AutoMapper;
using MediatR;
using SneakerShop.Dto;
using SneakerShop.Interface;

namespace SneakerShop.Queries.GetAllSizes
{
    public class GetAllSizesHandler : IRequestHandler<GetAllSizesQuery, GetAllSizesResult>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public GetAllSizesHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public Task<GetAllSizesResult> Handle(GetAllSizesQuery request,
            CancellationToken cancellationToken)
        {
            var sizes = _sizeRepository.GetSizes();
            var sizesMap = _mapper.Map<List<SizeDto>>(sizes);

            GetAllSizesResult result = new GetAllSizesResult { Sizes = sizesMap };

            return Task.FromResult(result);
        }
    }
}
