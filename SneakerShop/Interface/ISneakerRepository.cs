using SneakerShop.Models;

namespace SneakerShop.Interface
{
    public interface ISneakerRepository
    {
        ICollection<Sneaker> GetSneakers();
        ICollection<SneakerSize> GetSneakerSizes(int sneakerId);
        Sneaker GetSneaker(int sneakerId);
        bool SneakerExists(int sneakerId);
        bool CreateSneaker(Sneaker sneaker, List<int> sizeIds);
        bool UpdateSneaker(Sneaker sneaker);
        bool DeleteSneaker(Sneaker sneaker, ICollection<SneakerSize> sneakerSizes);
        bool Save();
    }
}
