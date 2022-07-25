using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenFlixAPI.Domain.Models.Profiles;
using OpenFlixAPI.Domain.Models.Videos;
using OpenFlixAPI.Domain.Repositories.Profiles;
using OpenFlixAPI.Domain.Repositories.Videos;
using OpenFlixAPI.Filters;
using OpenFlixAPI.Extensions;
using OpenFlixAPI.Domain.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenFlixAPI.Controllers
{
    /// <summary>
    /// Manipula as requisições relacionadas aos perfis dos usuários
    /// </summary>
    [ApiController]
    [Route("/v1/profiles")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly ITransactionHandler _transactionHandler;
        public ProfileController(
            IProfileRepository profileRepository,
            IFavoriteRepository favoriteRepository,
            ITransactionHandler transactionHandler
        )
        {
            _profileRepository = profileRepository;
            _favoriteRepository = favoriteRepository;
            _transactionHandler = transactionHandler;
        }

        /// <summary>
        /// Lista de perfis do usuário
        /// </summary>
        /// <returns>Retorna a lista de perfis do usuário</returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [HttpGet]
        [Route("")]
        [Authorize]
        public IActionResult GetProfiles()
        {
            var userId = this.GetUserId();

            var profiles = _profileRepository.GetUserProfiles(userId);

            return Ok(profiles.Select(profile => ProfileResponse.FromProfileModel(profile)));
        }

        /// <summary>
        /// Cria um novo perfil para o usuário e sua respectiva lista de favoritos
        /// </summary>
        /// <param name="profileRequest">Dados do novo perfil</param>
        /// <returns>Retorna o perfil criado</returns>
        [SwaggerResponse(200, Description = "Perfil criado com sucesso")]
        [SwaggerResponse(400, Description = "Dados do perfil inválidos")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [HttpPost]
        [Route("")]
        [ValidationFilter]
        [ExceptionFilter]
        [Authorize]
        public IActionResult CreateProfile(ProfileRequest profileRequest)
        {
            var userId = this.GetUserId();

            var transaction = _transactionHandler.BeginTransaction();

            var profile = new Profile()
            {
                Name = profileRequest.Name,
                ProfileImageId = profileRequest.ImageId,
                UserId = userId
            };

            var profileId = _profileRepository.CreateProfile(profile);

            var profileFavorite = new Favorite()
            {
                ProfileId = profileId,
                UserId = userId
            };
            _favoriteRepository.CreateFavorites(profileFavorite);

            transaction.Commit();

            var createdProfile = _profileRepository.GetProfileById(profileId, userId);

            return Created("", ProfileResponse.FromProfileModel(createdProfile));
        }
        /// <summary>
        /// Dados do perfil
        /// </summary>
        /// <param name="id">ID do perfil</param>
        /// <returns>Retorna os dados do perfil procurado</returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [SwaggerResponse(404, Description = "Perfil não encontrado")]
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        [ExceptionFilter]
        public IActionResult GetProfileById([FromRoute(Name = "id")] int id)
        {
            var userId = this.GetUserId();
            var profile = _profileRepository.GetProfileById(id, userId);

            return Ok(ProfileResponse.FromProfileModel(profile));
        }

        /// <summary>
        /// Deleta um perfil do usuário
        /// </summary>
        /// <param name="profileId">ID do perfil a ser deletado</param>
        /// <returns></returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [SwaggerResponse(404, Description = "Perfil não encontrado")]
        [HttpDelete]
        [Route("{profileId}")]
        [Authorize]
        [ExceptionFilter]
        public IActionResult DeleteProfile([FromRoute(Name = "profileId")] int profileId)
        {
            var userId = this.GetUserId();

            _profileRepository.DeleteProfile(profileId, userId);
            return NoContent();
        }

        /// <summary>
        /// Atualiza o perfil do usuário
        /// </summary>
        /// <param name="profileId">ID do perfil a ser atualizado</param>
        /// <param name="profileRequest">Novos dados do perfil</param>
        /// <returns>Retorna o perfil atualizado</returns>
        [SwaggerResponse(200, Description = "Perfil atualizado com sucesso")]
        [SwaggerResponse(400, Description = "Dados do perfil inválidos")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [SwaggerResponse(404, Description = "Perfil não encontrado")]
        [HttpPut]
        [Route("{profileId}")]
        [Authorize]
        [ValidationFilter]
        [ExceptionFilter]
        public IActionResult UpdateProfile(
            [FromRoute(Name = "profileId")] int profileId,
            ProfileRequest profileRequest)
        {
            var userId = this.GetUserId();

            var profile = new Profile()
            {
                Id = profileId,
                Name = profileRequest.Name,
                ProfileImageId = profileRequest.ImageId,
                UserId = userId
            };

            _profileRepository.UpdateProfile(profile, userId);
            var updatedProfile = _profileRepository.GetProfileById(profile.Id, userId);

            var profilesResult = ProfileResponse.FromProfileModel(updatedProfile);

            return Ok(profilesResult);
        }
    }
}
