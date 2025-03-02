using Bookmarted.Domain.Enums;

namespace Bookmarted.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required Genre Genre { get; set; }
        public required BookCondition Condition { get; set; }

        // Navigation Property
        public ICollection<BookAvailability> BookAvailabilities { get; set; } = new List<BookAvailability>();
    }
}
