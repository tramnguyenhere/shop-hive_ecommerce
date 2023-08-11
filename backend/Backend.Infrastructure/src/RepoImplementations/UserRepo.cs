using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class UserRepo : BaseRepo<User>, IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly DatabaseContext _context;
        public UserRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _users = dbContext.Users;
            _context = dbContext;
        }
        public Task<User> CreateAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindOneByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePassword(User user)
        {
            throw new NotImplementedException();
        }
    }
}