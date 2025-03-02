using Bookmarted.Application.DTOs;
using Bookmarted.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarted.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookAvailabilityController : ControllerBase
    {
        private readonly IBookAvailabilityService _bookAvailabilityService;

        public BookAvailabilityController(IBookAvailabilityService bookAvailabilityService)
        {
            _bookAvailabilityService = bookAvailabilityService;
        }

        [HttpGet("store/{storeId}")]
        public async Task<IActionResult> GetBooksByStore(int storeId)
        {
            var books = await _bookAvailabilityService.GetBooksByStoreAsync(storeId);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAvailability(CreateBookAvailabilityDto availabilityDto)
        {
            var availability = await _bookAvailabilityService.CreateBookAvailabilityAsync(availabilityDto);
            return CreatedAtAction(nameof(GetBooksByStore), new { storeId = availability.StoreId }, availability);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAvailability(int id, UpdateBookAvailabilityDto availabilityDto)
        {
            var result = await _bookAvailabilityService.UpdateBookAvailabilityAsync(id, availabilityDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAvailability(int id)
        {
            var result = await _bookAvailabilityService.DeleteBookAvailabilityAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
