#region New Code with polly
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using CircuitBreaker.Product.WebApi.Model;

namespace CircuitBreaker.Weather.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;

        public ProductController(HttpClient httpClient, IAsyncPolicy<HttpResponseMessage> retryPolicy)
        {
            _httpClient = httpClient;
            _retryPolicy = retryPolicy;
        }

        [HttpGet("{productDetailId}")]
        public async Task<ActionResult> Get(int productDetailId)
        {
            HttpResponseMessage httpResponseMessage = await _retryPolicy.ExecuteAsync(() =>
                      _httpClient.GetAsync($"api/ProductDetail/{productDetailId}"));

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
            return "CircuitBreaker.Product.WebApi Status - Up";
        }
    }
}

#endregion

#region Old Code
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace CircuitBreaker.Weather.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WeatherController : ControllerBase
//    {
//        private readonly HttpClient _httpClient;

//        public WeatherController(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        [HttpGet("{locationId}")]
//        public async Task<ActionResult> Get(int locationId)
//        {
//            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"temperature/{locationId}");

//            if (httpResponseMessage.IsSuccessStatusCode)
//            {
//                int temperature = await httpResponseMessage.Content.ReadAsAsync<int>();
//                return Ok(temperature);
//            }

//            return StatusCode((int)httpResponseMessage.StatusCode, "The temperature service returned an error.");
//        }
//    }
//}
#endregion




