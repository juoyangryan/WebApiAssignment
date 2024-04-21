using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var quotes = new List<Quote>
            {
                new Quote{QuoteType="Test", Description="This is test data.", DueDate=new DateTime(), Premium=19.99, Sales="Ryan"}
            };

            quotes.ForEach(p => context.Quotes.Add(p));
            context.SaveChanges();
        }
    }
}
