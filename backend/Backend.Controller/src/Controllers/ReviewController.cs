using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controller.src.Controllers
{
    public class ReviewController : CrudController<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        private readonly IReviewService _ReviewService;
        public ReviewController(IReviewService reviewService) : base(reviewService)
        {
            _ReviewService = reviewService;
        }

        [Authorize]
        public override async Task<ActionResult<IEnumerable<ReviewReadDto>>> CreateOne([FromBody] ReviewCreateDto dto) {
            var createdObject = await _ReviewService.CreateOne(dto);
            return CreatedAtAction("Created", createdObject);
        }

        [Authorize]
        public override async Task<ActionResult<ReviewReadDto>> UpdateOneById ([FromRoute] Guid id, [FromBody] ReviewUpdateDto update) {
            var updatedObject = await _ReviewService.UpdateOneById(id, update);
            return Ok(updatedObject);
        }

        [Authorize]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id) {
            return StatusCode(204, await _ReviewService.DeleteOneById(id));
        }
    }
}