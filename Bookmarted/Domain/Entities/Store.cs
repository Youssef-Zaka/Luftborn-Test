namespace Bookmarted.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public required string Name { get; set; }

        // Navigation Property
        public ICollection<BookAvailability> BookAvailabilities { get; set; } = new List<BookAvailability>();
    }
}
