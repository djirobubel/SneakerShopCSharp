using MediatR;

namespace SneakerShop.Queries.GetSneakerById
{
    public class GetSneakerByIdQuery : IRequest<GetSneakerByIdResult>
    {
        public int Id { get; set; }

        public GetSneakerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
