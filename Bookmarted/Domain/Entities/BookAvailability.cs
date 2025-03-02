using Bookmarted.Domain.ValueObjects;

namespace Bookmarted.Domain.Entities
{
    public class BookAvailability
    {
        public int BookAvailabilityId { get; set; }

        // Foreign Key Relations
        public int StoreId { get; set; }
        public required Store Store { get; set; }

        public int BookId { get; set; }
        public required Book Book { get; set; }

        // Value Objects
        public required Money Price { get; set; }
        public required Stock Stock { get; set; }
    }
}
