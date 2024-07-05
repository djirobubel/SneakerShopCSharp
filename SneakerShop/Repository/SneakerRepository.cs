using SneakerShop.Data;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Repository
{
    public class SneakerRepository : ISneakerRepository
    {
        private readonly DataContext _context;

        public SneakerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSneaker(Sneaker sneaker, List<int> sizeIds)
        {
            foreach (int sizeId in sizeIds)
            {
                var size = _context.Sizes.Where(s => s.Id == sizeId).FirstOrDefault();

                var sneakerSize = new SneakerSize()
                {
                    Size = size,
                    Sneaker = sneaker,
                };

                _context.SneakerSizes.Add(sneakerSize);
            }

            _context.Sneakers.Add(sneaker);
            return Save();
        }

        public bool DeleteSneaker(Sneaker sneaker, ICollection<SneakerSize> sneakerSizes)
        {
            _context.Sneakers.Remove(sneaker);
            _context.SneakerSizes.RemoveRange(sneakerSizes);
            return Save();
        }

        public Sneaker GetSneaker(int sneakerId)
        {
            return _context.Sneakers.Where(s => s.Id == sneakerId).FirstOrDefault();
        }

        public ICollection<Sneaker> GetSneakers()
        {
            return _context.Sneakers.OrderBy(s => s.Id).ToList();
        }

        public ICollection<SneakerSize> GetSneakerSizes(int sneakerId)
        {
            return _context.SneakerSizes.Where(ss => ss.SneakerId == sneakerId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SneakerExists(int sneakerId)
        {
            return _context.Sneakers.Any(s => s.Id == sneakerId);
        }

        public bool UpdateSneaker(Sneaker sneaker)
        {
            _context.Update(sneaker);
            return Save();
        }
    }
}
