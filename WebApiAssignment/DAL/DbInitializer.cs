using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAssignment.Models;

namespace WebApiAssignment.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var products = new List<Product>
            {
                new Product{ProductName="Product1", ProductDescription="This is product 1."}, 
                new Product{ProductName="Product2", ProductDescription="This is product 2."},
                new Product{ProductName="Product3", ProductDescription="This is product 3."}
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}