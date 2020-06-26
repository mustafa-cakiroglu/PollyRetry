using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading;

namespace ProductDetail.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        static int _counter = 0;
        static readonly Random randomProductDetail = new Random();

        [HttpGet("{Id}")]
        public ActionResult Get(int id)
        {
            _counter++;

            Thread.Sleep(3000);
            if (_counter % 4 == 0)
            {
                int randomResultId = randomProductDetail.Next(1, 6);
                var productDetailList = ProductDetailMockData.GetAllProductDetails();

                var productModel = productDetailList.FirstOrDefault(x => x.Id == randomResultId);
                return Ok(productModel);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError,
                "Something went wrong when getting the Product Details.");
        }

        [HttpGet]
        public string Get()
        {
            return "ProductDetail.WebApi Status - Up";
        }
    }
}
