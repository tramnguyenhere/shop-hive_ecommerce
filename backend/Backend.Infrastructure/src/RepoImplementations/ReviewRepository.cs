using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly DbSet<Review> _reviews;
        private readonly DatabaseContext _dbContext;
        public ReviewRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _reviews = dbContext.Reviews;
        }
    }
}