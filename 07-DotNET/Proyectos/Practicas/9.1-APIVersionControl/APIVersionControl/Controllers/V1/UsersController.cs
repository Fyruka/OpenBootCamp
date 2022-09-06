using APIVersionControl.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIVersionControl.Controllers.V1
{
    [ApiVersion("1.0")] // Especificamos la version de nuestra api para esta ruta
    [Route("api/v{version:apiVersion}/[controller]")] // En la ruta añadiremos las sintaxis que nos indique la version de nuestra API
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string ApiTestURL = "https://dummyapi.io/data/v1/user?limit=30"; // Añadimos la URL para nuestras consultas, y le pasamos un param de limite de 30 usuarios. 
        private const string AppId = "6317283c8458da687b68d2d6"; // Generamos la variable para la ID de cliente que nos pedira la API Fake de donde consumiremos los datos de los clientes. 
        private readonly HttpClient _httpClient;

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")] // Especificamos que esta ruta estara disponible unicamente para la version 1.0
        [HttpGet(Name = "GetUserData")]
        public async Task<IActionResult> GetUsersDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear(); // Limpiamos las headers de las consultas http por si hubiera algo
            _httpClient.DefaultRequestHeaders.Add("app-id", AppId); // Añadimos dentro del header nuestra appid tal y como nos pide la API fake

            var response = await _httpClient.GetStreamAsync(ApiTestURL); // Peticion lanzada a la FakeAPI y la API tiene que devolver la respuesta con los datos de los usuarios. 

            var usersData = await JsonSerializer.DeserializeAsync<UsersResponseData>(response); // Serializamos la respuesta en un Json, con el esquema que hemos creado en nuestro modelo dentro de la carpeta DTO

            return Ok(usersData); // Una vez obtenida toda la lista, devuelve un 200 (OK) con un JSON incluyendo a todos los usuarios
        }
    }
}
