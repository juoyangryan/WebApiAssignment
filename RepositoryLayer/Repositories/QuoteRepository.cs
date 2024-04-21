using DomainLayer.Models;
using DomainLayer.Interfaces;
using RepositoryLayer.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class QuoteRepository: IQuoteRepository
    {
        private readonly ApplicationContext _context;
        public QuoteRepository(ApplicationContext context) { _context = context; }
        
        public async Task<IEnumerable<Quote>> GetQuotesAsync()
        {
            return await _context.Quotes.ToListAsync();
        }
        public async Task<Quote> GetQuoteByIdAsync(int id)
        {
            return await _context.Quotes.FindAsync(id);
        }
        public async Task AddQuoteAsync(Quote quote)
        {
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateQuoteAsync(Quote quote)
        {
            _context.Entry(quote).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteQuoteAsync(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
