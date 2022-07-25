using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenFlixAPI.Domain.Models.Videos;
using OpenFlixAPI.Domain.Repositories.Videos;
using OpenFlixAPI.Filters;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using OpenFlixAPI.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenFlixAPI.Controllers
{
    /// <summary>
    /// Manipula as requisições relacionadas aos vídeos favoritos dos usuários
    /// </summary>
    [ApiController]
    [Route("/v1/favorites")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        /// <summary>
        /// Lista de séries favoritas do perfil
        /// </summary>
        /// <param name="profileId">ID do perfil logado do usuário</param>
        /// <returns>Retorna a lista de séries favoritas do perfil</returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [SwaggerResponse(404, Description = "Favoritos não encontrados")]
        [HttpGet]
        [Route("")]
        [Authorize]
        [ExceptionFilter]
        public IActionResult GetProfileFavorites([FromHeader(Name = "X-Profile-ID")][Required] int profileId)
        {
            var userId = this.GetUserId();

            var favorites = _favoriteRepository.GetProfileFavorites(profileId, userId);

            var favoritesResult = favorites.Series
                .Select(serie => SerieResponse.FromSerieModel(serie));

            return Ok(favoritesResult);
        }

        /// <summary>
        /// Adiciona uma série aos favoritos do perfil
        /// </summary>
        /// <param name="serieId">ID da série a ser adicionada aos favoritos</param>
        /// <param name="profileId">ID do perfil logado do usuário</param>
        /// <returns></returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [SwaggerResponse(404, Description = "Série ou Favoritos não encontrados")]
        [HttpPost]
        [Route("{serieId}")]
        [Authorize]
        public IActionResult AddSerieToFavorites(
            [FromRoute(Name = "serieId")] int serieId,
            [FromHeader(Name = "X-Profile-ID")][Required] int profileId)
        {
            var userId = this.GetUserId();

            _favoriteRepository.AddToFavorites(serieId, profileId, userId);

            return NoContent();
        }

        /// <summary>
        /// Remove uma série dos favoritos do perfil
        /// </summary>
        /// <param name="serieId">ID da série a ser adicionada aos favoritos</param>
        /// <param name="profileId">ID do perfil logado do usuário</param>
        /// <returns></returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [SwaggerResponse(404, Description = "Série ou Favoritos não encontrados")]
        [HttpDelete]
        [Route("{serieId}")]
        [Authorize]
        public IActionResult RemoveSerieFromFavorites(
            [FromRoute(Name = "serieId")] int serieId,
            [FromHeader(Name = "X-Profile-ID")][Required] int profileId)
        {
            var userId = this.GetUserId();

            _favoriteRepository.RemoveFromFavorites(serieId, profileId, userId);

            return NoContent();
        }
    }
}
