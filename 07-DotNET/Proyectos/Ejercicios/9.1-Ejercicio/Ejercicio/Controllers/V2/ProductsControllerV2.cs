using Ejercicio.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ejercicio.Controllers.V2
{
    [ApiVersion("2.0")]
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


        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductData")]
        public async Task<IActionResult> GetProductDataAsync()
        {
            var response = await _httpClient.GetStreamAsync(ApiTestUrl);
            
            var productsData = await JsonSerializer.DeserializeAsync<List<ProductDataV2>>(response);

            foreach (var product in productsData) {
                product.internalId = Guid.NewGuid();
            };

            return Ok(productsData);
        }
    }
}
