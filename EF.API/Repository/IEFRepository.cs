using EF.API.Models;

namespace EF.API.Repository
{
    public interface IEFRepository
    {
        Task<IEnumerable<Offer>> GetDiscount(string BookName);
        Task<int> CreateDiscount(Offer coupon);
        
        Task<bool> DeleteDiscount(int Id);
        Task<bool> UpdateDiscount(Offer coupon);
    }
}
