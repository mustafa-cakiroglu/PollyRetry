using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetail.WebApi
{
    public class ProductDetailMockData
    {
        public static List<ProductDetail> GetAllProductDetails()
        {
            var productDetailList = new List<ProductDetail>();

            var productDetail = new ProductDetail
            {
                Id = 1,
                Name = "IPhone 7",
                Price = 7000
            };
            productDetailList.Add(productDetail);

            productDetail = new ProductDetail
            {
                Id = 2,
                Name = "Samsung Galaxy M11 Duos 32 GB",
                Price = 2199
            };
            productDetailList.Add(productDetail);

            productDetail = new ProductDetail
            {
                Id = 3,
                Name = "Xiaomi Redmi Note 8 Pro 64",
                Price = 2799
            };
            productDetailList.Add(productDetail);

            productDetail = new ProductDetail
            {
                Id = 4,
                Name = "Vestel Venus Z30 64 GB",
                Price = 1569
            };
            productDetailList.Add(productDetail);

             productDetail = new ProductDetail
            {
                Id = 5,
                Name = "Apple iPhone 11 64 GB",
                Price = 7300
            };
            productDetailList.Add(productDetail);

            return productDetailList;
        }
    }
}
