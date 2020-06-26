using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CircuitBreaker.Product.WebApi.Model
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
