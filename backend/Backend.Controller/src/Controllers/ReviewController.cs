using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controller.src.Controllers
{
    public class ReviewController : CrudController<Review, ReviewReadDto, ReviewCreateDto, ReviewUpdateDto>
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService) : base(reviewService)
        {
            _reviewService = reviewService;
        }

        [Authorize]
        [HttpPost]
        public override async Task<ActionResult<ReviewReadDto>> CreateOne([FromBody] ReviewCreateDto dto) {
            var createdObject = await _reviewService.CreateOne(dto);
            return Ok(createdObject);
        }

        [Authorize]
        [HttpPatch("{id:Guid}")]
        public override async Task<ActionResult<ReviewReadDto>> UpdateOneById ([FromRoute] Guid id, [FromBody] ReviewUpdateDto update) {
            var updatedObject = await _reviewService.UpdateOneById(id, update);
            return Ok(updatedObject);
        }

        [Authorize]
        [HttpDelete("{id:Guid}")]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id) {
            return StatusCode(204, await _reviewService.DeleteOneById(id));
        }
    }
}