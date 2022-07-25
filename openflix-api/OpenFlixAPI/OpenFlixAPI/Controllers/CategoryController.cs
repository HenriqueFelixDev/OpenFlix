using Microsoft.AspNetCore.Mvc;
using OpenFlixAPI.Domain.Models.Videos;
using OpenFlixAPI.Domain.Repositories.Videos;

namespace OpenFlixAPI.Controllers
{
    /// <summary>
    /// Manipula as Requisições relacionadas às categorias dos vídeos
    /// </summary>
    [ApiController]
    [Route("/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Lista com as categorias cadastradas
        /// </summary>
        /// <returns>Retorna uma lista de categorias</returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            var categoriesResult = categories
                .Select(category => VideoCategoryResponse.FromVideoCategory(category));
            
            return Ok(categoriesResult);
        }
    }
}
