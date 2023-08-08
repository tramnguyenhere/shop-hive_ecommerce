using Microsoft.AspNetCore.Mvc;
using Backend.Business.src.Abstractions;
using Backend.Domain.src.Shared;

namespace Backend.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class CrudController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        private readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _baseService;

        public CrudController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> baseService) {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryOptions queryOptions) {
            return Ok(await _baseService.GetAll(queryOptions));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetOneById([FromRoute] string id) {
            return Ok(await _baseService.GetOneById(id));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<TReadDto>>> CreateOne([FromBody] TCreateDto dto) {
            var createdObject = await _baseService.CreateOne(dto);
            return CreatedAtAction("Created", createdObject);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TReadDto>> UpdateOneById ([FromRoute] string id, [FromForm] TUpdateDto update) {
            var updatedObject = await _baseService.UpdateOneById(id, update);
            return Ok(updatedObject);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOneById([FromRoute] string id) {
            return Ok(await _baseService.DeleteOneById(id));
        }
    }
}