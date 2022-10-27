using Dapper.API.Entity;
using Dapper.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
       

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpPost( Name = "CreateDiscount")]
        [ProducesResponseType(typeof(OfferBooks), (int)HttpStatusCode.OK)]

        public async Task<ActionResult> CreateDiscount(OfferBooks coupon)
        {
            var discount = await _bookRepository.CreateDiscount(coupon);
           
            return Ok(discount);
        }

        [HttpDelete("{Id}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(OfferBooks), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteDiscount(int Id)
        {
            return Ok(await _bookRepository.DeleteDiscount(Id));
        }
        [HttpGet("{BookName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(OfferBooks), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetDiscount(string BookName)
        {
            return Ok(await _bookRepository.GetDiscount(BookName));
        }
    }
}
