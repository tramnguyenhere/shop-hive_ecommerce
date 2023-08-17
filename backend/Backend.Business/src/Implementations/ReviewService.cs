using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class ReviewService
        : BaseService<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>,
            IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public ReviewService(
            IReviewRepository reviewRepo,
            IProductRepository productRepo,
            IUserRepository userRepo,
            IMapper mapper
        )
            : base(reviewRepo, mapper)
        {
            _reviewRepository = reviewRepo;
            _productRepository = productRepo;
            _userRepository = userRepo;
        }

        // public override async Task<ReviewReadDto> GetOneById(Guid id)
        // {
        //     var foundItem = await _reviewRepository.GetOneById(id);

        //     if (foundItem == null)
        //     {
        //         throw CustomException.NotFoundException("Review not found!");
        //     }

        //     var product = await _productRepository.GetOneById(foundItem.Product.Id);
        //     var user = await _userRepository.GetOneById(foundItem.User.Id);

        //     var foundItemDto = new ReviewReadDto
        //     {
        //         Id = foundItem.Id,
        //         ProductId = product.Id,
        //         UserId = user.Id,
        //         Feedback = foundItem.Feedback,
        //     };

        //     return foundItemDto;
        // }

        public async Task<ReviewReadDto> CreateOneReview(Guid userId, ReviewCreateDto dto)
        {
            var reviewedProduct = await _productRepository.GetOneById(dto.ProductId);

            if (reviewedProduct == null)
            {
                throw CustomException.NotFoundException("Product not found.");
            }

            if (string.IsNullOrEmpty(dto.Feedback))
            {
                throw CustomException.NotValidFormat("Feedback could not be empty");
            }

            var newReview = _mapper.Map<Review>(dto);

            newReview.User = await _userRepository.GetOneById(userId);
            newReview.Product = await _productRepository.GetOneById(dto.ProductId);
            newReview.Feedback = dto.Feedback;

            var createdReview = await _reviewRepository.CreateOne(newReview);

            return _mapper.Map<ReviewReadDto>(createdReview);
        }

        public override async Task<ReviewReadDto> UpdateOneById(Guid id, ReviewUpdateDto updatedDto)
        {
            var foundReview = await _reviewRepository.GetOneById(id);

            if (foundReview != null)
            {
                foundReview.Feedback = updatedDto.Feedback;
                var updatedReview = _mapper.Map<ReviewReadDto>(
                    await _reviewRepository.UpdateOneById(foundReview)
                );
            //     if (foundReview.Product != null)
            //     {
            //         updatedReview.ProductId = foundReview.Product.Id;
            //     }

            //     if (foundReview.User != null)
            //     {
            //         updatedReview.UserId = foundReview.User.Id;
            //     }
                return updatedReview;
            }
            else
            {
                throw CustomException.NotFoundException("Review not found.");
            }
        }
    }
}
