using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssignment.DAL;
using WebApiAssignment.Models;

namespace WebApiAssignment.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private UserContext _userContext = new UserContext();

        // GET api/values
        public IHttpActionResult Get()
        {
            var products = _userContext.Products.ToList();
            return Ok(products);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_userContext.Products.FirstOrDefault(p => p.ID == id));
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] Product product)
        {
            _userContext.Products.Add(product);
            _userContext.SaveChanges();
            return Ok(product);
        }

        // PUT api/values/5
        public IHttpActionResult Put([FromBody] Product product)
        {
            var oldProduct = _userContext.Products.FirstOrDefault(p => p.ID == product.ID);
            if (oldProduct != null)
            {
                oldProduct.ProductName = product.ProductName;
                oldProduct.ProductDescription = product.ProductDescription;
                _userContext.SaveChanges();
                return Ok(product);
            } else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            var oldProduct = _userContext.Products.FirstOrDefault(p => p.ID == id);
            var deletedProduct = _userContext.Products.Remove(oldProduct);
            _userContext.SaveChanges();

            return Ok(oldProduct);
        }
    }
}
