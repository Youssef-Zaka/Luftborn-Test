namespace Bookmarted.Application.DTOs
{
    public record BookAvailabilityDto(int AvailabilityId, int StoreId, int BookId, decimal Price, int Stock);
}
