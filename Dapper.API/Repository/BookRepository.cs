using Dapper.API.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        public async Task<bool> CreateDiscount(OfferBooks coupon)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            
            var affected = await connection.ExecuteAsync("InsertBooks", new {coupon.BookName,coupon.Amount,coupon.Description }
                              , commandType: CommandType.StoredProcedure);

            if (affected == 0)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> DeleteDiscount(int Id)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

           
            var affected = await connection.ExecuteAsync("DeleteBookById", new { Id }, commandType: CommandType.StoredProcedure);

            if (affected == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable< OfferBooks>> GetDiscount(string BookName)
        {
            using var connection = new SqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

           
            var affected = await connection.QueryAsync<OfferBooks>("GetBooksByBookName", new { BookName }, commandType: CommandType.StoredProcedure);


            return affected;
        }
    }
}
/*  var affected = await connection.ExecuteAsync
                  ("DELETE FROM Offer   WHERE BookName=@BookName",
                  new { BookName = BookName });*/
/*  var affected = await connection.ExecuteAsync
                  ("DELETE FROM Offer   WHERE BookName=@BookName",
                  new { BookName = BookName });*/