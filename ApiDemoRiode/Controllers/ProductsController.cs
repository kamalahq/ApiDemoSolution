using ApiDemoRiode.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiDemoRiode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product{Id=1,Name="Product-1",Category="Category-1"},
            new Product{Id=2,Name="Product-2",Category="Category-1"}
        };
        [HttpGet]
        public List<Product> Get()
        {
            return products;
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.FirstOrDefault(p=>p.Id == id);
            return product;
        }
        [HttpPost]
        public Product Post(Product model)
        {
            products.Add(model);
            return model;
        }
        [HttpPut("{id}")]
        public Product Put([FromRoute] int id,Product model)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product !=null)
            {
                product.Name = model.Name;
                product.Category = model.Category;
            }
            return product;
        }
        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return product;
        }
    }
}
