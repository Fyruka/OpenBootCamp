using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context; // Variable privada del contexto.
        private readonly JwtSettings _jwtSettings;
        private readonly IStringLocalizer<AccountController> _accountControllerLocalizer;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UniversityDBContext context, JwtSettings jwtSettings, IStringLocalizer<AccountController> accountControllerLocalizer, ILogger<AccountController> logger)
        {
            _context = context; // contexto de la aplicacion
            _jwtSettings = jwtSettings;
            _accountControllerLocalizer = accountControllerLocalizer;
            _logger = logger;
        }

        //// Example users
        //// TODO: Chango for real users on DB
        //private IEnumerable<User> Logins = new List<User>() 
        //{
        //    new User()
        //    {
        //        Id = 1,
        //        Email = "admin@imagina.com",
        //        Name = "Admin",
        //        Password = "admin"
        //    },
        //    new User()
        //    {
        //        Id = 1,
        //        Email = "pepe@imagina.com",
        //        Name = "User1",
        //        Password = "pepe"
        //    },
        //};

        [HttpPost] // Con este post nos devolveria una token. 
        [Route("AccountControllerResource")]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();

                // Search user in context with LINQ

                var searchUser = (from user in _context.Users // Con esto realizamos una busqueda dentro del contexto de la base de datos. 
                                  where user.Name == userLogin.UserName && user.Password == userLogin.Password // Estamos usando el name para el login, pero podriamos usar mejor el email que suele ser unico. 
                                  select user).FirstOrDefault(); // Devolvemos todo el usuario, pero tambien podriamos devolver un DTO del usuario en concreto.
                                                                 // Ademas toda la consulta la colocamos entre parentesis, y utilizamos la opracion FirstOrDefault()
                                                                 // para traer el primero de los valores, ya que puede haber mas de un usuario con el mismo nombre o contraseña parecida

                // System.Diagnostics.Debug.WriteLine($"User Found {searchUser.Name}"); // En lugar de utilizar Console.WriteLine, usaremos esta funcion que nos lo muestra por la consola de depuracion de Visual Studio


                // TODO: Change to searchUser
                // var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase)); // Esto nos dara un true o false si el nombre introducido esta en la lista. 
                
                if (searchUser != null) // Revisamos que no sea null
                {
                    // var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,  // Cambiamos en lugar de usar user, usaremos el searchUser para conseguir las credenciales. 
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Credentials");
                }

                var tokenWelcome = _accountControllerLocalizer["Welcome"];

                return Ok(new
                {
                    Token = Token,
                    TokenWelcome = $"{tokenWelcome.Value} {searchUser.Name}"
                });

            }catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
                _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(GetToken)} - Error Level Log");
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")] // con esta linia le estamos especificando que solo el Rol de administrador que nosotros hemos definido que usuarios lo tendran dentro del Helper son los que podran utilizar este Endpoint
        public IActionResult GetUserList()
        {
            var searchAllUsers = from user in _context.Users select user;

            return Ok(searchAllUsers);
        }
    }
}
