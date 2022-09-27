//using Greedy.Domain.Categories;
//using Greedy.Integration.Authentication;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics.CodeAnalysis;
//using System.Net;

//namespace Greedy.WebApi.Controllers
//{
//    [ExcludeFromCodeCoverage]
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CategoriesController : ControllerBase
//    {
//        private readonly ILogger<CategoriesController> _logger;
//        private ICategoryService _categoryService;

//        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
//        {
//            _logger = logger;
//            _categoryService = categoryService;
//        }

//        [HttpGet]
//        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<string>))]
//        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
//        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
//        public IActionResult Get()
//        {
//            var categories = _categoryService.GetAllDistinctCategories();
//            return Ok(categories);
//        }
//    }
//}