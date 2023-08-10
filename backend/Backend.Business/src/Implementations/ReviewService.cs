using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class ReviewService : BaseService<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>, IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepo, IMapper mapper) : base(reviewRepo, mapper)
        {
            _reviewRepository = reviewRepo;
        }
    }
}