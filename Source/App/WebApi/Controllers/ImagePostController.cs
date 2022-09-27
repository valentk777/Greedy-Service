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
//    public class ImageUploadController : ControllerBase
//    {
//        private readonly ILogger<ImageUploadController> _logger;
//        private ICategoryService _categoryService;

//        public ImageUploadController(ILogger<ImageUploadController> logger, IImageService categoryService)
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