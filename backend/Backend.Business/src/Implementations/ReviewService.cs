using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class ReviewService : BaseService<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>, IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepo, IProductRepository productRepo, IUserRepository userRepo, IMapper mapper) : base(reviewRepo, mapper)
        {
            _reviewRepository = reviewRepo;
            _productRepository = productRepo;
            _userRepository = userRepo;
        }
        public override async Task<ReviewReadDto> CreateOne(ReviewCreateDto review)
        {
            var reviewedProduct = await _productRepository.GetOneById(review.ProductId);

            if (reviewedProduct == null) {
                throw CustomException.NotFoundException("Product not found.");
            }

            if(string.IsNullOrEmpty(review.Feedback)) {
                throw CustomException.NotValidFormat("Feedback could not be empty");
            }

            var newReview = _mapper.Map<Review>(review);
            
            newReview.User = await _userRepository.GetOneById(review.UserId);
            newReview.Product = await _productRepository.GetOneById(review.ProductId);
            newReview.Feedback = review.Feedback;
            
            var createdReview = await _reviewRepository.CreateOne(newReview);
            
            return _mapper.Map<ReviewReadDto>(createdReview);
        }

        public override async Task<ReviewReadDto> UpdateOneById(Guid id, ReviewUpdateDto updatedDto)
        {
            var foundReview = await _reviewRepository.GetOneById(id);

            if(foundReview != null) {
                foundReview.Feedback = updatedDto.Feedback;
                return _mapper.Map<ReviewReadDto>(await _reviewRepository.UpdateOneById(foundReview));
            } else {
                await _reviewRepository.DeleteOneById(foundReview);
                throw CustomException.NotFoundException("Review not found.");
            }
        }
    }
}