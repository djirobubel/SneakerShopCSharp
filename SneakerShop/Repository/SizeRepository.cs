using SneakerShop.Data;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly DataContext _context;

        public SizeRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSize(Size size)
        {
            _context.Sizes.Add(size);
            return Save();
        }

        public bool DeleteSize(Size size, ICollection<SneakerSize> sneakerSizes)
        {
            _context.Sizes.Remove(size);
            _context.SneakerSizes.RemoveRange(sneakerSizes);
            return Save();
        }

        public Size GetSize(int sizeId)
        {
            return _context.Sizes.Where(s => s.Id == sizeId).FirstOrDefault();
        }

        public ICollection<Size> GetSizes()
        {
            return _context.Sizes.OrderBy(s => s.Id).ToList();
        }

        public ICollection<Size> GetSizesOfASneaker(int sneakerId)
        {
            return _context.SneakerSizes.Where(s => s.Sneaker.Id == sneakerId)
                .Select(s => s.Size).ToList();
        }

        public ICollection<SneakerSize> GetSneakerSizes(int sizeId)
        {
            return _context.SneakerSizes.Where(ss => ss.SizeId == sizeId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SizeExists(int sizeId)
        {
            return _context.Sizes.Any(s => s.Id == sizeId);
        }

        public bool UpdateSize(Size size)
        {
            _context.Update(size);
            return Save();
        }
    }
}
