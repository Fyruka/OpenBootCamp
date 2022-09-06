using APIVersionControl.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIVersionControl.Controllers.V2
{
    [ApiVersion("2.0")] // Especificamos la version de nuestra api para esta ruta
    [Route("api/v{version:apiVersion}/[controller]")] 
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string ApiTestURL = "https://dummyapi.io/data/v1/user?limit=30"; 
        private const string AppId = "6317283c8458da687b68d2d6";
        private readonly HttpClient _httpClient;

        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")] // Especificamos que esta ruta estara disponible unicamente para la version 2.0
        [HttpGet(Name = "GetUserData")]
        public async Task<IActionResult> GetUsersDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear(); 
            _httpClient.DefaultRequestHeaders.Add("app-id", AppId); 

            var response = await _httpClient.GetStreamAsync(ApiTestURL);  

            var usersData = await JsonSerializer.DeserializeAsync<UsersResponseData>(response);

            var users = usersData?.data; // En este caso solo devolvermos la lista de usuarios, quitando el resto de parametros. 

            return Ok(users);
        }
    }
}
