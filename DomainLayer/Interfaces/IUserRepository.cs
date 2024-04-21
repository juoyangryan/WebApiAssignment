using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);
        Task AddUserAsync(User user);

    }
}
