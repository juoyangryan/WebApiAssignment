using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetQuotesAsync();
        Task<Quote> GetQuoteByIdAsync(int id);
        Task AddQuoteAsync(Quote quote);
        Task UpdateQuoteAsync(Quote quote);
        Task DeleteQuoteAsync(int id);
    }
}
