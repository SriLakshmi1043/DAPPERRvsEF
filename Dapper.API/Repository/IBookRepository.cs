using Dapper.API.Entity;

namespace Dapper.API.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<OfferBooks>> GetDiscount(string BookName);
        Task<bool> CreateDiscount(OfferBooks coupon);
        
        Task<bool> DeleteDiscount(int Id);
    }
}
