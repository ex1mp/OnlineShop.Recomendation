using Microsoft.AspNetCore.Mvc;
using OnlineShop.Recomendation.Services;

namespace movierecommender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendationController : Controller
    {
        private readonly IRecomedationService _recomedationService;

        public RecomendationController(IRecomedationService recomedationService)
        {
            _recomedationService = recomedationService;
        }

        [HttpGet]
        [Route("/GetRating")]
        public IActionResult GetRating(int userId, int productId)
        {
            var result = _recomedationService.GetRating(userId, productId);

            return Ok(result);
        }

        [HttpGet]
        [Route("/GetRatings")]
        public IActionResult GetRatings(int userId, [FromQuery] List<int> productsId)
        {
            var result = _recomedationService.GetRatings(userId, productsId);

            return Ok(result);
        }
    }
}
