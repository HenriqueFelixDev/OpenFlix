using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using OpenFlixAPI.Domain.Exceptions;
using OpenFlixAPI.Domain.Models.Auth;
using OpenFlixAPI.Domain.Models.Users;
using OpenFlixAPI.Domain.Repositories.Users;
using OpenFlixAPI.Filters;
using OpenFlixAPI.Services.Auth;
using OpenFlixAPI.Services.Password;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenFlixAPI.Controllers
{
    /// <summary>
    /// Manipula as requisições de autenticação e criação de usuários
    /// </summary>
    [ApiController]
    [Route("/v1/auth")]
    [ExceptionFilter]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AuthController(IAuthService authService, IUserRepository userRepository, IPasswordService passwordService)
        {
            _authService = authService;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }
        /// <summary>
        /// Realiza a autenticação do usuário
        /// </summary>
        /// <returns>Retorna o token de autenticação do usuário (JWT)</returns>
        [SwaggerResponse(200, Description = "Token de autenticação do usuário")]
        [SwaggerResponse(400, Description = "Dados de autenticação (usuário e/ou senha) inválidos")]
        [SwaggerResponse(404, Description = "Usuário não encontrado")]
        [HttpGet]
        [Route("login")]
        public IActionResult Login([FromHeader(Name = "Authorization")][Required] string token)
        {
            var loginRequest = _authService.DecodeBasicToken(token);

            User? user = _userRepository.GetUserByUsername(loginRequest.Username);

            if (user == null || !_passwordService.VerifyPassword(user.Password, loginRequest.Password))
            {
                return NotFound("Usuário não encontrado!");
            }

            var jwt = _authService.CreateJWT(user);

            return Ok(new AuthResponse(jwt));
        }

        /// <summary>
        /// Cria um novo usuário e realiza a sua autenticação
        /// </summary>
        /// <param name="userSignUp"></param>
        /// <returns>Retorna o token de autenticação do usuário</returns>
        [SwaggerResponse(201, Description = "Usuário criado com sucesso")]
        [SwaggerResponse(400, Description = "Dados do usuário inválidos")]
        [ValidationFilter]
        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp(UserSignUp userSignUp)
        {
            var user = new User
            {
                Username = userSignUp.Username,
                Email = userSignUp.Email,
                Password = _passwordService.EncryptPassword(userSignUp.Password)
            };

            _userRepository.CreateUser(user);

            var jwt = _authService.CreateJWT(user);

            return Created("", new AuthResponse(jwt));
        }
    }
}
