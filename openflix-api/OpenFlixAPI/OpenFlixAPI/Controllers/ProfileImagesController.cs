using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenFlixAPI.Domain.Models.Profiles;
using OpenFlixAPI.Domain.Repositories.Profiles;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenFlixAPI.Controllers
{
    /// <summary>
    /// Manipula as requisições relacionadas às imagens de perfil dos usuários
    /// </summary>
    [ApiController]
    [Route("/v1/profile-images")]
    public class ProfileImagesController : ControllerBase
    {
        private readonly IProfileImageRepository _profileImageRepository;
        public ProfileImagesController(IProfileImageRepository profileImageRepository)
        {
            _profileImageRepository = profileImageRepository;
        }

        /// <summary>
        /// Lista de imagens de perfil
        /// </summary>
        /// <returns>Retorna a lista de imagens de perfil cadastradas</returns>
        [SwaggerResponse(200, Description = "Sucesso")]
        [SwaggerResponse(401, Description = "Usuário não autenticado")]
        [HttpGet]
        [Route("")]
        [Authorize]
        public IActionResult GetProfileImages()
        {
            var images = _profileImageRepository.GetProfileImages();
            var imagesResult = images.Select(profileImage => 
                ProfileImageResponse.FromProfileImage(profileImage));

            return Ok(imagesResult);
        }
    }
}
