using DomainLayer.Interfaces;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiAssignment.CustomFilters;
using WebApiAssignment.Models;

namespace WebApiAssignment.Controllers
{
    [CustomExceptionFilter]
    [Authorize]
    public class QuoteController : ApiController
    {
        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService) { _quoteService = quoteService; }

        // GET api/quote
        public async Task<IHttpActionResult> Get()
        {
            var quotes = await _quoteService.GetQuotesAsync();
            return Ok(quotes);
        }

        // GET api/values/5
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _quoteService.GetQuoteByIdAsync(id));
        }

        // POST api/values
        public async Task<IHttpActionResult> Post([FromBody] Models.Quote quote)
        {
            await _quoteService.AddQuoteAsync(new DomainLayer.Models.Quote
            {
                QuoteID = quote.QuoteID, 
                QuoteType = quote.QuoteType,
                Description = quote.Description,
                DueDate = quote.DueDate,
                Premium = quote.Premium,
                Sales = quote.Sales
            });
            return Ok(quote);
        }

        // PUT api/values
        public async Task<IHttpActionResult> Put([FromBody] Models.Quote quote)
        {
            var oldProduct = await _quoteService.GetQuoteByIdAsync(quote.QuoteID);
            if (oldProduct != null)
            {
                await _quoteService.UpdateQuoteAsync(new DomainLayer.Models.Quote
                {
                    QuoteID = quote.QuoteID,
                    QuoteType = quote.QuoteType,
                    Description = quote.Description,
                    DueDate = quote.DueDate,
                    Premium = quote.Premium,
                    Sales = quote.Sales
                });
                return Ok(quote);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/values/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _quoteService.DeleteQuoteAsync(id);

            return Ok(id);
        }
    }
}
