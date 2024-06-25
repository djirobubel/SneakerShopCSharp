using SneakerShop.Models;

namespace SneakerShop.Interface
{
    public interface ISizeRepository
    {
        ICollection<Size> GetSizes();
        ICollection<Size> GetSizesOfASneaker(int sneakerId);
        ICollection<SneakerSize> GetSneakerSizes(int sizeId);
        Size GetSize(int sizeId);
        bool SizeExists(int sizeId);
        bool CreateSize(Size size);
        bool UpdateSize(Size size);
        bool DeleteSize(Size size, ICollection<SneakerSize> sneakerSizes);
        bool Save();
    }
}
