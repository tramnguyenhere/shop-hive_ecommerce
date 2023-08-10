using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;

namespace Backend.Controller.src.Controllers
{
    public class ReviewController : CrudController<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        public ReviewController(IReviewService reviewService) : base(reviewService)
        {
        }
    }
}