using Ejercicio.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ejercicio.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string ApiTestUrl = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetProductData")]
        public async Task<IActionResult> GetProductDataAsync()
        {
            var response = await _httpClient.GetStreamAsync(ApiTestUrl);

            var products = await JsonSerializer.DeserializeAsync<ProductData>(response);

            return Ok(response);
        }
    }
}
