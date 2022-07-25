using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenFlixAPI.Domain.Models.Videos;
using OpenFlixAPI.Domain.Repositories.Videos;
using OpenFlixAPI.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace OpenFlixAPI.Controllers
{
    /// <summary>
    /// Manipula as requisições relacionadas aos vídeos
    /// </summary>
    [ApiController]
    [Route("/v1/videos")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository _videoRepository;
        public VideoController(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        /// <summary>
        /// Consulta de séries e vídeos
        /// </summary>
        /// <param name="search">Termo de pesquisa</param>
        /// <returns>Retorna a lista de séries que satisfazem a consulta</returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [HttpGet]
        [Route("")]
        [ExceptionFilter]
        [Authorize]
        public IActionResult SearchVideos([FromQuery(Name = "s")][Required] string search)
        {
            var videos = _videoRepository.SearchVideos(search);
            var videosResult = videos.Select(serie => SerieResponse.FromSerieModel(serie));
            return Ok(videosResult);
        }

        /// <summary>
        /// Obtém os dados de uma série
        /// </summary>
        /// <param name="serieId">ID da série</param>
        /// <returns>Dados da série procurada</returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [SwaggerResponse(404, Description = "Série não encontrada")]
        [HttpGet]
        [Route("{serieId}")]
        [Authorize]
        [ExceptionFilter]
        public IActionResult GetSerieById([FromRoute(Name = "serieId")] int serieId)
        {
            var serie = _videoRepository.GetSerieById(serieId);
            return Ok(SerieResponse.FromSerieModel(serie));
        }

        /// <summary>
        /// Lista de séries organizadas por categoria
        /// </summary>
        /// <returns>Retorna a lista de séries organizadas por categoria</returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [HttpGet]
        [Route("categoryzed")]
        [Authorize]
        public IActionResult GetHomeVideos()
        {
            var categoryzedVideos = _videoRepository.GetCategoryzedVideos();
            return Ok(categoryzedVideos);
        }
    }
}
