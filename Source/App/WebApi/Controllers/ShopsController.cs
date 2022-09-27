using Greedy.Domain.Shops;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Greedy.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/shops")]
    public class ShopsController : ControllerBase
    {
        private readonly ILogger<ShopsController> _logger;
        private IShopService _shopService;

        public ShopsController(ILogger<ShopsController> logger, IShopService shopService)
        {
            _logger = logger;
            _shopService = shopService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<string>))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            return Ok();
            //try
            //{
            //    var shops = _shopService.GetAllUserShops(username);
            //    return Ok(shops);
            //}
            //catch (NullReferenceException)
            //{
            //    return HelperClass.JsonHttpResponse<Object>(null);
            //}
        }
    }
}