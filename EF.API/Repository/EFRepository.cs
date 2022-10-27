using EF.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.API.Repository
{
    public class EFRepository : IEFRepository
    {
        private readonly BooksDBContext _dbContext;

        public EFRepository(BooksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateDiscount(Offer coupon)
        {
            // var discount = await _dbContext.Offers.AddAsync(coupon);
            // await _dbContext.SaveChangesAsync();


            var discount = await _dbContext.Database.ExecuteSqlInterpolatedAsync($"exec InsertBooks @Amount ={coupon.Amount} ,@BookName={coupon.BookName},@Description={coupon.Description}");

            return discount;

        }
        public async Task<bool> UpdateDiscount(Offer coupon)
        {
           var discount = await _dbContext.Database.ExecuteSqlInterpolatedAsync($"exec UpdateBooks @Id ={coupon.Id}, @Amount ={coupon.Amount} ,@BookName={coupon.BookName},@Description={coupon.Description}");
            if (discount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteDiscount(int Id)
        {
            var discount = await _dbContext.Database.ExecuteSqlRawAsync("exec DeleteBookById {0}", Id);
            if (discount ==0)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Offer>> GetDiscount(string BookName)
        {
            var discount = await _dbContext.Offers.FromSqlRaw("exec GetBooksByBookName {0}", BookName).ToListAsync();
            return discount;
        }
    }
}
