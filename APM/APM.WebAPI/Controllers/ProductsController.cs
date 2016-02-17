using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APM.WebAPI.Controllers
{     [EnableCors("http://localhost:61788/","*","*")] 
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            var repo = new ProductRepository();
            return repo.Retrieve();
        }


        public IEnumerable<Product> Get(string search)
        {
            var repo = new ProductRepository();
            var products = repo.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));
        }
        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product;
            var repo = new ProductRepository();
            if(id>0)
            {
                var products = repo.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = repo.Create();
            }
            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var repo = new ProductRepository();
            var newProduct = repo.Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            var repo = new ProductRepository();
            var updateProduct = repo.Save(id, product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
