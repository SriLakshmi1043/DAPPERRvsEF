using EF.API.Models;
using EF.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IEFRepository _iefRepository;
        private object _iefrepository;

        public HomeController(IEFRepository bookRepository)
        {
            _iefRepository = bookRepository;
        }
        [HttpPost(Name = "CreateDiscount")]
        [ProducesResponseType(typeof(Offer), (int)HttpStatusCode.OK)]

        public async Task<int> CreateDiscount(Offer coupon)
        {
            var discount = await _iefRepository.CreateDiscount(coupon);

            return discount;
        }

        [HttpDelete("{Id}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(Offer), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteDiscount(int Id)
        {
            return Ok(await _iefRepository.DeleteDiscount(Id));
        }

        [HttpGet("{BookName}", Name = "GetDiscount")]
        public async Task<ActionResult> GetDiscount(string BookName)
        {
            return Ok(await _iefRepository.GetDiscount(BookName));
        }
    }
}
