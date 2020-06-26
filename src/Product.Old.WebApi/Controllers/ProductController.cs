using Microsoft.AspNetCore.Mvc;
using Product.Old.WebApi.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace CircuitBreaker.Weather.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{productDetailId}")]
        public async Task<ActionResult> Get(int productDetailId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"api/productdetail/{productDetailId}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var productDetail = await httpResponseMessage.Content.ReadAsAsync<ProductDetail>();
                return Ok(productDetail);
            }

            return StatusCode((int)httpResponseMessage.StatusCode, "The Product Detail service returned an error.");
        }

        [HttpGet]
        public string Get()
        {
            return "Product.Old.WebApi Status - Up";
        }
    }
}
