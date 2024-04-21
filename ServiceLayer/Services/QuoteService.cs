using DomainLayer.Interfaces;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteService(IQuoteRepository quoteRepository) { _quoteRepository = quoteRepository; }
        public async Task<IEnumerable<Quote>> GetQuotesAsync()
        {
            return await _quoteRepository.GetQuotesAsync();
        }
        public async Task<Quote> GetQuoteByIdAsync(int id)
        {
            return await _quoteRepository.GetQuoteByIdAsync(id);
        }
        public async Task AddQuoteAsync(Quote quote)
        {
            await _quoteRepository.AddQuoteAsync(quote);
        }
        public async Task UpdateQuoteAsync(Quote quote)
        {
            await _quoteRepository.UpdateQuoteAsync(quote);
        }
        public async Task DeleteQuoteAsync(int id)
        {
            await _quoteRepository.DeleteQuoteAsync(id);
        }
    }
}
