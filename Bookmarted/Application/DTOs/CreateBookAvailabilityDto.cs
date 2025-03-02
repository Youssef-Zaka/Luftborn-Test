namespace Bookmarted.Application.DTOs
{
    public record CreateBookAvailabilityDto(int StoreId, int BookId, decimal Price, int Stock);
}
